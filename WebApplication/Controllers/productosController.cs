using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Data;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly DataBaseContext _Dbcontext;
        public productosController(DataBaseContext dbcontext)
        {
           _Dbcontext=dbcontext;
        }
        [HttpGet("all")]
        public IActionResult getAll()
        {
           return Ok(_Dbcontext.productos.ToList());
        }

        [HttpPost("new/")]
        public IActionResult newProduct([FromForm] Producto request)
        {
            _Dbcontext.productos.Add(request);
            _Dbcontext.SaveChanges();

            var response = new
            {
                Status = 200,
                Message = "Producto Ingresado",
                Data = request
            };
            return Ok(response);
        }

        [HttpPut("update/")]

        public IActionResult updateProduct([FromForm] Producto request)
        {
            var Actualizar = _Dbcontext.productos.Where(t =>
             t.ProductoId ==
             request.ProductoId).FirstOrDefault();

            if (Actualizar != null)
            {
                Actualizar.Nombre = request.Nombre;
                _Dbcontext.productos.Update(Actualizar);
                _Dbcontext.SaveChanges();

                var response = new
                {
                    Status = 200,
                    Message = "Producto Modificado",
                    Data = Actualizar
                };
                return Ok(response);
            }
            return StatusCode(400, "El Id no se ha encontrado :( ");
        }

        [HttpDelete("delete/")]
        public IActionResult deleteProduct([FromForm] Producto request)
        {
            var Eliminar = _Dbcontext.productos.Where(t =>
             t.ProductoId ==
             request.ProductoId).FirstOrDefault();

            if (Eliminar != null)
            {
                Eliminar.ProductoId = request.ProductoId;
                _Dbcontext.productos.Remove(Eliminar);
                _Dbcontext.SaveChanges();

                var response = new
                {
                    Status = 200,
                    Message = "Producto Eliminado",
                    Data = Eliminar
                };
                return Ok(response);
            }
            return StatusCode(400, "El Id no se ha encontrado :( ");
        }
    }
}
