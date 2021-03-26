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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService iCommentService;

        public CommentController(ICommentService iCommentService)
        {
            this.iCommentService = iCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> getComments(Guid KNOWLEDGE_BASE_ID)
        {
            return Ok(await iCommentService.getComments(KNOWLEDGE_BASE_ID));
        }
        [HttpPost]
        public async Task<IActionResult> comments(CommentsModel param_obj)
        {
            return Ok(await iCommentService.createComments(param_obj));
        }
    }
}
