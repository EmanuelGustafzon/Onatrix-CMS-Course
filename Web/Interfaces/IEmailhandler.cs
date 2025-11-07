namespace Web.Interfaces;

public interface IEmailhandler
{
    public Task<bool> SendEmail(string html, string text, string subject, string[] recievers);
}
