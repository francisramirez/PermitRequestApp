﻿namespace PermitRequestApp.Api.Services.Core
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
