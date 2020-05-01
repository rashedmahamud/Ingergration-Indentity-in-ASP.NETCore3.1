using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IndentityTest2.Areas.Admin.Contollers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class AdminController : Controller
    {
        [Route("[action]/{page:int?}")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{page:int?}")]
        public IActionResult Orders()
        {
            return View();
        }
    }
}