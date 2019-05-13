using Fsoft.SKU.CoreApp.Data.Entities;
using Fsoft.SKU.CoreApp.Services.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        public string Status { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public IEnumerable<MenuViewModel> ListMenuViewModel { get; set; }

        public IEnumerable<Menu> ListMenus { get; set; }

        public PaginationInfo PaginationInfo { get; set; }
    }
}
