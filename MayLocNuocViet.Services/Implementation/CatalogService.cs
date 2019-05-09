using AutoMapper;
using AutoMapper.QueryableExtensions;
using MLT.MayLocNuocViet.Data.Entities;
using MLT.MayLocNuocViet.Infrastructure.Interfaces;
using MLT.MayLocNuocViet.Models.System;
using MLT.MayLocNuocViet.Services.Interfaces;
using MLT.MayLocNuocViet.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MLT.MayLocNuocViet.Services.Implementation
{
    public class CatalogService :  ICatalogService
    {
        private IEFRepository<Catalog> _catalogRepository;
        private IEFUnitOfWork _unitOfWork;

        public CatalogService(IEFRepository<Catalog> catalogRepository,
            IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _catalogRepository = catalogRepository;
        }



        public PagedResult<CatalogViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _catalogRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = query.Count();
            var query1 = query.OrderByDescending(x => x.CreatedDate)
              .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query1.ProjectTo<CatalogViewModel>().ToList();
            var result = from d in data
                         join q in query
                         on d.ParentId equals q.Id into tmp
                         from ed in tmp.DefaultIfEmpty()
                         select new CatalogViewModel
                         {
                             Id = d.Id,
                             Name = d.Name,
                             Description = d.Description,
                             Path=d.Path,
                             Url=d.Url,
                             ParentName = ed?.Name ?? String.Empty
                         };

            var paginationSet = new PagedResult<CatalogViewModel>()
            {
                Results = result.ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }


        public List<CatalogViewModel> GetAll()
        {
            var entities = _catalogRepository.GetAll().ToList();
            var results = Mapper.Map<List<CatalogViewModel>>(entities);
            return results;
        }

   
        public bool IsExistsCatalogName(string name, int id)
        {
            var result = _catalogRepository.FindAll(x => x.Name == name.Trim() && x.Id != id);
            if (result.Any())
            {
                return true;
            }
            return false;
        }

        public bool Add(CatalogViewModel entityvm)
        {
            try
            {
                var entity = Mapper.Map<CatalogViewModel, Catalog>(entityvm);
                _catalogRepository.Insert(entity);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CatalogViewModel GetById(int id)
        {
            var entity = _catalogRepository.GetById(id);
            var result = Mapper.Map<CatalogViewModel>(entity);
            return result;
        }

        public bool Delete(int id)
        {
            try
            {
                _catalogRepository.Remove(id);
                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CatalogViewModel entityvm)
        {
            try
            {
                var entity = _catalogRepository.GetById(entityvm.Id);
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = entityvm.UpdatedBy;
                entity.Name = entityvm.Name;
                entity.ParentId = entityvm.ParentId;
                entity.Path = entityvm.Path;
                entity.Url = entityvm.Url;
                _catalogRepository.Update(entity);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                //return false;
            }
        }

        public List<CatalogViewModel> GetCatalogTree()
        {
            List<CatalogViewModel> allCat = this.GetAll();
            List<CatalogViewModel> rsTree = new List<CatalogViewModel>();
            BuildTree(0, 0, allCat, ref rsTree);
            return rsTree;
        }

        /// <summary>
        /// recursive build tree function for catalog
        /// </summary>
        /// <param name="parentId">parentId is ID of root tree</param>
        /// <param name="level">level is of the tree</param>
        /// <param name="listCatalog">list catalog that you want to build tree</param>
        /// <param name="rs">rs is return result after that build tree</param>
        /// <returns></returns>
        private List<CatalogViewModel> BuildTree(int parentId, int level, List<CatalogViewModel> listCatalog, ref List<CatalogViewModel> rs)
        {
            if (level >= 3)
                return rs;
            else
            {
                String prefix = "";
                for (int i = 0; i < level; i++)
                {
                    prefix = prefix + "--";
                }
                foreach (var item in listCatalog)
                {
                    if (item.ParentId == parentId)
                    {
                        item.Name = prefix + item.Name;
                        rs.Add(item);
                        List<CatalogViewModel> tmpRs = BuildTree(item.Id, level + 1, listCatalog, ref rs);
                    }
                }
                return rs;
            }
        }
    }
}
