using email_service.src.adapters;
using email_service.src.core;

namespace email_service.src.application;

public class EmailSenderService : IEmailSenderUseCase
{
    private readonly IEmailSenderGateway emailSenderGateway;

    public EmailSenderService(IEmailSenderGateway emailSenderGateway)
    {
        this.emailSenderGateway = emailSenderGateway;
    } 

    public void SendEmail(string to, string subject, string body)
    {
        this.emailSenderGateway.SendEmail(to, subject, body);
    }

    
}

