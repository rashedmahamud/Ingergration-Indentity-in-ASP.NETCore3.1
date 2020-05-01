using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndentityTest2.Areas.Admin.Contollers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {
        [Route("{page:int?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}