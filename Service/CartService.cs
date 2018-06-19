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

        public IEnumerable<CartViewModel> GetCartProducts(string Account)
        {
            var orders = new OrdersRepository();
            var result = orders.GetCartProductsInformation(Account);
            foreach(var item in result)
            {
                item.Total = item.UnitPrice * item.Quantity;
            }
            return result;
        }

        public bool AlterCartToOrders(int MemberID , int OrderID)
        {
            var orders = new OrdersRepository();
            return  orders.UpdateCartToOrders(MemberID,OrderID);
        }


        public int GetMemberIdByAccount(string Account)
        {
            var members = new MembersRepository();
            return members.GetMemberIDByAccount(Account);
        }

        public int GetCartOrderIDByMemberID(int MemberId)
        {
            var orders = new OrdersRepository();
            return orders.GetCartOrderID(MemberId);
        }


    }
}
