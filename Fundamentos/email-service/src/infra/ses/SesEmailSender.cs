using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using email_service.src.adapters;
using email_service.src.core.exceptions;

namespace email_service.src.infra.ses;

 //: IEmailSenderGateway
public class SesEmailSender
{
    private readonly IAmazonSimpleEmailService amazonSimpleEmailService;

    public SesEmailSender(IAmazonSimpleEmailService amazonSimpleEmailService)
    {
        this.amazonSimpleEmailService = amazonSimpleEmailService;
    }

    public async Task<string> SendEmail(List<string> to, string subject, string body)
    {
        //SendEmailRequest request = new SendEmailRequest()
        var messageId = "";
        

        try
        {
            var response = await amazonSimpleEmailService.SendEmailAsync(
                new SendEmailRequest
                {
                    Destination = new Destination()
                    {
                        BccAddresses = new List<string> { "rod.vgo@gmai.com" },
                        //CcAddresses = ccAddresses,
                        ToAddresses = to,
                    },
                    Message = new Message
                    {
                        Subject = new Content
                        {
                            Charset = "UTF-8",
                            Data = subject
                        },
                        Body = new Body
                        {
                            //Html = new Content
                            //{
                            //    Charset = "UTF-8",
                            //    Data = bodyHtml
                            //},
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = body
                            }
                        },

                    },
                }
            );
            messageId = response.MessageId;
        } 
        catch (AmazonServiceException exeption ) {
            throw new EmailServiceException("Failuer while sending email", exeption);
        }

        return messageId;
    }
}

