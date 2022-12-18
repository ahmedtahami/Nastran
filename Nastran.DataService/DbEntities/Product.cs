using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastran.DataService.DbEntities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiededAt { get; set; }
    }
}
