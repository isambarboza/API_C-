using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        private object? animal;

        public UsuariosController(IUsuariosRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }
        [HttpGet("GetAllUsuarios")]
        public async Task<ActionResult<List<UsuariosModel>>> GetAllUsuarios()
        {
            List<UsuariosModel> usuarios = await _usuariosRepositorio.GetAll();
            return Ok(usuarios);
            ;
        }
        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuariosModel>> GetUsuarioId(int id)
        {
            UsuariosModel usuario = await _usuariosRepositorio.GetById(id);
            return Ok(usuario);
            ;
        }
        [HttpPost("insertUsuario")]
        public async Task<ActionResult<UsuariosModel>> insertUsuario([FromBody] UsuariosModel usuariosModel)
        {
            UsuariosModel usuario = await _usuariosRepositorio.InsertUsuario(usuariosModel);
            return Ok(usuario);
        }
        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<UsuariosModel>> UpdateUsuario(int id, [FromBody] UsuariosModel usuariosModel)
        {
            usuariosModel.UsuarioId = id;
            UsuariosModel usuario = await _usuariosRepositorio.UpdateUsuario(usuariosModel, id);
            return Ok(usuario);
        }
        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult<UsuariosModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuariosRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }
    }
}


