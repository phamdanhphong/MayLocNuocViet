using MLT.MayLocNuocViet.DataModel.Hrm;
using System.Collections.Generic;

namespace MLT.MayLocNuocViet.Services.Interfaces
{
    public interface IPositionService
    {
        List<PositionViewModel> GetAll();

        PositionViewModel GetById(int id);

        PositionViewModel Add(PositionViewModel objVm);

        void Update(PositionViewModel objVm);

        void Delete(int id);

        void Save();
    }
}
