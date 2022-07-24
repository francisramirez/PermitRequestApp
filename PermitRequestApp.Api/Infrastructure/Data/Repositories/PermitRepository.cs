using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PermitRequestApp.Api.Infrastructure.Data.Context;
using PermitRequestApp.Api.Infrastructure.Data.Entities;
using PermitRequestApp.Api.Infrastructure.Data.Models;
using PermitRequestApp.Api.Infrastructure.Data.Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace PermitRequestApp.Api.Infrastructure.Data.Repositories
{
    public class PermitRepository : Core.RepositoryBase<Permit>, IPermitRepository
    {
        private readonly ILogger<PermitRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPermitTypeRepository _permitTypeRepository;
        public PermitRepository(PermitDbContext context,
                                ILogger<PermitRepository> logger,
                                IConfiguration configuration,
                                IPermitTypeRepository permitTypeRepository
                                ) : base(context)
        {
            _logger = logger;
            _configuration = configuration;
            _permitTypeRepository = permitTypeRepository;
        }
        public async Task<List<PermitModel>> GetPermitsByPermitType(int permitTypeId)
        {
            List<PermitModel> permitModels = new List<PermitModel>();

            try
            {
                permitModels = (await GetAllPermits())
                                .Where(pe => pe.PermitTypeId== permitTypeId)
                                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(_configuration["PermitMessage:ErrorGettingPermitsByType"], ex.ToString());
            }

            return permitModels;
        }
        public async Task<List<PermitModel>> GetAllPermits()
        {
            List<PermitModel> permits = new List<PermitModel>();

            try
            {
                permits = (from pe in await base.Get()
                           join pet in await _permitTypeRepository.Get() on pe.PermitTypeId equals pet.Id
                           select new PermitModel()
                           {
                               Id = pe.Id,
                               EmployeeLastName = pe.EmployeeLastName,
                               EmployeeName = pe.EmployeeName,
                               PermitDate = pe.PermitDate,
                               PermitTypeDescription = pet.Description,
                               PermitTypeId = pe.PermitTypeId
                           }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(_configuration["PermitMessage:ErrorGetAllPermits"], ex.ToString());

            }

            return permits;
        }

         
    }
}
