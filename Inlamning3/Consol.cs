using Inlamning3.Entites;
using Inlamning3.Services;
using Inlamning3.Services.DtoModells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3;

internal class Consol
{


   private readonly CategoryAndProductService _categoryAndProductService;
    private readonly Cu_Ad_Ro_Or_Service _cu_Ad_Ro_Or_Service;

    private readonly AdressService _adressService;
    public Consol(CategoryAndProductService categoryAndProductService, Cu_Ad_Ro_Or_Service cu_Ad_Ro_Or_Service,AdressService adressService)
    {
        _categoryAndProductService = categoryAndProductService;

        _cu_Ad_Ro_Or_Service = cu_Ad_Ro_Or_Service;

        _adressService = adressService;

    }















    public void UpdateAdress()
    {



        Console.WriteLine("Write id for customers Adress");

        int ide = int.Parse(Console.ReadLine()!);


        var adress = _adressService.GetAdressById(ide);
       


        if (adress != null)
        {
            Console.WriteLine("Write new streetName");
            adress.StreetName = Console.ReadLine()!;

            Console.WriteLine("Write new city");
            adress.City = Console.ReadLine()!;

            Console.WriteLine("Write new postalcode");
            adress.PostalCode = Console.ReadLine()!;

            var updatedAdress = _adressService.updateAdress(adress);
        }


    }















    public void UpdateCustomer()
    {



        Console.WriteLine("Write id for customer");

        var id = int.Parse(Console.ReadLine()!);



        var customer = _cu_Ad_Ro_Or_Service.GetCustomerID(id);


        if ( customer != null)
        {
            Console.WriteLine("Write new name");
            customer.FirstName = Console.ReadLine()!;

            Console.WriteLine("Write new Lastname");
            customer.LastName = Console.ReadLine()!;

            Console.WriteLine("Write new Email");
            customer.Email = Console.ReadLine()!;

            var updatedCustomer = _cu_Ad_Ro_Or_Service.UpdateCustomer(customer);
}
    }





    public void CreateCustomer()
    {

        var sucess = _cu_Ad_Ro_Or_Service.CreateCustomer(new CustomerDto { FirstName = Console.ReadLine()!, LastName = Console.ReadLine()!,RoleName = Console.ReadLine()!, Email = Console.ReadLine()!, StreetName = Console.ReadLine()!,  City = Console.ReadLine()!, PostalCode = Console.ReadLine()!, });

       


    }









    public bool CreateProduct()
    {
      
 var sucess = _categoryAndProductService.CreateProduct(new ProductDto { Title = Console.ReadLine()!, Price = Decimal.Parse(Console.ReadLine()!), Description = Console.ReadLine()!, CategoryName = Console.ReadLine()! });


        if (sucess)
        {
           


            return sucess;

        }


        else { return false; }
    }








    public void DataBaseApp()
    {







    }
























}

