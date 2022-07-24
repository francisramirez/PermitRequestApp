using PermitRequestApp.Api.Infrastructure.Data.Core;
using System;
namespace PermitRequestApp.Api.Infrastructure.Data.Entities
{
    /// <summary>
    /// Entity that represents requests for permits
    /// </summary>
    public partial class Permit : BaseEntity
    {
        /// <summary>
        /// Name of the employee
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Employee Last Name
        /// </summary>
        public string EmployeeLastName { get; set; }
        /// <summary>
        /// Type of permit requested
        /// </summary>
        public int PermitTypeId { get; set; }
        /// <summary>
        /// Date for when the permit is requested
        /// </summary>
        public DateTime PermitDate { get; set; }
    }
}
