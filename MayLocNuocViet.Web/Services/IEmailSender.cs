using System.Threading.Tasks;

namespace MLT.MayLocNuocViet.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
