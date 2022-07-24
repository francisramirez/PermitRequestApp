using System.Collections.Generic;
using System.Threading.Tasks;
using PermitRequestApp.Api.Infrastructure.Data.Core;
using PermitRequestApp.Api.Infrastructure.Data.Entities;
using PermitRequestApp.Api.Infrastructure.Data.Models;

namespace PermitRequestApp.Api.Infrastructure.Data.Repositories.Contracts
{
    public interface IPermitRepository : IRepositoryBase<Permit>
    {
         Task<List<PermitModel>> GetPermitsByPermitType(int permitTypeId);
        Task<List<PermitModel>> GetAllPermits();
       

    }
}
