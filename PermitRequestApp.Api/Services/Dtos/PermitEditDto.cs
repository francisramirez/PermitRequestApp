using System;

namespace PermitRequestApp.Api.Services.Dtos
{
    public class PermitEditDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public short? PermitTypeId { get; set; }
        public DateTime? PermitDate { get; set; }
    }
}
