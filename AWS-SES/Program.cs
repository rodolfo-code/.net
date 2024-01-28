using Amazon;
using System;
using System.Collections.Generic;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Amazon.Runtime;

namespace AmazonSESSample;

class Program
{
    static readonly string senderAddress = "joker.rdf@gmail.com";
    static readonly string receiverAddress = "joker.rdf@gmail.com";
    static readonly string configSet = "ConfigSet";

    static readonly string subject = "Amazon SES test (AWS SDK for .NET)";

    // The email body for recipients with non-HTML email clients.
    static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                    + "This email was sent through Amazon SES "
                                    + "using the AWS SDK for .NET.";

    // The HTML body of the email.
    // The HTML body of the email.
    static readonly string htmlBody = @"<html>
                                        <head></head>
                                        <body>
                                          <h1>Amazon SES Test (AWS SDK for .NET)</h1>
                                          <p>This email was sent with
                                            <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
                                            <a href='https://aws.amazon.com/sdk-for-net/'>
                                              AWS SDK for .NET</a>.</p>
                                        </body>
                                        </html>";

    static async Task Main(string[] args)
    {
        AWSCredentials credentials = new BasicAWSCredentials("AKIA4LL66G54ZE6QMWP4", "4+3jwAzpvSxPIsLhPUsBOME3kX7G6tu68rGLLWN4");

        // Replace USWest2 with the AWS Region you're using for Amazon SES.
        // Acceptable values are EUWest1, USEast1, and USWest2.
        using (var client = new AmazonSimpleEmailServiceClient(credentials, RegionEndpoint.EUNorth1))
        {

            var sendRequest = new SendEmailRequest
            {
                Source = senderAddress,
                Destination = new Destination
                {
                    ToAddresses =
                    new List<string> { receiverAddress }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = htmlBody
                        },
                        Text = new Content
                        {
                            Charset = "UTF-8",
                            Data = textBody
                        }
                    }
                },
                // If you are not using a configuration set, comment
                // or remove the following line 
                //ConfigurationSetName = configSet
            };

            try
            {
                Console.WriteLine("Sending email using Amazon SES...");
                var response = client.SendEmailAsync(sendRequest);
                Console.WriteLine("The email was sent successfully." + response);
            }
            catch(Exception ex)
            {
                Console.WriteLine("The email was not sent.");
                Console.WriteLine("Error message: " + ex.Message);
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        };
    }

}
