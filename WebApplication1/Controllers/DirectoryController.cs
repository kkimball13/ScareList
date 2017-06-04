using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class DirectoryController : Controller
    {
        // GET: Directory

            [Route("directory")]
        public ActionResult Directory()
        {
            ItemViewModel<int?> vm = new ItemViewModel<int?>();
            //vm.Item = 
            return View();
        }

        public ActionResult AddHaunt()
        {
            return View();
        }

        public ActionResult TestStuff()
        {
            return View();
        }

        public ActionResult TestStuff2()
        {
            return View();
        }
    }
}