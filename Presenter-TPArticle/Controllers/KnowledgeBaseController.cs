using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLEAN_Application.Interface;
using CLEAN_Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presenter_TPArticle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeBaseController : ControllerBase
    {
        private readonly IKnowledgeBaseService testDBService;
        // GET: TestDBController
        public KnowledgeBaseController(IKnowledgeBaseService testDBService)
        {
            this.testDBService = testDBService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await testDBService.get());
        }

        [HttpGet("ArticleDescription")]
        public async Task<IActionResult> Get(Guid KnowledgeBaseNumber)
        {
            return Ok(await testDBService.getDescription(KnowledgeBaseNumber));
        }

        [HttpPost]

        public async Task<IActionResult> Post(ArticleModel param_obj)
        {
            return Ok(await testDBService.create(param_obj));
        }
        [HttpPut]
        public async Task<IActionResult> Put(ArticleModel param_obj)
        {
            return Ok(await testDBService.update(param_obj));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid param_obj)
        {
            return Ok(await testDBService.delete(param_obj));
        }

    }
}
