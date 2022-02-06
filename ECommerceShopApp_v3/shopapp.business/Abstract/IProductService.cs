using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        // Product GetProductDetails(int id);
        Product GetProductDetails(string url);
        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        List<Product> GetHomePageProducts();
        List<Product> GetSearchResult(string searchString);
        Product GetByIdWithCategories(int id);
        void Update(Product product, int[] categoryIds);
    }
}