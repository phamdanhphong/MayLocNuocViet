using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("Roles")]
    public class Role : IdentityRole<Guid> , IDateTracking
    {
        public Role() : base()
        {

        }
        public Role(string name, string description) : base(name)
        {
            this.Description = description;
        }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public virtual ICollection<GroupRole> GroupRoles { get; set; }
    }
}
