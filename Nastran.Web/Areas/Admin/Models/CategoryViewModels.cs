using System.ComponentModel.DataAnnotations;

namespace Nastran.Web.Areas.Admin.Models
{
    public class AddProdcutViewModel
    {
        public long Id { get; set; }
        [Required]
        public long SubCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string[] ImagePaths { get; set; }
    }
    public class AddCategoryViewModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
    public class AddSubCategoryViewModel
    {
        public long Id { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
