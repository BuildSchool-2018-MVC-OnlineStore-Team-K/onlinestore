using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSchool.MVCSolution.OnlineStore.Utilities

//給予每一個類別使用 寫成Tmodel 泛型類別  , 給他where限制 : 他議定要是類別 
//可以用無參數的方式產生執行個體 用new出來 , 框住一定要符合條件才可以使用此泛型工具
{
    public static class DbReaderModelBinder<TModel> where TModel : class, new()
    {//datareader傳進來 做好之後傳回指定model  , 其他東西都換成TModel 符合地都可以用 , customers 等都改成tmodel 其他做法都依樣
        public static TModel Bind(IDataRecord record)
        {
            var properties = typeof(TModel).GetProperties();
            var model = new TModel();

            for (var i = 0; i < record.FieldCount; i++)
            {
                var fieldName = record.GetName(i);
                var property = properties.FirstOrDefault(
                    p => p.Name == fieldName);

                if (property == null)
                    continue;

                if (!record.IsDBNull(i))
                    property.SetValue(model,
                        record.GetValue(i));
            }

            return model;
        }
    }
}

