using   Fsoft.SKU.CoreApp.Services.ViewModels.Setting;
using   Fsoft.SKU.CoreApp.Services.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Services.Searchs
{
    public class SearchParameter
    {
        public int TotalItems { get; set; }
        public List<ParameterViewModel> ParameterViewModels { get; set; }
    }
}
