using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                    //context.AddRange(ProductCategories);//burada da altta da tanımlayabiliriz fark etmez
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }
            }
            context.SaveChanges();
        }

        private static Category[] Categories =
        {
            new Category(){Name="Telefon",Url="telefon"},//beyaz-esya
            new Category(){Name="Bilgisayar",Url="bilgisayar"},
            new Category(){Name="Elektronik",Url="elektronik"},
            new Category(){Name="Beyaz Eşya",Url="beyaz-esya"}
        };

        private static Product[] Products =
        {
            new Product(){Name="Samsun S5",Url="samsung-s5",Description="İyi telefon1",Price=2000,ImageUrl="1.jpg",IsApproved=true,IsHome=true},
            new Product(){Name="Samsun S6",Url="samsung-s6",Description="İyi telefon2",Price=3500,ImageUrl="2.jpg",IsApproved=true},
            new Product(){Name="Samsun S7",Url="samsung-s7",Description="İyi telefon3",Price=4000,ImageUrl="3.jpg",IsApproved=true},
            new Product(){Name="Samsun S8",Url="samsung-s8",Description="İyi telefon4",Price=5500,ImageUrl="4.jpg",IsApproved=true,IsHome=true},
            new Product(){Name="Samsun S9",Url="samsung-s9",Description="İyi telefon5",Price=6750,ImageUrl="5.jpg",IsApproved=true,IsHome=true},
            new Product(){Name="Asus Laptop",Url="asus-laptop",Description="İyi laptop1",Price=11150,ImageUrl="5.jpg",IsApproved=true,IsHome=true},
            new Product(){Name="Asus Bilgisayar",Url="asus-bilgisayar",Description="İyi Bilgisayar",Price=9150,ImageUrl="4.jpg",IsApproved=true,IsHome=true},
        };

        private static ProductCategory[] ProductCategories ={
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[1],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[2]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[2],Category=Categories[2]},
            new ProductCategory(){Product=Products[3],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[2]},
            new ProductCategory(){Product=Products[4],Category=Categories[0]},
            new ProductCategory(){Product=Products[4],Category=Categories[2]},
            new ProductCategory(){Product=Products[5],Category=Categories[1]},
            new ProductCategory(){Product=Products[5],Category=Categories[2]},
            new ProductCategory(){Product=Products[6],Category=Categories[1]},
            new ProductCategory(){Product=Products[6],Category=Categories[2]},
        };
    }
}