﻿using System;
using System.Collections.Generic;
using TeduShop.Model.Model;

namespace TeduShop.Service.PostService
{
    public interface IPostService 
    { 
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int page, int pageSize , out int totalRow);
        Post GetById(int id);
        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
}
