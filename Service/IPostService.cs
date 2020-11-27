using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IPostService
    {
        PagingWrapper<List<FeedBackDTO>> GetAllFeedback(int page, int size, string searchParam);
        Post InsertPost(Post post);
    }
}
