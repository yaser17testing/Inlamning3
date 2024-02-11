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




    public void GetCustomer()
    {



        Console.WriteLine("Enter Customer ID");
        int artikel =int.Parse(Console.ReadLine()!);

        var resultGet = _cu_Ad_Ro_Or_Service.GetCustomerID(artikel!);

        if (resultGet != null)
        {





            Console.WriteLine($"user found with Artikel: {resultGet.Id} - {resultGet.FirstName} - {resultGet.LastName} - {resultGet.Email} - {resultGet.Role.RoleName} - {resultGet.Address.StreetName} - {resultGet.Address.City} - {resultGet.Address.PostalCode} ");

            Console.WriteLine("Orders:");
            foreach (var order in resultGet.Orders)
            {
                Console.WriteLine($"- Order ID: {order.OrderID}");
                Console.WriteLine($"  OrderDetails: {order.OrderDetails}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"No user found with Artikel: {artikel}");
        }
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

        Console.WriteLine("FirstName");

        var firstNam = Console.ReadLine();

        Console.WriteLine("lastName");

        var lastNam = Console.ReadLine();

        Console.WriteLine("RoleName");

        var roleName = Console.ReadLine();


        Console.WriteLine("Email");

        var mail = Console.ReadLine();

        Console.WriteLine("Street");

        var street = Console.ReadLine();

        Console.WriteLine("City");

        var city = Console.ReadLine();

        Console.WriteLine("postal");

        var postal = Console.ReadLine();

        var sucess = _cu_Ad_Ro_Or_Service.CreateCustomer(new CustomerDto { FirstName = firstNam!, LastName = lastNam!,RoleName = roleName!, Email = mail!, StreetName = street!,  City = city!, PostalCode = postal!, });

       


    }









    public bool CreateProduct()
    {



        Console.WriteLine("Creating new Product. Enter Title,");
        var title = Console.ReadLine();
        Console.WriteLine("Enter price");
        var price = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Description");
        var description = Console.ReadLine();
        Console.WriteLine("Enter Category");
        var category = Console.ReadLine();

        var sucess = _categoryAndProductService.CreateProduct(new ProductDto { Title = title!, Price = price, Description = description!, CategoryName = category! });


        if (sucess)
        {
           


            return sucess;

        }


        else { return false; }
    }



    public void GetAllCustomers()
    {
        Console.Clear();
        var result = _cu_Ad_Ro_Or_Service.GetAllCustomer();

        foreach (var item in result)
        {


            Console.WriteLine($" {item.Id} - {item.FirstName} - {item.LastName} - {item.Email} - {item.Role.RoleName} - {item.Address.StreetName} - {item.Address.City} - {item.Address.PostalCode} ");

            Console.WriteLine("Orders:");
            foreach (var order in item.Orders)
            {
                Console.WriteLine($"- Order ID: {order.OrderID}");
                Console.WriteLine($"  OrderDetails: {order.OrderDetails}");
                Console.WriteLine();
            }

        }

    }



        public void GetAllProducts()
        {
            Console.Clear();
            var result = _categoryAndProductService.GetAll();

            foreach (var item in result)
            {


                Console.WriteLine($" {item.ArtikelID} - {item.Title} - {item.Description} - {item.Price} - {item.Category.CategoryName} ");



        }




    }



    public void DeleteProduct()
    {

        Console.WriteLine("Enter ArtikelID to delete");



        var sucess = _categoryAndProductService.DeleteProduct(new ProductDto { ArtikelID = int.Parse( Console.ReadLine()!) });


        if (sucess)
        {
            Console.WriteLine("Succed");


        }


    }



    public void DeleteCustomer()
    {

        Console.WriteLine("Enter CustomerID to delete");

        var customId = int.Parse( Console.ReadLine()!);

        var sucess = _cu_Ad_Ro_Or_Service.DeleteCustomerById(customId);


        if (sucess)
        {
            Console.WriteLine("Succed");


        }


    }






    public void DataBaseApp()
    {







    }
























}

