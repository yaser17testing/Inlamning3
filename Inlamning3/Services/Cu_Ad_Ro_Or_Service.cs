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

internal class Cu_Ad_Ro_Or_Service(CustomerRepository customerRepository, AdressRepository adressRepository, OrderRepository orderRepository, RoleRepository roleRepository,OrderService orderService)
{

    private readonly CustomerRepository _customerRepository = customerRepository;

    private readonly AdressRepository _adressRepository = adressRepository;


    private readonly OrderRepository _orderRepository = orderRepository;

    private readonly RoleRepository _roleRepository = roleRepository;

    private readonly OrderService _orderService = orderService;



    public bool CreateCustomer(CustomerDto user)
    {


        try
        {

           


            var roles = _roleRepository.GetOne(x => x.RoleName == user.RoleName);
            roles ??= _roleRepository.Create(new RoleEntity { RoleName = user.RoleName });

            var adresses = _adressRepository.GetOne(x => x.StreetName == user.StreetName && x.City == user.City && x.PostalCode == user.PostalCode);
            adresses ??= _adressRepository.Create(new AdressEntity { StreetName = user.StreetName, City = user.City, PostalCode = user.PostalCode });



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

            {

                var newOrder = new OrderEntity
                {
                    CustomerID = result.Id,
                    OrderDetails = "in progress1",
                };

                
                _orderRepository.Create(newOrder);



                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false;


    }


    public CustomerEntity GetCustomerID(int product)
    {


        try
        {

            var existing = _customerRepository.GetOne(x => x.Id == product);

            if (existing != null)
            {

                

                return existing;
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



    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {




        try
        {


            //var existingCustomer = _customerRepository.GetOne(x => x.Id == user.Id);










            var updatedCustomer = _customerRepository.Update(x => x.Id == customerEntity.Id,customerEntity);

                if (updatedCustomer != null)
                {
                    return updatedCustomer;
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

