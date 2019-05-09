using MLT.MayLocNuocViet.Models.System;
using MLT.MayLocNuocViet.Utilities.Dtos;
using System.Collections.Generic;

namespace MLT.MayLocNuocViet.Services.Interfaces
{
    public interface ICatalogService
    {
        bool Add(CatalogViewModel catalog);

        bool Update(CatalogViewModel entity);

        bool Delete(int id);

        CatalogViewModel GetById(int id);

        List<CatalogViewModel> GetAll();
        
        
        PagedResult<CatalogViewModel> GetAllPaging(string keyword, int page, int pageSize);

        bool IsExistsCatalogName(string name, int id);

        List<CatalogViewModel> GetCatalogTree();
    }
}
