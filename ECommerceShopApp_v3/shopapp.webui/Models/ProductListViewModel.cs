using System;
using System.Collections.Generic;
// using shopapp.webui.Models;
using shopapp.entity;


namespace shopapp.webui.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        // public Category Category { get; set; }
        // public List<Category> Categories { get; set; }
        public PageInfo PageInfo { get; set; }

    }

    public class PageInfo
    {
        public int TotalItems { get; set; }//toplam ürün adedi
        public int ItemsPerPage { get; set; }//sayfa başına kaç ürün gösterilecek
        public int CurrentPage { get; set; }//şu anki sayfa
        public string CurrentCategory { get; set; }//kategori seçimi varsa varsa hangi kategori
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); //mesela 10 ürün var sayfa başına 3 ürün gösterilecek 3.3 oluyor sondaki 1 ürün için ayrı sayfa oluşturabilecek bir yuvarlama işlemi yapıyoruz.
        }
    }
}