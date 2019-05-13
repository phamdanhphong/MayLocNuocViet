using AutoMapper;
using AutoMapper.QueryableExtensions;
using MLT.MayLocNuocViet.Data.Entities;
using MLT.MayLocNuocViet.DataModel.Hrm;
using MLT.MayLocNuocViet.Infrastructure.Interfaces;
using MLT.MayLocNuocViet.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MLT.MayLocNuocViet.Services.Implementation
{
    public class PositionService : IPositionService
    {
        private IEFRepository<Position> _positionRepository;
        private IEFUnitOfWork _unitOfWork;

        public PositionService(IEFRepository<Position> positionRepository,
            IEFUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }


        public List<PositionViewModel> GetAll()
        {
            return _positionRepository.FindAll().OrderBy(x => x.OrderBy).ProjectTo<PositionViewModel>().ToList();
        }

        public PositionViewModel GetById(int id)
        {
            return Mapper.Map<Position, PositionViewModel>(_positionRepository.GetById(id));
        }

        public PositionViewModel Add(PositionViewModel objVm)
        {
            var obj = Mapper.Map<PositionViewModel, Position>(objVm);
            _positionRepository.Insert(obj);
            return objVm;
        }

        public void Update(PositionViewModel objVm)
        {
            var obj = Mapper.Map<PositionViewModel, Position>(objVm);
            _positionRepository.Update(obj);
        }

        public void Delete(int id)
        {
            _positionRepository.Remove(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}
