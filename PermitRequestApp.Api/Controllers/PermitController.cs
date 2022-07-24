using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PermitRequestApp.Api.Services.Contracts;
using PermitRequestApp.Api.Services.Core;
using PermitRequestApp.Api.Services.Dtos;

namespace PermitRequestApp.Api.Controllers
{
    public class PermitController : Controller
    {
        private readonly IPermitService _permitService;

        public PermitController(IPermitService permitService)
        {
            _permitService = permitService;
        }

        [HttpGet("GetPermits")]
        public async Task<ActionResult<ServiceResponse>> GetPermits()
        {
            var response = await _permitService.GetPermits();
           return Ok(response);
        }

        [HttpGet("GetPermitTypes")]
        public async Task<ActionResult<ServiceResponse>> GetPermitTypes()
        {
            var response = await _permitService.GetPermitTypes();
            return Ok(response);
        }


        [HttpGet("GetPermitsById/{id}")]
        public async Task<ActionResult<ServiceResponse>> GetPermitsById(int id)
        {
            var response = await _permitService.GetPermitById(id);
            return Ok(response);
        }
        [HttpPost("SavePermit")]
        public async Task<ActionResult<ServiceResponse>> SavePermit([FromBody]PermitAddDto permitAddDto) 
        {
            var response = await _permitService.SavePermit(permitAddDto);
            return Ok(response);
        } 
   
        [HttpPost("EditPermit")]
        public async Task<ActionResult<ServiceResponse>> EditPermit([FromBody]PermitEditDto permitEditDto)
        {
            var response = await _permitService.EditPermit(permitEditDto);
            return Ok(response);
        }
       
        [HttpPost("RemovePermit")]
        public async Task<ActionResult<ServiceResponse>> RemovePermit([FromBody]PermitRemoveDto removeDto)
        {
            var response = await _permitService.RemovePermit(removeDto.Id);
            return Ok(response);
        }
    }
}
