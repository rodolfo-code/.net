namespace email_service.src.core;

public interface IEmailSenderUseCase
{
    void SendEmail(string to, string subject, string body);
}

