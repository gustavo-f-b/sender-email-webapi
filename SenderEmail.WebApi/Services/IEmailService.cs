using SenderEmail.WebApi.Models;

namespace SenderEmail.WebApi.Services
{
    public interface IEmailService
    {
        string Send(Email model);
    }
}
