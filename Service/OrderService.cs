using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using ViewModels;

namespace Service
{
    public class OrderService
    {
        public IEnumerable<Orders> GetOrders()
        {
            var repository = new OrdersRepository();
            return repository.GetOrdersStatus();
        }
    }
}
