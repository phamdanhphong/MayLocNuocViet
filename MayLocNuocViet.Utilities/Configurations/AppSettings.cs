using  MLT.MayLocNuocViet.Utilities.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MLT.MayLocNuocViet.Utilities.Configurations
{
    public static class AppSettings
    {
        private static IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

        public static string ConnectString
        {
            get { return Configuration["ConnectionStrings:DefaultConnection"]; }
        }

        public static string JwtFormatAudienceId
        {
            get { return Configuration["wn:JwtFormatAudienceId"]; }
        }

        public static string JwtFormatAudienceSecret
        {
            get { return Configuration["wn:JwtFormatAudienceSecret"]; }
        }

        public static string SendGridWebApiKey
        {
            get { return Configuration["Sendgrid:SendGridWebApiKey"]; }
        }

        public static string ApiDomain
        {
            get { return Configuration["wn:ApiDomain"]; }
        }

        public static string TokenTimeout
        {
            get { return Configuration["wn:TokenTimeout"]; }
        }

        public static string IntranetDomain
        {
            get { return Configuration["wn:IntranetDomain"]; }
        }

        public static string MaxFailedAccessAttemptsBeforeLockout
        {
            get { return Configuration["wn:MaxFailedAccessAttemptsBeforeLockout"]; }
        }

        public static string DefaultAccountLockoutTimeSpan
        {
            get { return Configuration["wn:DefaultAccountLockoutTimeSpan"]; }
        }

        public static int RegistrationExpireDays
        {
            get { return StringUtil.ConvertToInt(Configuration["wn:RegistrationExpireDays"]); }
        }

        public static int ChangePwdExpireDays
        {
            get { return StringUtil.ConvertToInt(Configuration["wn:ChangePwdExpireDays"]); }
        }

        public static string DefaultDocumentFolder
        {
            get { return Configuration["FileUploading:DefaultDocumentFolder"]; }
        }


        public static string DefaultFolderUpload
        {
            get { return Configuration["FileUploading:DefaultFolderUpload"]; }
        }

        public static string DefaultAvatarFolder
        {
            get { return Configuration["FileUploading:DefaultAvatarFolder"]; }
        }

        public static string WopiDiscoveryXml
        {
            get { return Configuration["wopi:DiscoveryXml"]; }
        }

        public static string WopiServer
        {
            get { return Configuration["wopi:Server"]; }
        }

        public static string HmacKey
        {
            get { return Configuration["wopi:HmacKey"]; }
        }

        public static string EmailRegisterSubject
        {
            get { return Configuration["email:RegisterSubject"]; }
        }

        public static string EmailUnlockUserSubject
        {
            get { return Configuration["email:UnlockUserSubject"]; }
        }

        public static string EmailReactiveUserSubject
        {
            get { return Configuration["email:ReactiveUserSubject"]; }
        }

        public static string EmailResetPasswordSubject
        {
            get { return Configuration["email:ResetPasswordSubject"]; }
        }

        public static string EmailForgotPasswordSubject
        {
            get { return Configuration["email:ForgotPasswordSubject"]; }
        }

        public static string EmailChangeRoleSubject
        {
            get { return Configuration["email:ChangeRoleSubject"]; }
        }

        public static string EmailChangeUserSubject
        {
            get { return Configuration["email:ChangeUserrSubject"]; }
        }

        public static string EmailSystemDefault
        {
            get { return Configuration["Email:EmailSystemDefault"]; }
        }

        public static string NameSystemDefault
        {
            get { return Configuration["Email:NameSystemDefault"]; }
        }

        public static string EmailServer
        {
            get { return Configuration["MailSettings:Server"]; }
        }

        public static string EmailUserName
        {
            get { return Configuration["MailSettings:UserName"]; }
        }

        public static string EmailPassword
        {
            get { return Configuration["MailSettings:Password"]; }
        }

        public static string EmailFromEmail
        {
            get { return Configuration["MailSettings:FromEmail"]; }
        }

        public static string EmailFromName
        {
            get { return Configuration["MailSettings:FromName"]; }
        }

        public static string EmailPort
        {
            get { return Configuration["MailSettings:Port"]; }
        }

        public static string EmailEnableSsl
        {
            get { return Configuration["MailSettings:EnableSsl"]; }
        }

        #region Multi Factor Authentication
        //public static Dictionary<string, bool> MfaRolleOutAccounts
        //{
        //    get
        //    {
        //        var accountList = Configuration["mfa.rolledOut.accounts"].Split(';');
        //        return accountList.ToDictionary(key => key.Trim().ToLower(), value => true);
        //    }
        //}
        #endregion Multi Factor Authentication

        #region Send mail to all users
        public static bool SendMailToAllUserInTesting
        {
            get
            {
                var config = Configuration["sendMailToAllUsers.testing"].Trim();
                return !config.Equals("false", StringComparison.OrdinalIgnoreCase);
            }
        }
        //public static List<string> SendMailToAllUserTestingAccounts
        //{
        //    get
        //    {
        //        var accountList = Configuration["sendMailToAllUsers.testAccounts"].Split(';');
        //        return accountList.ToList();
        //    }
        //}
        #endregion Send mail to all users
    }
}
