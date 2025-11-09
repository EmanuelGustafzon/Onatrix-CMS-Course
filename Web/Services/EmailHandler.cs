using Azure;
using Azure.Communication.Email;
using System.Diagnostics;
using Web.Interfaces;

namespace Web.Services;

public class EmailHandler(IConfiguration config) : IEmailhandler
{
    private readonly IConfiguration _config = config;
    public bool SendEmailConfirmation(string reciever)
    {
        try
        {
            string connectionString = _config["COMMUNICATION_SERVICES_CONNECTION_STRING"];
            var emailClient = new EmailClient(connectionString);

            var emailMessage = new EmailMessage(
                senderAddress: _config["EMAIL_DOMAIN"],
                content: new EmailContent("We have revieved your message")
                {
                    PlainText = "Thanks for contacting us at Onatrix We have recieved your message and we will soon get back to you!",
                    Html = @"
		            <html>
			            <body>
				            <h1>
					            Thanks for contacting us at Onatrix We have recieved your message and we will soon get back to you!
				            </h1>
			            </body>
		            </html>"
                },
                recipients: new EmailRecipients(new List<EmailAddress>
                {
                new EmailAddress(reciever)
                }));


            EmailSendOperation emailSendOperation = emailClient.Send(
                WaitUntil.Started,
                emailMessage);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
