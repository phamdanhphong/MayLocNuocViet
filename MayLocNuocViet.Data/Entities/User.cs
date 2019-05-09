using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("Users")]
    public class User: IdentityUser<Guid>, IDateTracking
    {
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public int DepartmentRefId { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public Guid ManagerId { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(255)]
        public string Setting { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public virtual ICollection<UserInGroup> UserInGroups { get; set; }

        public virtual ICollection<NotificationHistory> NotificationHistories { get; set; }
    }
}
