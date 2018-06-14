using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SizeTypeSelectItems
    {

        public bool Disabled { get; set; }
        //
        // 摘要:
        //     表示此項目要包裝至其中的 optgroup HTML 項目。在選取清單中，支援多個具有相同名稱的群組。它們會利用參照等式來進行比較。
        //public SelectListGroup Group { get; set; }
        //
        // 摘要:
        //     取得或設定值，這個值表示是否已選取此 System.Web.Mvc.SelectListItem。
        //
        // 傳回:
        //     如果項目已選取，則為 true，否則為 false。
        public bool Selected { get; set; }
        //
        // 摘要:
        //     取得或設定選取之項目的文字。
        //
        // 傳回:
        //     文字。
        public string Text { get; set; }
        //
        // 摘要:
        //     取得或設定選取之項目的值。
        //
        // 傳回:
        //     數值。
        public string Value { get; set; }




    }
}




