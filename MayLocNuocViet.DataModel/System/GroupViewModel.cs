using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fsoft.SKU.CoreApp.Data.Entities;
using Fsoft.SKU.CoreApp.Services.ViewModels.Pagination;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class GroupViewModel
    {
        public int Id { set; get; }

        [Required]
        public string Name { set; get; }

        public string Description { set; get; }

        public string Status { get; set; }

        public virtual ICollection<UserInGroupViewModel> UserInGroups { get; set; }

        public IEnumerable<Group> ListGroup { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

        public IEnumerable<Role> ListRole { get; set; }
    }
}
