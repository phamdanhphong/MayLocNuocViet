using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("Menus")]
    public class Menu : IDateTracking
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(500)]
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

    }
}
