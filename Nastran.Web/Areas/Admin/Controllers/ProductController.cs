using Microsoft.AspNetCore.Mvc;
using Nastran.Web.Models;
using Newtonsoft.Json;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Nastran.DataService.DbEntities.Product>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddProduct");
        }
        [HttpPost]
        public IActionResult Create(DataService.DbEntities.Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            return Ok("Product Created");
        }
    }
}
