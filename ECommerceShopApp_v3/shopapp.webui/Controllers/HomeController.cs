using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;

// using shopapp.webui.Models;
using shopapp.entity;
// using shopapp.webui.ViewModels;
using shopapp.webui.Models;


namespace shopapp.webui.Controllers
{
    public class HomeController : Controller
    {
        // private IProductRepository _productRepository;
        //startup-ConfigureServices metodunun içine addscope yaptık
        private IProductService _productService;

        // public HomeController(IProductRepository productRepository)
        // {
        //     this._productRepository = productRepository;
        // }

        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {

            return View(GetProductAndCategory());
        }

        private ProductListViewModel GetProductAndCategory()
        {

            var productListViewModel = new ProductListViewModel()
            {

                // Products = ProductRepository.Products
                // Products = _productRepository.GetAll()
                // Products = _productService.GetAll()
                Products = _productService.GetHomePageProducts()//hata verdi çünkü veritabanında değişiklik yaptık(IsHome keledik Product entititsine)  bu yüzden migrationda belirtmezsek hata alırız.

            };


            return productListViewModel;
        }

        public IActionResult About()
        {
            return View();
        }


        //localhost:5000/home/about
        // public string About()
        // {
        //     return "home/about";
        // }


        public IActionResult Contact()
        {
            return View("MyView");//myview.cshtml için
        }
    }
}