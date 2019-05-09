using System;
using System.Collections.Generic;
using System.Text;

namespace MLT.MayLocNuocViet.Utilities.Constants
{
    /// <summary>
    /// CommonConstants
    /// </summary>
    public static class CommonConstants
    {
        public const string DefaultPassword = "User@123";

        public const string AdministratorRoleId = "51bd39ff-6679-454f-a1ec-9fef07d25f80";

        /// <summary>
        /// AppRole
        /// </summary>
        public class AppRole
        {
            public const string AdminRole = "Admin";
        }

        /// <summary>
        /// UserClaims
        /// </summary>
        public class UserClaims
        {
            public const string Roles = "Roles";
        }

        public const string StatusNew = "New";
        public const string StatusCancelled = "Cancelled";
        public const string StatusDeleted = "Deleted";
        public const string UserStatusNew = "New";
        public const string UserStatusDeleted = "Deleted";
        public const string UserStatusLocked = "Locked";
        public const string StatusActive = "Active";
        public const string StatusDeactivated = "Deactivated";

        /// <summary>
        /// DocumentType
        /// </summary>
        public enum DocumentType
        {
            Product,
            Avatar
        }


        public class Catalog
        {
            public const string AppendLevel = "--";
            public const int MaxLevel = 3;
        }

    }
}

/// <summary>
/// AuditLogConstant
/// </summary>
public static class AuditLogConstant
{
    public const string Add = "Add";
    public const string Update = "Update";
    public const string Delete = "Delete";
}

/// <summary>
/// UserRoleConstant
/// </summary>
public static class UserRoleConstant
{
    public const string Discriminator_Default = "UserRole";
}

/// <summary>
/// RoleConstant
/// </summary>
public static class RoleConstant
{
    public const string RoleId_Empty = "00000000-0000-0000-0000-000000000000";
}

/// <summary>
/// MenuItem
/// </summary>
public static class MenuItem
{
    public const string EmailAccount = "EmailAccount";
    public const string EmailTemplate = "EmailTemplate";
    public const string User = "User";
    public const string Role = "Role";
    public const string Menu = "Menu";
    public const string Customer = "Custommer";
    public const string Department = "Department";
    public const string Group = "Group";
    public const string CustomerFeedback = "User";
    public const string EmailTemplateSetting = "CustomerFeedback";
    public const string Maintenance = "Maintenance";
    public const string Notification = "Notification";
    public const string NotificationHistory = "NotificationHistory";
    public const string Parameter = "Parameter";
    public const string ProductCategory = "ProductCategory";
    public const string Product = "Product";
    public const string ProductHistory = "ProductHistory";
    public const string Project = "Project";
    public const string Task = "Task";
    public const string TaskTemplate = "TaskTemplate";
    public const string Vendor = "Vendor";
    public const string Warranty = "Warranty";
    public const string WarrantyPolicy = "WarrantyPolicy";
}

/// <summary>
/// Action
/// </summary>
public static class Action
{
    public const string CanRead = "CanRead";
    public const string CanCreate = "CanCreate";
    public const string CanUpdate = "CanUpdate";
    public const string CanDelete = "CanDelete";
    public const string CanImport = "CanImport";
    public const string CanExport = "CanExport";
}