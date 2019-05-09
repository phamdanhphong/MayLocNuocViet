using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("RolePermissions")]
    public class RolePermission
    {
        [Key, Column(Order = 0)]
        public Guid RoleId { get; set; }

        [Key, Column(Order = 1)]
        public int MenuId { get; set; }

        public bool CanRead { set; get; }

        public bool CanCreate { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public bool CanImport { set; get; }

        public bool CanExport { set; get; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

    }
}
