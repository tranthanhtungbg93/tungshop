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
			postCategory.CreatedDate = DateTime.Now;
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

		public static void UpdatePost(this Post post, PostModel model)
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

		public static void AddProductCategory(this ProductCategory product, ProductCategoryModel model)
		{
			product.Alias = model.Alias;
			product.CreatedBy = model.CreatedBy;
			product.CreatedDate = DateTime.Now;
			product.Description = model.Description;
			product.DisplayOrder = model.DisplayOrder;
			product.HomeFlag = model.HomeFlag;
			product.ID = model.ID;
			product.Image = model.Image;
			product.MetaDescription = model.MetaDescription;
			product.MetaKeyWord = model.MetaKeyWord;
			product.Name = model.Name;
			product.ParentID = model.ParentID;
			product.Status = model.Status;
			product.UpdatedBy = model.UpdatedBy;
			product.UpdatedDate = model.UpdatedDate;
		}

		public static void UpdateProductCategory(this ProductCategory product, ProductCategoryModel model)
		{
			product.Alias = model.Alias;
			product.CreatedBy = model.CreatedBy;
			product.CreatedDate = model.CreatedDate;
			product.Description = model.Description;
			product.DisplayOrder = model.DisplayOrder;
			product.HomeFlag = model.HomeFlag;
			product.ID = model.ID;
			product.Image = model.Image;
			product.MetaDescription = model.MetaDescription;
			product.MetaKeyWord = model.MetaKeyWord;
			product.Name = model.Name;
			product.ParentID = model.ParentID;
			product.Status = model.Status;
			product.UpdatedBy = model.UpdatedBy;
			product.UpdatedDate = DateTime.Now;

		}

		public static void AddProduct(this Product product, ProductModel model)
		{
			product.Alias = model.Alias;
			product.CateforyID = model.CateforyID;
			product.Content = model.Content;
			product.CreatedBy = model.CreatedBy;
			product.CreatedDate = DateTime.Now;
			product.Description = model.Description;
			product.HomeFlag = model.HomeFlag;
			product.HotFlag = model.HotFlag;
			product.ID = model.ID;
			product.Image = model.Image;
			product.MetaDescription = model.MetaDescription;
			product.MetaKeyWord = model.MetaKeyWord;
			product.MoreImages = model.MoreImages;
			product.Name = model.Name;
			product.Price = model.Price;
			product.PromotionPrice = model.PromotionPrice;
			product.UpdatedBy = model.UpdatedBy;
			product.UpdatedDate = model.UpdatedDate;
			product.ViewCount = model.ViewCount;
			product.Warranty = model.Warranty;
			product.Tags = model.Tags;
			product.Status = model.Status;
			product.Quantity = model.Quantity;
		}

		public static void UpdateProduct(this Product product, ProductModel model)
		{
			product.Alias = model.Alias;
			product.CateforyID = model.CateforyID;
			product.Content = model.Content;
			product.CreatedBy = model.CreatedBy;
			product.CreatedDate = model.CreatedDate;
			product.Description = model.Description;
			product.HomeFlag = model.HomeFlag;
			product.HotFlag = model.HotFlag;
			product.ID = model.ID;
			product.Image = model.Image;
			product.MetaDescription = model.MetaDescription;
			product.MetaKeyWord = model.MetaKeyWord;
			product.MoreImages = model.MoreImages;
			product.Name = model.Name;
			product.Price = model.Price;
			product.PromotionPrice = model.PromotionPrice;
			product.UpdatedBy = model.UpdatedBy;
			product.UpdatedDate = DateTime.Now;
			product.ViewCount = model.ViewCount;
			product.Warranty = model.Warranty;
			product.Tags = model.Tags;
			product.Status = model.Status;
			product.Quantity = model.Quantity;
		}
	}
}