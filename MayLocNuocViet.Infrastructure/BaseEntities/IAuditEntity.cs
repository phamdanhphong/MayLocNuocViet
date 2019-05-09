using System;

namespace MLT.MayLocNuocViet.Infrastructure.BaseEntities
{
    public interface IAuditEntity
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}