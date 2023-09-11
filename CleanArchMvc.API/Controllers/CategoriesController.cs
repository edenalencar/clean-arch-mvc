using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Lista todas categorias.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categorias não encontradas");
            }
            return Ok(categories);
        }

        /// <summary>
        /// Obtém uma categoria.
        /// </summary>        
        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(category);
        }

        /// <summary>
        /// Cria uma categoria.
        /// </summary>        
        /// <returns>Retorna a categoria do identificador</returns>
        /// <remarks>
        /// Requisição simpls:
        ///
        ///     Post /Categoria
        ///     {
        ///         "id": 0,
        ///         "name": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna a categoria criada</response>
        /// <response code="400">Se categoria for nula</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Dados inválidos");
            }
            await _categoryService.Add(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        /// <summary>
        /// Atualiza uma categoria.
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest("Dados inválidos");
            }

            if (categoryDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            await _categoryService.Update(categoryDTO);
            return Ok(categoryDTO);
        }

        /// <summary>
        /// Exlui uma categoria.
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            await _categoryService.Remove(id);
            return Ok(category);
        }
    }
}
