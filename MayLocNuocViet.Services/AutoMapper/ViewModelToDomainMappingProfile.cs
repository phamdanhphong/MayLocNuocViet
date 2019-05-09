using AutoMapper;
using Fsoft.SKU.CoreApp.Data.Entities;

namespace Fsoft.SKU.CoreApp.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>();

            CreateMap<RoleViewModel, Role>();
            CreateMap<GroupViewModel, Group>();
            CreateMap<UserInGroupViewModel, UserInGroup>();
            CreateMap<MenuViewModel, Menu>();
            CreateMap<RolePermissionViewModel, RolePermission>();

            CreateMap<UserRoleViewModel, UserRole>();

            CreateMap<NotificationViewModel, Notification>();
            CreateMap<NotificationHistoryViewModel, NotificationHistory>();
            CreateMap<ParameterViewModel, Parameter>();
        }
    }
}
