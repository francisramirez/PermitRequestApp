using PermitRequestApp.Api.Services.Core;
using PermitRequestApp.Api.Services.Dtos;
using PermitRequestApp.Api.Services.Responses;
using System.Threading.Tasks;

namespace PermitRequestApp.Api.Services.Contracts
{
    public interface IPermitService
    {
        Task<ServiceResponse> GetPermits();
        Task<ServiceResponse> GetPermitById(int Id);
        Task<ServiceResponse> GetPermitTypes();
        Task<ServiceResponse> GetPermitsByType(int permitTypeId);
        Task<PermitResponse> SavePermit(PermitAddDto permitAddDto);
        Task<PermitResponse> EditPermit(PermitEditDto permitAddDto);
        Task<ServiceResponse> RemovePermit(int permitId);
    }
}
