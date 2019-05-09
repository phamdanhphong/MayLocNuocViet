using System;
using System.Collections.Generic;
using System.Text;
using   MLT.MayLocNuocViet.Data.Enums;

namespace  MLT.MayLocNuocViet.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
