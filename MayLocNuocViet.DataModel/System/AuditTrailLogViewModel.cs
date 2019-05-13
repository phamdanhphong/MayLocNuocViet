using Fsoft.SKU.CoreApp.Data.Entities;
using Fsoft.SKU.CoreApp.Services.ViewModels.Pagination;
using System;
using System.Collections.Generic;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class AuditTrailLogViewModel
    {
        public Guid Id { get; set; }

        public string Action { get; set; }

        public string TableName { get; set; }

        public string RecordId { get; set; }

        public string OldValue { get; set; }

        public string NewValue { set; get; }

        public string UserId { set; get; }

        public DateTime ChangeTime{ get; set; }

        public IEnumerable<AuditTrailLogViewModel> ListMenuViewModel { get; set; }

        public IEnumerable<AuditTrailLog> ListAudittrailLog   { get; set; }

        public PaginationInfo PaginationInfo { get; set; }
    }
}
