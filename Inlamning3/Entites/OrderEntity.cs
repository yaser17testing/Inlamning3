using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Entites
{
    public class OrderEntity
    {
        [Key]
        public int OrderID { get; set; }

public string OrderDetails { get; set; } = null!;

        [ForeignKey("CustomerEntity")]
        public int CustomerID { get; set; }


        public virtual CustomerEntity Customer { get; set; } = null!;


    }
}
