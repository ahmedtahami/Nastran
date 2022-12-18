using Microsoft.AspNetCore.Mvc;
using Nastran.DataService.Repositories;
using Nastran.Web.Models;
using Newtonsoft.Json;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly SubCategoryRepository _repository;
        public SubCategoryController(SubCategoryRepository repository)
        {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            return View(new List<Nastran.DataService.DbEntities.SubCategory>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddSubCategory");
        }
        [HttpPost]
        public IActionResult Create(Areas.Admin.Models.AddSubCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            return Ok(_repository.Add(new DataService.DbEntities.SubCategory
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
                isActive = true,
                LastModifiedBy = User.Identity.Name,
                LastModifiededAt = DateTime.Now,
            }));
        }
    }
}
