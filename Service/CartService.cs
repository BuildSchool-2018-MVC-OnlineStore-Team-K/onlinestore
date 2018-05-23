using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Service
{
    public class CartService
    {

        public IEnumerable<CartViewModel> GetCartProducts(int MemberID , int OrderID)
        {
            var orders = new OrdersRepository();
            var result = orders.GetCartProductsInformation(MemberID, OrderID);
            foreach(var item in result)
            {
                item.Total = item.UnitPrice * item.Quantity;
            }
            return result;
        }

    }
}
