using System;
using System.Collections.Generic;
using System.Text;

namespace  MLT.MayLocNuocViet.Data.Interfaces
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }


    }
}
