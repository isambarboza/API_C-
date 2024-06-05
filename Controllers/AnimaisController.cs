using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly IAnimaisRepositorio _animaisRepositorio;
        private object? animal;

        public AnimaisController(IAnimaisRepositorio animaisRepositorio)
        {
            _animaisRepositorio = animaisRepositorio;
        }
        [HttpGet("GetAllAnimais")]
        public async Task<ActionResult<List<AnimaisModel>>> GetAllAnimais()
        {
            List<AnimaisModel> animais = await _animaisRepositorio.GetAll();
            return Ok(animais);
            ;
        }
        [HttpGet("GetAnimaisId/{id}")]
        public async Task<ActionResult<AnimaisModel>> GetAnimaisId(int id)
        {
            AnimaisModel animal = await _animaisRepositorio.GetById(id);
            return Ok(animal);
            ;
        }
        [HttpPost("insertAnimais")]
        public async Task<ActionResult<AnimaisModel>> insertAnimal([FromBody] AnimaisModel animaisModel)
        {
            AnimaisModel animal = await _animaisRepositorio.InsertAnimal(animaisModel);
            return Ok(animal);
        }
        [HttpPut("UpdateAnimais/{id:int}")]
        public async Task<ActionResult<AnimaisModel>> UpdateAnimal(int id, [FromBody] AnimaisModel animaisModel)
        {
            animaisModel.AnimaisId = id;
            AnimaisModel animal = await _animaisRepositorio.UpdateAnimal(animaisModel, id);
            return Ok(animal);
        }
        [HttpDelete("DeleteAnimais/{id:int}")]
        public async Task<ActionResult<AnimaisModel>> DeleteAnimal(int id)
        {
            bool deleted = await _animaisRepositorio.DeleteAnimal(id);
            return Ok(deleted);
        }
    }
}


