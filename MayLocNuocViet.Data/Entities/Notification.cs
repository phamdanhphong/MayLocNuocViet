using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("Notifications")]
    public class Notification : IDateTracking
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public virtual ICollection<NotificationHistory> NotificationHistories { get; set; } 

    }
}
