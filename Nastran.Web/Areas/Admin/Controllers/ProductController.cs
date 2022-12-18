using Microsoft.AspNetCore.Mvc;
using Nastran.DataService.Repositories;
using Nastran.Web.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using System.IO;

namespace Nastran.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageRepository _imageRepository;
        public ProductController(ProductRepository repository, ProductImageRepository productImageRepository)
        {
            this._repository = repository;
            this._imageRepository = productImageRepository;
        }
        public IActionResult Index()
        {
            return View(new List<Nastran.DataService.DbEntities.Product>());
        }
        public IActionResult Create()
        {
            return PartialView("_AddProduct");
        }
        [HttpPost]
        public IActionResult Create(Areas.Admin.Models.AddProdcutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(JsonConvert.SerializeObject(ValidationError.GetModelStateErrors(ModelState)));
            }
            var product = _repository.Add(new DataService.DbEntities.Product
            {
                Id = model.Id,
                SubCategoryId = model.SubCategoryId,
                Name = model.Name,
                Description = model.Description,
                isActive = true,
                LastModifiedBy = User.Identity.Name,
                LastModifiededAt = DateTime.Now
            });
            foreach (var item in model.ImagePaths)
            {
                var bytes = System.IO.File.ReadAllBytes(item);
                _imageRepository.Add(new DataService.DbEntities.ProductImage
                {
                    Image = bytes,
                    Description = model.Description,
                    Name = $"{model.Name} + Image + {Guid.NewGuid}",
                    isActive = true,
                    LastModifiedBy = User.Identity.Name,
                    LastModifiededAt = DateTime.Now
                });
            }
            return Ok(product);
        }
    }
}
