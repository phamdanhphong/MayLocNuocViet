using System;
using System.Collections.Generic;
using System.Text;

namespace  MLT.MayLocNuocViet.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDeleted { set; get; }
    }
}
