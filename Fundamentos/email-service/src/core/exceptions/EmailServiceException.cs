using System.Transactions;

namespace email_service.src.core.exceptions;

public class EmailServiceException : Exception
{
    public EmailServiceException(string message) : base(message)
    {
    }

    public EmailServiceException(string message, Exception innerException) : base(message, innerException) 
    {
        
    }
}

