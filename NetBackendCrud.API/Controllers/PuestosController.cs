using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetBackendCrud.API.Handlers;
using NetBackendCrud.Application.DTOs.Puesto;
using System.Net;

namespace NetBackendCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApiResponse _apiResponse;
        public PuestosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = new ApiResponse();
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<ApiResponse>> BuscarPorId([FromRoute] int id)
        {
            var model = await _unitOfWork.puestoRepository.GetByIdAsync(id);

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

        [HttpGet("Listar")]
        public async Task<ActionResult<ApiResponse>> Listar()
        {
            _apiResponse.Success = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Message = string.Empty;
            _apiResponse.Result = await _unitOfWork.puestoRepository.GetAllAsync();

            return Ok(_apiResponse);
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Actualizar([FromRoute] int id, PuestoUpdateRequestDto model)
        {
            var modelOld = await _unitOfWork.puestoRepository.GetByIdAsync(id);

            if (modelOld == null)
            {
                _apiResponse.Success = false;
                _apiResponse.StatusCode = HttpStatusCode.NotFound;
                _apiResponse.Message = "Registro no encontrado.";
                return NotFound(_apiResponse);
            }

            modelOld.NOM_PUEST = model.NOM_PUEST;
            modelOld.FEC_USUAR_MODIF = DateTime.Now;
            modelOld.COD_USUAR_MODIF = model.COD_USUAR_MODIF;

            try
            {
                _unitOfWork.puestoRepository.Update(modelOld);
                await _unitOfWork.puestoRepository.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                _apiResponse.Success = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Message = ex.InnerException!.Message;
                return BadRequest(_apiResponse);
            }

            return NoContent();
        }
    }
}
