using System;
using System.Collections.Generic;
using System.Text;

namespace MLT.MayLocNuocViet.Utilities.Constants
{
    public static class RegularExpressionConstant
    {
        public const string NotAllowSpecialChar = @"[\w \-_.ZüöäÜÖÄß etc]*$";
        public const string PasswordRules = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20})";
        public const string EmailRules = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
    }
}
