using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                                .Where(i => i.ProductId == id)
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i => i.IsApproved).AsQueryable();
                //onaylı olan ürünleri saymazsa sayfa sayısı hatalı olur
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.Url == category.ToLower()));
                }

                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(p => p.IsApproved && p.IsHome).ToList();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        // public Product GetProductDetails(int id)
        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                                .Where(i => i.Url.ToLower() == url.ToLower())
                                .Include(i => i.ProductCategories)
                                .ThenInclude(c => c.Category)
                                .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.Where(i => i.IsApproved).AsQueryable();//veritabanına göndermeden önce ben üzerine sorgu yazıyorum demek gibi

                if (!string.IsNullOrEmpty(name))
                {
                    products = products
                                .Include(i => i.ProductCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.ProductCategories.Any(a => a.Category.Url == name.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();//skipte kaç ürün öteleneceği take de kaç ürün alınacağı belirlenir (mantık basit)
            }
        }

        public List<Product> GetSearchResult(string searchString)
        {
            using (var context = new ShopContext())
            {
                return context.Products.Where(p => p.IsApproved && (p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower()))).ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product product, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                var entity = context.Products
                                    .Include(i => i.ProductCategories)
                                    .FirstOrDefault(i => i.ProductId == product.ProductId);
                if (entity != null)
                {
                    entity.Name = product.Name;
                    entity.Price = product.Price;
                    entity.Description = product.Description;
                    entity.Url = product.Url;
                    entity.ImageUrl = product.ImageUrl;

                    entity.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = product.ProductId,
                        CategoryId = catid
                    }).ToList();

                    context.SaveChanges();
                }

            }
        }
    }
}