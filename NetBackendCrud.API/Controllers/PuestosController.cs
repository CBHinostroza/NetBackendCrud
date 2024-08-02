using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetBackendCrud.API.Handlers;
using NetBackendCrud.Domain.DTOs.Puesto;
using System.Net;

namespace NetBackendCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly IPuestoRepository _puestoRepository;
        private readonly ApiResponse _apiResponse;
        public PuestosController(IPuestoRepository puestoRepository)
        {
            _puestoRepository = puestoRepository;
            _apiResponse = new ApiResponse();
        }

        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<ApiResponse>> FindById([FromRoute] int id)
        {
            var model = await _puestoRepository.Get(id);

            if (model == null)
            {
                _apiResponse.Success = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.Message = "Registro no encontrado.";
                return NotFound(_apiResponse);
            }

            _apiResponse.Success = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Message = "Registro encontrado.";

            return Ok(_apiResponse);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            _apiResponse.Success = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Message = string.Empty;
            _apiResponse.Result = await _puestoRepository.GetAll();

            return Ok(_apiResponse);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, PuestoUpdateRequestDto model)
        {
            var modelOld = await _puestoRepository.Get(id);

            if (modelOld == null)
            {
                _apiResponse.Success = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.Message = "Registro no encontrado";
                return NotFound(_apiResponse);
            }

            modelOld.NOM_PUEST = model.NOM_PUEST;
            modelOld.COD_USUAR_MODIF = model.COD_USUAR_MODIF;

            try
            {
                await _puestoRepository.Update(modelOld);
            }
            catch (DbUpdateException ex)
            {
                _apiResponse.Success = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Message = ex.InnerException!.Message;
                return NotFound(_apiResponse);
            }

            return NoContent();
        }
    }
}
