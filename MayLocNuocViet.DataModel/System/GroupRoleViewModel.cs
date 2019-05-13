using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Fsoft.SKU.CoreApp.Data.Entities;
using Fsoft.SKU.CoreApp.Services.ViewModels.Pagination;
using Fsoft.SKU.CoreApp.Services.ViewModels.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    
    public class GroupRoleViewModel : IdentityUserRole<Guid>
    {
        public GroupViewModel Group { get; set; }

        public RoleViewModel RoleModel { get; set; }

        public PaginationInfo PaginationInfo { get; set; }
    }
}
