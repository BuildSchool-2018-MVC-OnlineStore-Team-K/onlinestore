using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SizeService
    {
        SizeRepository repo = new SizeRepository();

        public IEnumerable<Size> GetSizeTable()
        {
            return repo.GetSizesTable();
        }
    }
}
