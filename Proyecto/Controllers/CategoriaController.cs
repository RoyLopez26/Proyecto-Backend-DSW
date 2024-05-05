using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Proyecto.Repositorio.DAO;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> registrarCategoria(Categoria categoria)
        {
            var mensaje = await Task.Run(() => new CategoriaDAO().registrarCategoria(categoria));
            return Ok(mensaje);
        }

        [HttpGet]
        public async Task<IActionResult> obtenerCategorias()
        {
            var lista = await Task.Run(() => new CategoriaDAO().obtenerCategorias());
            return Ok(lista);
        }
    }
}
