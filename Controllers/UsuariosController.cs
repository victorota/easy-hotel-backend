using System.Collections.Generic;
using easy_hotel_backend.Models;
using easy_hotel_backend.Repositorio;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace easy_hotel_backend.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private ApiDbContext _usuarioDbContext;
        private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;

        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult getById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Crate([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioRepositorio.Add(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut]
        public IActionResult Update(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioId != id)
            {
                return BadRequest();
            }
            var _usuario = _usuarioRepositorio.Find(id);
            if (_usuario == null)
            {
                return NotFound();
            }
            _usuario.Email = usuario.Email;
            _usuario.Nome = usuario.Nome;

            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioRepositorio.Remove(id);
            return new ContentResult();
        }
    }
}