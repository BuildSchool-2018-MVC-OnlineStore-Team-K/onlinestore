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
    [RoutePrefix("backend")]
    public class BackEndController : Controller
    {
        [Route("")]
        // GET: BackEnd
        public ActionResult ProductsManage()
        {
            return View();
        }


        [Route("")]
        [HttpPost]
        public ActionResult ProductsManage(HttpPostedFileBase file)
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

    }
}