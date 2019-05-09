using System;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class NotificationHistoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Id_Notification { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Note { get; set; }

        public DateTime PushDate { get; set; }

        public string Status { set; get; }

        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public virtual UserViewModel User { get; set; }

        public virtual NotificationViewModel Notification { get; set; }

    }
}