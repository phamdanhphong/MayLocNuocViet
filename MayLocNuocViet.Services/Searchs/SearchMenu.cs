using   Fsoft.SKU.CoreApp.Services.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Services.Searchs
{
    public class SearchMenu
    {
        public int TotalItems { get; set; }
        public List<MenuViewModel> MenuViewModels { get; set; }
    }
}
