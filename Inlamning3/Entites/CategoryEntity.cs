using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Entites
{


[Index(nameof(CategoryName), IsUnique = true)]

    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    }
}
