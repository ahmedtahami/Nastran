using Microsoft.AspNetCore.Mvc;
using Nastran.Web.Models;
using Newtonsoft.Json;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Nastran.DataService.DbEntities.SubCategory>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddSubCategory");
        }
        [HttpPost]
        public IActionResult Create(DataService.DbEntities.SubCategory model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            return Ok("SubCategory Created");
        }
    }
}
