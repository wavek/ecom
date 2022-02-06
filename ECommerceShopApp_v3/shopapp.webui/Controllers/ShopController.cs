using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
// using shopapp.webui.ViewModels;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult List(string category, int page = 1)//localhost/products/telefon?page=1 herhangi bir değer gelmezse varsayılan olarak birinci sayfaya gider
        {
            const int pageSize = 3;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };

            return View(productListViewModel);
        }

        // public IActionResult Details(int? id)
        public IActionResult Details(string urlName)//startup içindeki değişken adı urlName
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }

            if (urlName == null)
            {
                return NotFound();
            }

            // Product product = _productService.GetById((int)id);//nullable değil o yüzden int görmesi için cast ettik
            // Product product = _productService.GetProductDetails((int)id);
            Product product = _productService.GetProductDetails(urlName);



            if (product == null)
            {
                return NotFound();
            }
            // return View(product);
            return View(new ProductDetailModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });

        }

        public IActionResult Search(string filter)
        {
            var productListViewModel = new ProductListViewModel()
            {

                Products = _productService.GetSearchResult(filter)
            };

            return View(productListViewModel);
        }
    }
}