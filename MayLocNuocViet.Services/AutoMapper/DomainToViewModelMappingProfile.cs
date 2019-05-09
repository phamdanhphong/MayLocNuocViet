using AutoMapper;
using MLT.MayLocNuocViet.Data.Entities;
using MLT.MayLocNuocViet.Models.Email;
using MLT.MayLocNuocViet.Models.System;

namespace MLT.MayLocNuocViet.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {


            CreateMap<EmailAccount, EmailAccountViewModel>();

            CreateMap<Catalog, CatalogViewModel>();
        }
    }
}
