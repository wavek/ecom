using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(Product product)
        {
            //iş kuralları

            _productRepository.Create(product);
        }

        public void Delete(Product product)
        {
            //iş kuralları

            _productRepository.Delete(product);
        }

        public List<Product> GetAll()
        {
            //iş kuralları

            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            //iş kuralları

            return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
            return _productRepository.GetHomePageProducts();
        }

        // public Product GetProductDetails(int id)
        public Product GetProductDetails(string url)
        {
            return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategory(name, page, pageSize);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product product)
        {
            //iş kuralları

            _productRepository.Update(product);
        }

        public void Update(Product product, int[] categoryIds)
        {
            _productRepository.Update(product, categoryIds);
        }
    }
}