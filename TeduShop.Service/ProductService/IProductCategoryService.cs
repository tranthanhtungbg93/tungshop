using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductService
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory category);
        void Update(ProductCategory category);
        void Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllbyParentID(int parentId);
        ProductCategory GetById(int id);
        void SaveChange();
    }
}
