using System;
namespace PermitRequestApp.Api.Services.Exceptions
{
    public class PermitException : Exception
    {
        public PermitException(string message) : base(message)
        {

        }
    }
}
