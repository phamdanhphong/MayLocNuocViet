using AutoMapper;
using   Fsoft.SKU.CoreApp.Services.ViewModels.System;
using   Fsoft.SKU.CoreApp.Data.Entities;

namespace  Fsoft.SKU.CoreApp.Services.AutoMapper
{
    public class BaseModelToDomainMappingProfile : Profile
    {
        public BaseModelToDomainMappingProfile()
        {
            CreateMap<UserBaseModel, User>();
            CreateMap<GroupBaseModel, Group>();
            CreateMap<NotificationBaseModel, Notification>();
            CreateMap<NotificationHistoryBaseModel, NotificationHistory>();
            CreateMap<RolePermissionBaseModel, RolePermission>();
        }
    }
}
