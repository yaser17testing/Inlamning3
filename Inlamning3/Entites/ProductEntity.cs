using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Entites
{
    public class ProductEntity
    {
        [Key]
        public int ArtikelID { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;


        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("CategoryEntity")]
        public int? CategoryId { get; set; }
        
        public virtual CategoryEntity Category { get; set; } = null!;






    }
}
