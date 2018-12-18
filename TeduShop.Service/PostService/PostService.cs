using System;
using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service.PostService
{
    public class PostService : IPostService
    {
        IUnitOfWork _unitOfWork;
        IPostRepository _postRepository;

        public PostService(IUnitOfWork unitOfWork, IPostRepository postRepository)
        {
            _unitOfWork = unitOfWork;
            _postRepository = postRepository;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetAllbyTag(tag, pageIndex, pageSize, out totalRow);
            // sẽ xử lý join bảng posttag trong bài khác
        }

        public IEnumerable<Post> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, pageIndex, pageSize);
        }

        public IEnumerable<Post> GetByCategoryId(int categoryId, int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, pageIndex, pageSize, new string[] { "PostCategory" });
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
