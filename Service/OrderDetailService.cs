using BuildSchool.MVCSolution.OnlineStore.OrderDetailRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Service
{
    public class OrderDetailService
    {
        public IEnumerable<OrderDetailViewModel> GetMemberOrderDetail(int MemberID)
        {
            var repository = new OrderDetailRepository();
            return repository.GetMemberOrderDetail(MemberID);
        }
    }
}
