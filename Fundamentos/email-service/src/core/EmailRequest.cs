namespace email_service.src.core;

public class EmailRequest
{
    public string to { get;}
    public string subject { get; }
    public string body { get; }

    public EmailRequest(string to, string subject, string body)
    {
        to = to;
        subject = subject;
        body = body;
    }
}
