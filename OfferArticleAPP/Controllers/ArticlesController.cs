using AutoMapper;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using OfferArticleWebApi.Dto;
using ServiceLayer.Services;

namespace OfferArticleWebApi.Controllers
{
    [ApiController]
    [Route("/api/articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(ILogger<ArticlesController> logger, IArticleService articleService, IMapper mapper)
        {
            _logger = logger;
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ArticleIdDto>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetArticles()
        {
            try
            {
                var articles = _mapper.Map<List<ArticleIdDto>>(_articleService.GetArticles());

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Ok(articles);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ArticleIdDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetArticle(int id)
        {
            try
            {
                var articleModel = _articleService.GetSpecificArticle(id);

                if (articleModel == null)
                {
                    return NotFound();
                }

                var article = _mapper.Map<ArticleIdDto>(articleModel);

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Ok(article);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(ArticleIdDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateArticle([FromBody] ArticleCreateDto articleCreate)
        {
            try
            {
                if (articleCreate == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var articleDbModel = _mapper.Map<Article>(articleCreate);

                var response = _articleService.CreateArticle(articleDbModel);

                if (response.ExistSameName)
                {
                    ModelState.AddModelError("", "Item with same Name already exists");
                    return StatusCode(422, ModelState);
                }

                var responseModel = _mapper.Map<ArticleIdDto>(response.Entity);

                return Ok(responseModel);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateArticle([FromRoute] int id, [FromBody] ArticleCreateDto articleCreate)
        {
            try
            {
                if (articleCreate == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var articleDbModel = _mapper.Map<Article>(articleCreate);

                var response = _articleService.UpdateArticle(id, articleDbModel);

                if (!response.RecordExists)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteArticle([FromRoute] int id)
        {
            try
            {
                var response = _articleService.DeleteArticle(id);

                if (!response.RecordExists)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
