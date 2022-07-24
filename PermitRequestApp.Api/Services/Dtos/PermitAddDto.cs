using System;

namespace PermitRequestApp.Api.Services.Dtos
{
    public class PermitAddDto
    {
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public short? PermitTypeId { get; set; }
        public DateTime? PermitDateDesc { get; set; }
    }
}
