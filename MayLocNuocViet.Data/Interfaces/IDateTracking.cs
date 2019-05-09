using System;
using System.Collections.Generic;
using System.Text;

namespace  MLT.MayLocNuocViet.Data.Interfaces
{
    public interface IDateTracking
    {
        string CreatedBy { set; get; }

        DateTime CreatedDate { set; get; }

        string UpdatedBy { set; get; }

        DateTime UpdatedDate { set; get; }
    }
}
