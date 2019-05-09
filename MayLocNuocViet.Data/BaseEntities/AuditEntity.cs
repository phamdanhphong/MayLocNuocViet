using System;
using System.ComponentModel.DataAnnotations;

namespace  MLT.MayLocNuocViet.Data.BaseEntities
{
    public class AuditEntity : IAuditEntity
    {
        public DateTime? CreatedDate { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }
    }
}