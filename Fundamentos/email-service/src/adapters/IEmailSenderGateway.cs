namespace email_service.src.adapters;

public interface IEmailSenderGateway
{
    public async Task<string> SendEmail(string to, string subject, string body) {
        
    }
}

