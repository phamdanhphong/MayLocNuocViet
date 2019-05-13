using System;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class NotificationHistoryBaseModel
    {
        public int Id { get; set; }

        [Required]
        public int Id_Notification { get; set; }

        [Required]
        public string UserId { get; set; }

        public string Note { get; set; }

        public DateTime PushDate { get; set; }

        public string Status { set; get; }

    }
}