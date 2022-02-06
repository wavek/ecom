using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;

namespace shopapp.webui.ViewComponents
{
    public class OrdersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var orders = new List<Order>(){
                new Order(){Name="Sipariş 1"},
                new Order(){Name="Sipariş 2"}
            };

            return View(orders);
        }
    }
}