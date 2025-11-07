using Web.Interfaces;

namespace Web.Services;

public class EmailHandler : IEmailhandler
{
    public Task<bool> SendEmail(string html, string text, string subject, string[] recievers)
    {
        throw new NotImplementedException();
    }
}
