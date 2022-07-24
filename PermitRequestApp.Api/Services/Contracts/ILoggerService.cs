using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitRequestApp.Api.Services.Contracts
{
    public interface ILoggerService<TObject> where TObject : class
    {
        void LogError(string message, params object[] args);
        void LogInformation(string message, params object[] args);
    }
}
