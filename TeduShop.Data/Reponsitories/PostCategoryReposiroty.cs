﻿using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface IPostCategoryReposiroty
    {
    }
    public class PostCategoryReposiroty : ReponsitoryBase<PostCategory>, IPostCategoryReposiroty
    {
        public PostCategoryReposiroty(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}