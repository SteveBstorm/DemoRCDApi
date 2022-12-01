using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRCDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_articleService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Article a)
        {
            _articleService.Create(a);
            return Ok();
        }
    }
}
