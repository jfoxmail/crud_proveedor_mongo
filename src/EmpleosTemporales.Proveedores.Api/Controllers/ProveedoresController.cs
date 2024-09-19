using EmpleosTemporales.Proveedores.Application.DataBase.Models;
using EmpleosTemporales.Proveedores.Application.Exceptions;
using EmpleosTemporales.Proveedores.Application.Features;
using EmpleosTemporales.Proveedores.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmpleosTemporales.Proveedores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        
        public ProveedoresController() 
        {            
        }

        [AllowAnonymous]
        [HttpGet("Get-token")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<IActionResult> GetToken([FromServices] IGetTokenJwtService getTokenJwtService)
        {
            var data = getTokenJwtService.Execute("123456");
            if (data == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        /*
        [HttpPost("Create")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<ActionResult> Create(Proveedor proveedor, [FromServices] IProveedorService proveedorService)
        {
            var data = await proveedorService.CrearProveedor(proveedor);
            if (data == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
        */

        [HttpPost("Create")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<ActionResult> Create([FromBody] Proveedor proveedor, [FromServices] IProveedorService proveedorService)
        {
            if (proveedor == null)
            {
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest, "Proveedor no puede ser nulo"));
            }

            var data = await proveedorService.CrearProveedor(proveedor);

            if (data == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, "No se creó ningún proveedor"));
            }

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }


        [HttpGet("Read-all")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<IActionResult> GetAll([FromServices] IProveedorService proveedorService)
        {
            var data = await proveedorService.ObtenerProveedores();
            if (data == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));            

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }                

        [HttpGet("Read-by-id/{id}")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<ActionResult> GetById(string id, [FromServices] IProveedorService proveedorService)
        {
            if(id == "")
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await proveedorService.ObtenerProveedorPorId(id);
            if (data == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }       

        [HttpPut("Update")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<ActionResult> Update(Proveedor proveedor, [FromServices] IProveedorService proveedorService)
        {
            var data = await proveedorService.ActualizarProveedor(proveedor);
            if (data == null)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("Delete/{id}")]
        [TypeFilter(typeof(ExceptionManager))]
        public async Task<ActionResult> Delete(string id, [FromServices] IProveedorService proveedorService)
        {
            bool data = await proveedorService.EliminarProveedor(id);
            if (!data)
                return StatusCode(StatusCodes.Status204NoContent, ResponseApiService.Response(StatusCodes.Status204NoContent, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

    }    
}
