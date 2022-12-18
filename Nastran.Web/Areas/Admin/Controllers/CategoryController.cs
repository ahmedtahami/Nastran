using Microsoft.AspNetCore.Mvc;
using Nastran.Web.Models;
using Newtonsoft.Json;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<DataService.DbEntities.Category>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddCategory");
        }
        [HttpPost]
        public IActionResult Create(DataService.DbEntities.Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            return Ok("Category Created");
        }
    }
}