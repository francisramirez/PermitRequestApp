using System;

namespace PermitRequestApp.Api.Infrastructure.Data.Models
{
    public class PermitModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public int PermitTypeId { get; set; }
        public string PermitTypeDescription { get; set; }
        public DateTime PermitDate { get; set; }

        public string PermitDateDesc { 
            get 
            {
                return this.PermitDate.ToString("MM/dd/yyyy");
            } 
        }
    }
}
