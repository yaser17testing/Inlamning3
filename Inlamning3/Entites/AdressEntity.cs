
using System.ComponentModel.DataAnnotations;

namespace Inlamning3.Entites;

public class AdressEntity
{

    [Key]
    public int Id { get; set; }

    [Required]
    public string StreetName { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;

    public virtual ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();







}

