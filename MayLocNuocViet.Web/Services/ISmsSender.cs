using System.Threading.Tasks;

namespace MLT.MayLocNuocViet.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
