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
                senderAddress: "DoNotReply@7dbc1663-afc5-4f3b-a2e9-c01cca66f59a.azurecomm.net",
                content: new EmailContent("Thanks for reaching out to Onatrix")
                {
                    PlainText = "Thanks for reaching out to us at Onatrix. We will get back to you soon.",
                    Html = @"
		            <html>
			            <body>
				            <h1>
					            Thanks for reaching out to us at Onatrix. We will get back to you soon.
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
