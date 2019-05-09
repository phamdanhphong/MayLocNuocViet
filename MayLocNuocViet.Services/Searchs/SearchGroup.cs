using   Fsoft.SKU.CoreApp.Services.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Services.Searchs
{
    public class SearchGroup
    {
        public int TotalItems { get; set; }
        public List<GroupViewModel> GroupViewModels { get; set; }
    }
}
