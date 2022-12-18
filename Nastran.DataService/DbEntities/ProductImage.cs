using System.ComponentModel.DataAnnotations;

namespace Nastran.DataService.DbEntities
{
    public class ProductImage
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiededAt { get; set; }
    }
}
