using System.ComponentModel.DataAnnotations;

namespace MLT.MayLocNuocViet.Models.Email
{
    public class EmailAccountViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email address"), DataType(DataType.Text)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Email display name")]
        public string DisplayName { get; set; }

        [Display(Name = "Host")]
        public string Host { get; set; }

        [Display(Name = "Port")]
        public int Port { get; set; }

        [Display(Name = "User")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "SSL")]
        public bool EnableSsl { get; set; }

        [Display(Name = "Use default credentials")]
        public bool UseDefaultCredentials { get; set; }

        public string FriendlyName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(DisplayName))
                    return Email + " (" + DisplayName + ")";

                return Email;
            }
        }

        [EmailAddress]
        [Display(Name = "Send email to")]
        public string SendTestEmailTo { get; set; }

        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

    }
}
