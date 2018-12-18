﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.PostCategoryService
{
    public interface IPostCategoryService : IDisposable
    {
        PostCategory Add(PostCategory category);
        PostCategory Update(PostCategory category);
        void Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllbyParentID(int parentId);
        PostCategory GetById(int id);
        void SaveChange();
    }
}