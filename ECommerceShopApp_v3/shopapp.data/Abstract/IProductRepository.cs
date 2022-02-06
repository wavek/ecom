using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        // Product GetProductDetails(int id);
        Product GetProductDetails(string url);

        List<Product> GetProductsByCategory(string name, int page, int pageSize);
        List<Product> GetPopularProducts();
        List<Product> GetTop5Products();
        List<Product> GetHomePageProducts();
        int GetCountByCategory(string category);
        List<Product> GetSearchResult(string searchString);
        Product GetByIdWithCategories(int id);
        void Update(Product product, int[] categoryIds);

    }
}