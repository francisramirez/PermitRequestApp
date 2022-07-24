using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PermitRequestApp.Api.Infrastructure.Data.Repositories.Contracts;
using PermitRequestApp.Api.Services.Contracts;
using PermitRequestApp.Api.Services.Core;
using PermitRequestApp.Api.Services.Dtos;
using PermitRequestApp.Api.Services.Exceptions;
using PermitRequestApp.Api.Services.Responses;
using PermitRequestApp.Api.Services.Extentions;
using PermitRequestApp.Api.Infrastructure.Data.Entities;
using PermitRequestApp.Api.Infrastructure.Data.Models;

namespace PermitRequestApp.Api.Services
{
    public class PermitService : IPermitService
    {
        private readonly IPermitRepository _permitRepository;
        private readonly IPermitTypeRepository _permitTypeRepository;
        private readonly ILoggerService<PermitService> _loggerService;
        private readonly IConfiguration _configuration;

        public PermitService(IPermitRepository permitRepository,
                             IPermitTypeRepository permitTypeRepository,
                             ILoggerService<PermitService> loggerService,
                             IConfiguration configuration
                             )
        {
            _permitRepository = permitRepository;
            _permitTypeRepository = permitTypeRepository;
            _loggerService = loggerService;
            _configuration = configuration;
        }

        public async Task<PermitResponse> SavePermit(PermitAddDto permitAddDto)
        {
            PermitResponse response = new PermitResponse();

            try
            {
                if (string.IsNullOrEmpty(permitAddDto.EmployeeName))
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorEmployeeName"];
                    return response;
                }
                if (string.IsNullOrEmpty(permitAddDto.EmployeeLastName))
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorEmployeeLastName"];
                    return response;
                }
                if (!permitAddDto.PermitTypeId.HasValue)
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorPermitType"];
                    return response;
                }
                if (!permitAddDto.PermitDateDesc.HasValue)
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorPermitDate"];
                    return response;
                }

                Permit permit = permitAddDto.ConvertToPermitAddDtoToPermitEntity();
                await _permitRepository.Add(permit);
                response.Id = permit.Id;
                response.Message = _configuration["PermitMessage:PermitSave"];
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = _configuration["PermitMessage:ErrorAddingPermit"];
                _loggerService.LogError(response.Message, ex.ToString());

            }
            return response;
        }
        public async Task<PermitResponse> EditPermit(PermitEditDto permitEditDto)
        {
            PermitResponse response = new PermitResponse();

            try
            {
                if (string.IsNullOrEmpty(permitEditDto.EmployeeName))
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorEmployeeName"];
                    return response;
                }
                if (string.IsNullOrEmpty(permitEditDto.EmployeeLastName))
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorEmployeeLastName"];
                    return response;
                }
                if (!permitEditDto.PermitTypeId.HasValue)
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorPermitType"];
                    return response;
                }
                if (!permitEditDto.PermitDate.HasValue)
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:ErrorPermitDate"];
                    return response;
                }

                Permit permit = await _permitRepository.GetById(permitEditDto.Id);
                
                if (permit != null)
                {
                    permit.EmployeeLastName = permitEditDto.EmployeeLastName;
                    permit.EmployeeName = permitEditDto.EmployeeName;
                    permit.PermitDate = permitEditDto.PermitDate.Value;
                    permit.PermitTypeId = permitEditDto.PermitTypeId.Value;

                    await _permitRepository.Update(permit);
                    response.Data = permit.ConvertToPermitEntityToPermitModel();
                    response.Message = _configuration["PermitMessage:PermitEdit"];

                }
                else
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:PermitNotExist"];
                  
                }
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = _configuration["PermitMessage:ErrorUpdatingPermit"];
                _loggerService.LogError(response.Message, ex.ToString());

            }

            return response;
        }
        public async Task<ServiceResponse> RemovePermit(int permitId)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                var permit = await _permitRepository.GetById(permitId);

                if (permit != null)
                {
                    await _permitRepository.Remove(permit);
                    response.Message = _configuration["PermitMessage:PermitRemove"]; ;
                }

                else
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:PermitNotExist"];
                }
              
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = _configuration["PermitMessage:ErrorRemovingPermit"];
                _loggerService.LogError(response.Message, ex.ToString());

            }

            return response;
        }
        public async Task<ServiceResponse> GetPermits()
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                response.Data = await _permitRepository.GetAllPermits();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = _configuration["PermitMessage:ErrorGettingPermitsByType"];
                _loggerService.LogError(response.Message, ex.ToString());
            }

            return response;
        }
        public async Task<ServiceResponse> GetPermitsByType(int permitTypeId)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await _permitRepository.GetPermitsByPermitType(permitTypeId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = _configuration["PermitMessage:ErrorGettingPermitsByType"];
                _loggerService.LogError(response.Message, ex.ToString());
            }

            return response;
        }
        public async Task<ServiceResponse> GetPermitTypes()
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                response.Data = await _permitTypeRepository.Get();
            }
            catch (Exception ex)
            {
                response.Success = true;
                response.Message = _configuration["PermitMessage:ErrorGetPermitType"];
                _loggerService.LogError(response.Message, ex.ToString());
            }

            return response;
        }
        public async Task<ServiceResponse> GetPermitById(int Id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                Permit permit = await _permitRepository.GetById(Id);

                if (permit is null)
                {
                    response.Success = false;
                    response.Message = _configuration["PermitMessage:PermitNotExist"];
                    return response;
                }

                PermitModel permitModel = permit.ConvertToPermitEntityToPermitModel();

                response.Data = permitModel;
            }
            catch (Exception ex)
            {
                response.Success = true;
                response.Message = _configuration["PermitMessage:ErrorGetPermitById"];
                _loggerService.LogError(response.Message, ex.ToString());

            }
            return response;
        }
    }
}
