using   Fsoft.SKU.CoreApp.Services.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Services.Searchs
{
    public class SearchUser
    {
        public int TotalItems { get; set; }
        public List<UserViewModel> UserViewModels { get; set; }
    }
}
