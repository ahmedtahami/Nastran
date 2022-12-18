using Microsoft.AspNetCore.Mvc;
using Nastran.DataService.Repositories;
using Nastran.Web.Models;
using Newtonsoft.Json;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;
        public CategoryController(CategoryRepository repository)
        {
            this._repository = repository;
        }
        public IActionResult Index()
        {
            return View(new List<DataService.DbEntities.Category>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddCategory");
        }
        [HttpPost]
        public IActionResult Create(Admin.Models.AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            return Ok(_repository.Add(new DataService.DbEntities.Category
            {
                Id = model.Id,
                Name = model.Name,
                Description= model.Description,
                isActive = true,
                LastModifiedBy = User.Identity.Name,
                LastModifiededAt = DateTime.Now,
            }));
        }
    }
}