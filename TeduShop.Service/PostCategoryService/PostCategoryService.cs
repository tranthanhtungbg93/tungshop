using System;
using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service.PostCategoryService
{
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryReposiroty _postCategory;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryReposiroty postCategory, IUnitOfWork unitOfWork)
        {
            _postCategory = postCategory;
            _unitOfWork = unitOfWork;
        }

        public void Add(PostCategory category)
        {
            _postCategory.Add(category);
        }

        public void Delete(int id)
        {
            _postCategory.Delete(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategory.GetAll();
        }

        public IEnumerable<PostCategory> GetAllbyParentID(int parentId)
        {
            return _postCategory.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return _postCategory.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory category)
        {
            _postCategory.Update(category);
        }
    }
}
