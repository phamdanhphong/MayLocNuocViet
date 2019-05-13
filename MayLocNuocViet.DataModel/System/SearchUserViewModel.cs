using System.Collections.Generic;

namespace Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class SearchUserViewModel
    {
        public ParamSearchUser Param { get; set; }
        public IList<UserViewModel> UserDtos { get; set; }
    }
}