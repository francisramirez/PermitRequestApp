using PermitRequestApp.Api.Infrastructure.Data.Entities;
using PermitRequestApp.Api.Infrastructure.Data.Models;
using PermitRequestApp.Api.Services.Dtos;

namespace PermitRequestApp.Api.Services.Extentions
{
    public static class PermitExtention
    {
        public static Permit ConvertToPermitEditDtoToPermitEntity(this PermitEditDto permitEditDto)
        {
            return new Permit()
            {
                EmployeeLastName = permitEditDto.EmployeeLastName,
                EmployeeName = permitEditDto.EmployeeName,
                Id = permitEditDto.Id,
                PermitDate = permitEditDto.PermitDate.Value,
                PermitTypeId = permitEditDto.PermitTypeId.Value
            };
        }
        public static Permit ConvertToPermitAddDtoToPermitEntity(this PermitAddDto permitAddDto)
        {
            return new Permit()
            {
                EmployeeLastName = permitAddDto.EmployeeLastName,
                EmployeeName = permitAddDto.EmployeeName,
                PermitDate = permitAddDto.PermitDateDesc.Value,
                PermitTypeId = permitAddDto.PermitTypeId.Value
            };
        }
        public static PermitModel ConvertToPermitEntityToPermitModel(this Permit permit)
        {
            return new PermitModel()
            {
                EmployeeLastName = permit.EmployeeLastName,
                EmployeeName = permit.EmployeeName,
                PermitDate = permit.PermitDate,
                PermitTypeId = permit.PermitTypeId, 
                Id=permit.Id 
            };
        }
    }
}
