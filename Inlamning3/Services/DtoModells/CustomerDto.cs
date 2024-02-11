using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Services.DtoModells;

public class CustomerDto
{


    
    public int Id { get; set; }

    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

   

    public string Email { get; set; } = null!;



    public string StreetName { get; set; } = null!;

    
    public string PostalCode { get; set; } = null!;


    public string City { get; set; } = null!;


    public string RoleName { get; set; } = null!;

    public string OrderDetails { get; set; } = null!;





}

