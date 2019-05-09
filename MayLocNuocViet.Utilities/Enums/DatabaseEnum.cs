using System.ComponentModel;

namespace MLT.MayLocNuocViet.Utilities.Enums
{
    public static class DatabaseEnum
    {
        public enum ActivityStatus
        {
            [Description("Open")]
            Open,
            [Description("In Progress")]
            InProgress,
            [Description("Finished")]
            Finished
        }

        public enum Function
        {
            [Description("ROLE_FUNCTION_HOME")]
            Home = 1,
            [Description("ROLE_FUNCTION_TOPIC")]
            Topics,
            [Description("ROLE_FUNCTION_MEETING")]
            Meetings,
            [Description("ROLE_FUNCTION_OPENPOINT")]
            OpenPoints,
            [Description("ROLE_FUNCTION_ROLE")]
            Roles,
            [Description("ROLE_FUNCTION_USER")]
            Users,
            [Description("ROLE_FUNCTION_MEETINGGROUP")]
            MeetingGroups,
            [Description("ROLE_FUNCTION_DOCUMENT")]
            Documents,
            [Description("ROLE_FUNCTION_GUEST")]
            Guest
        }

        public enum Permission
        {
            [Description("ROLE_PERMISSION_CREATE")]
            Create = 1,
            [Description("ROLE_PERMISSION_READ")]
            Read,
            [Description("ROLE_PERMISSION_UPDATE")]
            Update,
            [Description("ROLE_PERMISSION_DELETE")]
            Delete
        }

        public enum Status
        {
            Opening = 1,
            Planning = 2,
            Processing = 3,
            Delegation = 4,
            FollowUp = 5,
            [Description("Completion")]
            Completed = 6,
            Archived = 7
        }

        public enum UserStatus
        {
            Pending = 0,
            Activated,
            DeActivated,
            Locked,
            IsSuperAdmin
        }

        public enum Category
        {
            [Description("CATEGORY_HOME")]
            Home = 1,
            [Description("CATEGORY_TOPICS")]
            Topics = 2,
            [Description("CATEGORY_MEETINGGROUPS")]
            MeetingGroups = 3,
            [Description("CATEGORY_MEETINGS")]
            Meetings = 4,
            [Description("CATEGORY_OPENPOINTS")]
            OpenPoints = 5,
            [Description("CATEGORY_ROLES")]
            Roles = 6,
            [Description("CATEGORY_PERMISSIONS")]
            Permissions = 7,
            [Description("CATEGORY_USERS")]
            Users = 8,
            [Description("CATEGORY_DOCUMENTS")]
            Documents = 9,
            [Description("CATEGORY_OTHERS")]
            Others = 10
        }

        public enum OperatorOption
        {
            And,
            Or
        }
    }
}