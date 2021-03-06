﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.ProductCategoryService
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory category);
        void Update(ProductCategory category);
		ProductCategory Delete(int id);
        IEnumerable<ProductCategory> GetAll();
		IEnumerable<ProductCategory> GetAll(string keyword);
		IEnumerable<ProductCategory> GetAllbyParentID(int parentId);
        ProductCategory GetById(int id);
        void SaveChange();
    }
}
