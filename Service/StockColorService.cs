using BuildSchool.MVCSolution.OnlineStore.Models;
using BuildSchool.MVCSolution.OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StockColorService
    {
        StockColorRepository repo = new StockColorRepository();
        public IEnumerable<StockColor> GetStockColorsTable(int id)
        {
            return repo.GetStockColorTable(id);
        }
    }
}
