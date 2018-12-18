using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryTest
    {
        IDBFactory dBFactory;
        IPostCategoryReposiroty postCategoryReposiroty;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initializa()
        {
            dBFactory = new DbFactory();
            postCategoryReposiroty = new PostCategoryReposiroty(dBFactory);
            unitOfWork = new UnitOfWork(dBFactory);
        }

        [TestMethod]
        public void PostCategoryRepository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "tessttt";
            postCategory.Alias = "Tessssss";
            postCategory.Status = true;

            var result = postCategoryReposiroty.Add(postCategory);
            unitOfWork.Commit();
        }
    }
}
