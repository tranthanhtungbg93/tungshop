namespace TeduShop.Data.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using TeduShop.Common;
	using TeduShop.Model.Model;

	internal sealed class Configuration : DbMigrationsConfiguration<TeduShop.Data.TeduShopDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(TeduShop.Data.TeduShopDbContext context)
		{
			//var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));

			//var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));

			//var user = new ApplicationUser()
			//{
			//    UserName = "tungconbg93",
			//    Email = "tranthanhtung.cd2.21@gmail.com",
			//    EmailConfirmed = true,
			//    Birthday = DateTime.Today,
			//    FullName = "Tran Thanh Tung"
			//};

			//manager.Create(user, "Tung@123");
			//// check role chua ton tai
			//if (!roleManager.Roles.Any())
			//{
			//    roleManager.Create(new IdentityRole { Name = "Admin" });
			//    roleManager.Create(new IdentityRole { Name = "User" });
			//}

			//var adminUser = manager.FindByEmail("tranthanhtung.cd2.21@gmail.com");

			//manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
			AddProductCategory(context);
			AddProduct(context);
			ContentSlides(context);
			CreatePages(context);
		}

		public void AddProductCategory(TeduShop.Data.TeduShopDbContext context)
		{
			if (context.ProductCategories.Count() == 0)
			{
				List<ProductCategory> list = new List<ProductCategory>() {
				new ProductCategory()
				{
					Name = "Laptop",
					Alias="abc",
					Status=true
				},
				new ProductCategory()
				{
					Name = "Ram",
					Alias="abc",
					Status=true
				},
				new ProductCategory()
				{
					Name = "Card man hinh",
					Alias="abc",
					Status=true
				},
				new ProductCategory()
				{
					Name = "G-shock",
					Alias="abc",
					Status=true
				},
				new ProductCategory()
				{
					Name = "My tom tre con",
					Alias="abc",
					Status=true
				},
				new ProductCategory()
				{
					Name = "Iphone XXX",
					Alias="abc",
					Status=true
				},
			};
				context.ProductCategories.AddRange(list);
				context.SaveChanges();
			}
		}
		public void AddProduct(TeduShop.Data.TeduShopDbContext context)
		{
			if (context.Products.Count() == 0)
			{
				List<Product> list = new List<Product>() {
				new Product()
				{
					Name = "Laptop",
					Alias="abc",
					Status=true
				},
				new Product()
				{
					Name = "Ram",
					Alias="abc",
					Status=true
				},
				new Product()
				{
					Name = "Card man hinh",
					Alias="abc",
					Status=true
				},
				new Product()
				{
					Name = "G-shock",
					Alias="abc",
					Status=true
				},
				new Product()
				{
					Name = "My tom tre con",
					Alias="abc",
					Status=true
				},
				new Product()
				{
					Name = "Iphone XXX",
					Alias="abc",
					Status=true
				},
			};
				context.Products.AddRange(list);
				context.SaveChanges();
			}
		}
		private void ContentFooter(TeduShopDbContext context)
		{
			if (context.Footers.Count(x => x.ID == CommonConstant.DefaultFooterID) == 0)
			{
				string content;
			}
		}

		private void ContentSlides(TeduShopDbContext context)
		{
			if (context.Slides.Count() == 0)
			{
				List<Slide> lstSlide = new List<Slide>() {
					new Slide()
					{
						Name="Slide 1",
						DisplayOrder = 1,
						Status = true,
						URL = "#",
						Image = "/Assets/Client/images/bag.jpg",
						Description = @"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
								<span class=""on-get"">GET NOW</span>"
					},
					new Slide()
					{
						Name="Slide 2",
						DisplayOrder = 2,
						Status = true,
						URL = "#",
						Image = "/Assets/Client/images/bag.jpg",
						Description = @"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
								<span class=""on-get"">GET NOW</span>"
					},
					new Slide()
					{
						Name="Slide 3",
						DisplayOrder = 3,
						Status = true,
						URL = "#",
						Image = "/Assets/Client/images/bag1.jpg",
						Description = @"<h2>FLAT 50% 0FF</h2>
								<label>FOR ALL PURCHASE <b>VALUE</b></label>
								<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
								<span class=""on-get"">GET NOW</span>"
					}
				};
				context.Slides.AddRange(lstSlide);
				context.SaveChanges();
			}
		}

		private void CreatePages(TeduShopDbContext context)
		{
			if(context.Pages.Count() == 0)
			{
				var page = new Page()
				{
					Alias= "gioi-thieu",
					Content = "HP 280 G3 SFF là sự cân đối hài hòa giữa hiệu năng, chất lượng và giá thành đối với một máy tính để bàn dành cho doanh nghiệp. Được thiết kế để đáp ứng tối đa nhu cầu làm việc mỗi ngày, dòng máy tính để bàn HP 280 G3 với sức mạnh xử lý đáng kinh ngạc và cung cấp nhiều tùy chọn cấu hình đi kèm sẽ là lựa chọn mang lại hiệu quả kinh tế cho doanh nghiệp.",
					Name = "Giới thiệu trang web"
				};
				context.Pages.Add(page);
				context.SaveChanges();
			}
		}
	}
}
