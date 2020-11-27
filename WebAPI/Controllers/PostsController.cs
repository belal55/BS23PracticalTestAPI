using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IVote _voteService;
        public PostsController(IPostService postService,IVote voteService)
        {
            this._postService = postService;
            this._voteService = voteService;
        }

        [HttpGet]
        public PagingWrapper<List<FeedBackDTO>> Get(int page = 1, int size = 10, string searchParam="")
        {
            return _postService.GetAllFeedback(page,size, searchParam);
        }
        [HttpPost]
        public ActionResult<Post> Post(Post post)
        {
            return _postService.InsertPost(post);
        }
        [HttpPost("insertVote")]
        public ActionResult<Vote> insertVote(Vote vote)
        {
            return _voteService.InsertVote(vote);
        }
    }
}