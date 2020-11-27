using Domain;
using Domain.DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepo;
        private readonly IRepository<Comment> _commentRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Vote> _voteRepo;
        public PostService(IRepository<Post> postRepo,IRepository<Comment> commentRepo, IRepository<User> userRepo, IRepository<Vote> voteRepo)
        {
            this._postRepo = postRepo;
            this._commentRepo = commentRepo;
            this._userRepo = userRepo;
            this._voteRepo = voteRepo;
        }
        public PagingWrapper<List<FeedBackDTO>> GetAllFeedback(int page, int size,string searchParam)
        {
            PagingWrapper<List<FeedBackDTO>> pagingModel = new PagingWrapper<List<FeedBackDTO>>();

            List<FeedBackDTO> modelList = new List<FeedBackDTO>();
            var allPost = _postRepo.GetAll().ToList();
            
            allPost.ForEach(p =>
            {
                p.comments = this._commentRepo.GetAll().Where(c => c.PostId == p.Id).ToList();
                FeedBackDTO parentModel = new FeedBackDTO();
                parentModel.Id = p.Id;
                parentModel.Content = p.Title;
                parentModel.Author = p.Author;
                parentModel.CreationDate = p.CreationTime;
                parentModel.TotalComments = p.comments.Count;
                parentModel.isParent = true;
                modelList.Add(parentModel);

                p.comments.ToList().ForEach(cm =>
                {
                    FeedBackDTO childModel = new FeedBackDTO();
                    childModel.Id = cm.Id;
                    childModel.Content = cm.Content;
                    childModel.Author = this._userRepo.Get(cm.UserId).UserName.ToString();
                    childModel.CreationDate = cm.CreationTime;
                    childModel.TotalDislikes = this._voteRepo.GetAll().Where(v=>v.CommentId==cm.Id && v.IsLiked==false).Count();
                    childModel.TotalLikes = this._voteRepo.GetAll().Where(v => v.CommentId == cm.Id && v.IsLiked == true).Count();
                    childModel.isParent = false;
                    modelList.Add(childModel);
                });
            });

            // for searching 
            if (searchParam != null && searchParam != "")
            {
                modelList = modelList.Where(ap => ap.Content.ToLower().Contains(searchParam.ToLower()) == true).ToList();
            }

            var query = modelList;
            var entries =  query.Skip((page - 1) * size).Take(size).ToList();
            var count =  query.Count();
            var totalPages = (int)Math.Ceiling(count / (float)size);
            var firstPage = 1; // obviously
            var lastPage = totalPages;
            var prevPage = page > firstPage ? page - 1 : firstPage;
            var nextPage = page < lastPage ? page + 1 : lastPage;

            pagingModel.totalPages = totalPages;
            pagingModel.firstPage = firstPage;
            pagingModel.lastPage = lastPage;
            pagingModel.prevPage = prevPage;
            pagingModel.nextPage = nextPage;
            pagingModel.currentPage = page;
            pagingModel.totalRows = modelList.Count();
            pagingModel.Data = entries;


            return pagingModel;
        }

        public Post InsertPost(Post post)
        {
            _postRepo.Insert(post);
            _postRepo.SaveChanges();
            return post;
        }
    }
}
