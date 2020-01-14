using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sol_Demo.Controllers
{
    public class DemoController : Controller
    {

        private List<string> ListImages()
        {
            var listObj = new List<String>();
            listObj.Add("https://cdn.pixabay.com/photo/2015/12/01/20/28/road-1072823__340.jpg");
            listObj.Add("https://images.pexels.com/photos/257360/pexels-photo-257360.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500");
            listObj.Add("https://cdn.pixabay.com/photo/2015/06/19/21/24/the-road-815297__340.jpg");

            return listObj;
        }

        public IActionResult Index()
        {
            return View(this.ListImages());
        }
    }
}