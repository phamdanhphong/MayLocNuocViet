using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using   Fsoft.SKU.CoreApp.Data.Interfaces;

namespace  Fsoft.SKU.CoreApp.Data.Entities
{
    [Table("NotificationHistorys")]
    public class NotificationHistory : IDateTracking
    {
        [Key]
        public int Id { get; set; }

        public int Id_Notification { get; set; }

        public Guid UserId { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        public DateTime PushDate { get; set; }

        [StringLength(20)]
        public string Status { set; get; }

        [StringLength(100)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [StringLength(100)]
        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("Id_Notification")]
        public virtual Notification Notification { get; set; }

    }
}
