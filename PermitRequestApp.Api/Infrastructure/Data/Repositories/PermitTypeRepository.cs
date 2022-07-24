using PermitRequestApp.Api.Infrastructure.Data.Context;
using PermitRequestApp.Api.Infrastructure.Data.Entities;
using PermitRequestApp.Api.Infrastructure.Data.Repositories.Contracts;

namespace PermitRequestApp.Api.Infrastructure.Data.Repositories
{
    public class PermitTypeRepository : Core.RepositoryBase<PermitType>, IPermitTypeRepository
    {
        public PermitTypeRepository(PermitDbContext context) : base(context)
        {

        }
    }
}
