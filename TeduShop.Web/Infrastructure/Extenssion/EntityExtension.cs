using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Model;
using TeduShop.Web.Models;

namespace TeduShop.Web.Infrastructure.Extenssion
{
    public static class EntityExtension
    {
        public static void UpdateCategory(this PostCategory postCategory, PostCategoryModel model)
        {
            postCategory.Alias = model.Alias;
            postCategory.CreatedBy = model.CreatedBy;
            postCategory.CreatedDate = model.CreatedDate;
            postCategory.Description = model.Description;
            postCategory.DisplayOrder = model.DisplayOrder;
            postCategory.HomeFlag = model.HomeFlag;
            postCategory.ID = model.ID;
            postCategory.Image = model.Image;
            postCategory.MetaDescription = model.MetaDescription;
            postCategory.MetaKeyWord = model.MetaKeyWord;
            postCategory.Name = model.Name;
            postCategory.ParentID = model.ParentID;
            postCategory.Status = model.Status;
            postCategory.UpdatedBy = model.UpdatedBy;
            postCategory.UpdatedDate = model.UpdatedDate;
        }

        public static void UpdatePost(this Post post , PostModel model)
        {
            post.Alias = model.Alias;
            post.CategoryID = model.CategoryID;
            post.Content = model.Content;
            post.CreatedBy = model.CreatedBy;
            post.CreatedDate = model.CreatedDate;
            post.Description = model.Description;
            post.HomeFlag = model.HomeFlag;
            post.HotFlag = model.HotFlag;
            post.ID = model.ID;
            post.Image = model.Image;
            post.MetaDescription = model.MetaDescription;
            post.MetaKeyWord = model.MetaKeyWord;
            post.Name = model.Name;
            post.Status = model.Status;
            post.UpdatedBy = model.UpdatedBy;
            post.UpdatedDate = model.UpdatedDate;
        }
    }
}