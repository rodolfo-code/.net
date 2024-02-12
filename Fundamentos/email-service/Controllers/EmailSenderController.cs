//using email_service.src.application;
using Amazon.SimpleEmail.Model;
using email_service.src.application;
using email_service.src.core;
using email_service.src.core.exceptions;
using Microsoft.AspNetCore.Mvc;

namespace email_service.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailSenderController : ControllerBase
{
    private readonly EmailSenderService emailSenderService;

    public EmailSenderController(EmailSenderService emailSenderService)
    {
        this.emailSenderService = emailSenderService;
    }

    public async Task<IActionResult> sendEmail([FromBody] EmailRequest request)
    {
        try
        {
            this.emailSenderService.SendEmail(request.to, request.subject, request.body);
            return Ok( "Email send successfukky");
        } catch (EmailServiceException exception) { 
            return BadRequest( exception.Message );
        }
    }
}

