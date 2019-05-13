using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class NotificationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Note { get; set; }

        public string Status { set; get; }

        public DateTime CreatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public DateTime UpdatedDate { set; get; }

        public virtual ICollection<NotificationHistoryViewModel> NotificationHistories { get; set; }
    }
}