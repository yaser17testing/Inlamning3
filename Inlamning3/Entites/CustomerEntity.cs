using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Entites;
[Index(nameof(Email), IsUnique = true)]
    public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    
    public string Email { get; set; } = null!;


        [ForeignKey("RoleEntity")]
        public int? RoleId { get; set; }
       
        public virtual RoleEntity Role { get; set; } = null!;


[ForeignKey("AddressEntity")]
        public int AddressId { get; set; }

    public virtual AdressEntity Address { get; set; } = null!;

        public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();


}
