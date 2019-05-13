using   Fsoft.SKU.CoreApp.Utilities.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace  Fsoft.SKU.CoreApp.Services.ViewModels.System
{
    public class RegisterUserViewModel : ConcurrencyCheckViewModel
    {
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required]
        [RegularExpression(RegularExpressionConstant.EmailRules, ErrorMessage = "Invalid email pattern")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        public string[] RoleIds { get; set; }

        public string[] GroupIds { get; set; }

        public string Description { get; set; }

        public int DepartmentRefId { get; set; }


    }
}