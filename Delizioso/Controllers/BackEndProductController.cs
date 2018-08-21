using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApplication1.Controllers
{
    [RoutePrefix("backendproduct")]
    public class BackEndProductController : Controller
    {

        [Route("productview")]
        public ActionResult ProductsManage()
        {
            var service = new BackEndProductService();
            return View(service.GetAllProductDetail());
        }


        [Route("Create")]
        // GET: BackEnd
        public ActionResult ProductsCreate()
        {
            return View();
        }


        [Route("Create")]
        [HttpPost]
        public ActionResult ProductsCreate(HttpPostedFileBase file)
        {
            string fileLocation = "";
            string extension = "";
            
            if (Request.Files["file"].ContentLength > 0)
            {
                extension =
                     System.IO.Path.GetExtension(file.FileName);

                if (extension == ".xls" || extension == ".xlsx")
                {
                    fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation)) // 驗證檔案是否存在
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["file"].SaveAs(fileLocation); // 存放檔案到伺服器上

                }
            }

            // 建立一個工作簿
            XSSFWorkbook excel;

            // 檔案讀取
            using (FileStream files = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                excel = new XSSFWorkbook(files); // 將剛剛的Excel 讀取進入到工作簿中
            }


            // Excel 的哪一個活頁簿，有兩種方式可以取得活頁簿
            ISheet sheet = excel.GetSheetAt(0);  // 在第幾個活頁簿，饅頭建議使用，畢竟我們不知道使用者會把活頁部取神麼名字，先抓地一個在說！(從0開始計算)
            ISheet sheetb = excel.GetSheet("Name"); // 利用名稱擷取

             var productsModels = new List<CreateProductsModel>();

            for (int row = 1; row <= sheet.LastRowNum; row++) // 使用For 走訪所有的資料列
            {
                var model = new CreateProductsModel();
                if (sheet.GetRow(row) != null) // 驗證是不是空白列
                {
                    // for (int c = 0; c <= sheet.GetRow(row).LastCellNum; c++) // 使用For 走訪資料欄
                    // {

                    model.Category = sheet.GetRow(row).GetCell(0).StringCellValue;
                    model.ProductName = sheet.GetRow(row).GetCell(1).StringCellValue;
                    model.Price = (int)sheet.GetRow(row).GetCell(2).NumericCellValue;
                    model.Size = sheet.GetRow(row).GetCell(3).StringCellValue;
                    model.Color = sheet.GetRow(row).GetCell(4).StringCellValue;
                    model.Stock = (int)sheet.GetRow(row).GetCell(5).NumericCellValue;
                    //sheet.GetRow(row).GetCell(c).NumericCellValue; // 數值
                    //sheet.GetRow(row).GetCell(c).StringCellValue; // 字串
                    //sheet.GetRow(row).GetCell(c).BooleanCellValue; // 布林
                    //sheet.GetRow(row).GetCell(c).DateCellValue; // 日期
                    // }
                }
                productsModels.Add(model);

            }

            var backendproductservice =new BackEndProductService();
            // var OrderByResult  = backendproductservice.OrderByProducts(productsModels);

            // var GetDifferentProductName = backendproductservice.GetDifferentProductName(productsModels);
            backendproductservice.InsertIntoDataBase(productsModels);


            ViewBag.IsAuthenticated = true;

            return View(productsModels);
        }

        [Route("CreatePicture")]
        public ActionResult PictureManage()
        {

            return View();
        }


        
        [Route("UpdateProductInfoResult/{ProductID}")]
        [HttpPost]
        public ActionResult UpdateProductInfoResult(int productID , List<ProductDetailViewModel> ProductDetailmodel)
        {
            var x = ProductDetailmodel;
            var service = new ProductsService();
            service.UpdateProductInfoByProductID_SizeID_ColorID(ProductDetailmodel);
            var result = service.GetProductDetailByProdycuID(productID);
            return View(result);
        }


        
        //預設
        [Route("UpdateProductInfo/{ProductID}")]
        public ActionResult UpdateProductInfo(int productID)
        {
            var service = new ProductsService();

            //這我沒辦法 他不能寫在service裡面 抓不到SelectListItem這東西
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "XS", Value = "XS", Selected = false });
            items.Add(new SelectListItem() { Text = "S", Value = "S", Selected = false });
            items.Add(new SelectListItem() { Text = "M", Value = "M", Selected = true });
            items.Add(new SelectListItem() { Text = "L", Value = "L", Selected = false });
            items.Add(new SelectListItem() { Text = "XL", Value = "XL", Selected = false });
            ViewBag.SelectedItems = items;

            var result = service.GetProductDetailByProdycuID(productID);
            return View(result);
           
        }




        [Route("CreatePicture")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PictureManage(IEnumerable<HttpPostedFileBase> upfiles)
        {
            //檢查是否有選擇檔案
            if (upfiles != null)
            {
                var i = 0;
                foreach (var file in upfiles)
                {
                    //檢查檔案大小要限制也可以在這裡做
                    if (file.ContentLength > 0)
                    {
                        string fileType = file.FileName.Split('.').Last().ToUpper();
                        var NewFileName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + i+"."+fileType;
                        string savedName = Path.Combine(Server.MapPath("~/Images/"), NewFileName);
                        file.SaveAs(savedName);
                        i++;
                    }
                }
            }
            return RedirectToAction("CreatePicture");
        }

        [Route("searchmember")]
        public ActionResult SearchAllMember()
        {
            var service = new MemberService();
            ViewBag.Members = service.GetMembers().ToList();
            return PartialView();
        }

        [Route("orderstatus")]
        public ActionResult OrdersStatus()
        {
            var service = new OrderService();
            ViewBag.Orders = service.GetOrders().ToList();
            return PartialView();
        }

    }
}