namespace TeduShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
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
		}

        public void AddProductCategory(TeduShop.Data.TeduShopDbContext context)
        {
            if(context.ProductCategories.Count() == 0)
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
		public void AddProduct(TeduShop.Data.TeduShopDbContext context){
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

	}
}
