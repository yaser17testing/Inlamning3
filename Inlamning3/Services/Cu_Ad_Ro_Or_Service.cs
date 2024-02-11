using Inlamning3.Entites;
using Inlamning3.Repository;
using Inlamning3.Services.DtoModells;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3.Services;

internal class Cu_Ad_Ro_Or_Service(CustomerRepository customerRepository, AdressRepository adressRepository, OrderRepository orderRepository, RoleRepository roleRepository)
{

    private readonly CustomerRepository _customerRepository = customerRepository;

    private readonly AdressRepository _adressRepository = adressRepository;


    private readonly OrderRepository _orderRepository = orderRepository;

    private readonly RoleRepository _roleRepository = roleRepository;





    public bool CreateCustomer(CustomerDto user)
    {


        try
        {




            var roles = _roleRepository.GetOne(x => x.RoleName == user.RoleName);
            roles ??= _roleRepository.Create(new RoleEntity { RoleName = user.RoleName });

            var adresses = _adressRepository.GetOne(x => x.StreetName == user.StreetName && x.City == user.City && x.PostalCode == user.PostalCode);
            adresses??=_adressRepository.Create(new AdressEntity { StreetName = user.StreetName , City = user.City ,PostalCode = user.PostalCode });



            var customerEntity = new CustomerEntity
            {




                FirstName = user.FirstName,


                LastName = user.LastName,

                Email = user.Email,

                RoleId = roles.Id,

                AddressId = adresses.Id,



            };

            var result = _customerRepository.Create(customerEntity);
            if (result != null)



                return true;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false;


    }


    public CustomerEntity GetCustomerID(CustomerDto product)
    {


        try
        {

            var existing = _customerRepository.GetOne(x => x.Id == product.Id);

            if (existing != null)
            {

                Debug.WriteLine($"Product found with Titel: {product.Id} - {product.FirstName} - {product.LastName} - {product.Email} - {product.OrderID} - {product.OrderID} ");

                return existing;
            }


            else
            {
                Debug.WriteLine($"No Product found with Titel: {product.Id}");
            }

        }

        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }


        return null!;




    }





    public CustomerEntity GetCustomerEmail(string email)
    {



        var getCustomerEmail = _customerRepository.GetOne(x => x.Email == email);

        if (getCustomerEmail != null)
        {



            return getCustomerEmail;

        }
        else
        {


            return null!;
        }


      


    }









    public IEnumerable<CustomerEntity> GetAllCustomer()
    {




        try
        {


            var result = _customerRepository.GetAll();







            return result;



        }
        catch (Exception ex)
        { Debug.WriteLine("ERROR :: " + ex.Message); }


        return Enumerable.Empty<CustomerEntity>();



    }



    public CustomerEntity UpdateCustomer(CustomerDto user)
    {




        try
        {


            var existingCustomer = _customerRepository.GetOne(x => x.Id == user.Id);



            if (existingCustomer != null)
            {


             









                existingCustomer.FirstName = user.FirstName;

                existingCustomer.LastName = user.LastName;

                existingCustomer.Email = user.Email;


             







                var updatedCustomer = _customerRepository.Update(existingCustomer);

                if (updatedCustomer != null)
                {
                    return updatedCustomer;
                }


            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }
        return null!;
    }


























    public bool DeleteCustomerById(int id)

    {





        if (_customerRepository.Exists(x => x.Id == id))

        {


            var deleteCustomer = _customerRepository.Delete(x => x.Id == id);


            return deleteCustomer;





        }

        else
        {
            return false;




        }



    }
























}

