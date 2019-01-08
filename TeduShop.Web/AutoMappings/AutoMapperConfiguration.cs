using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeduShop.Model.Model;
using TeduShop.Web.Models;

namespace TeduShop.Web.AutoMappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post,PostModel>();
            Mapper.CreateMap<PostCategory, PostCategoryModel>();
            Mapper.CreateMap<Tag, TagModel>();
            Mapper.CreateMap<PostTag, PostTagModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryModel>();
            Mapper.CreateMap<Product, ProductModel>();
			Mapper.CreateMap<Footer, FooterModel>();
			Mapper.CreateMap<Slide, SlideModel>();
		}
    }
}