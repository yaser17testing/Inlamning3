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

internal class AdressService
{





    private readonly AdressRepository _adressRepository;

    public AdressService(AdressRepository adressRepository)
    {
        _adressRepository = adressRepository;





    }




    public AdressEntity CreateAdress(AdressDto adress)
    {

        var adressEntity = _adressRepository.GetOne(x => x.StreetName == adress.StreetName && x.City == adress.City && x.PostalCode == adress.PostalCode);
        adressEntity ??= _adressRepository.Create(new AdressEntity { StreetName = adress.StreetName , City = adress.City , PostalCode = adress.PostalCode });

        return adressEntity;






    }




















    public AdressEntity GetAdressByStreet(AdressDto adress)
    {

        var adressGet = _adressRepository.GetOne(x => x.StreetName == adress.StreetName && x.City == adress.City && x.PostalCode == adress.PostalCode);

        if (adressGet != null)
        {

            return adressGet;


        }
        else
        {


            return null!;

        }


    }


    public AdressEntity GetAdressById(int id)
    {

        var adressGet = _adressRepository.GetOne(x => x.Id == id);

        if (adressGet != null)
        {

            return adressGet;


        }
        else
        {


            return null!;

        }




    }



    public IEnumerable<AdressEntity> GetAllRoles()
    {

        var allAdress = _adressRepository.GetAll();


        return allAdress;



    }




    public AdressEntity updateAdress(AdressEntity adress)
    {

        try
        {


            var existingAdress = _adressRepository.GetOne(x => x.Id == adress.Id);



            if (existingAdress != null)
            {




                existingAdress.StreetName = adress.StreetName;

                existingAdress.City = adress.City;

                existingAdress.PostalCode = adress.PostalCode;









                var updatedOrder = _adressRepository.Update(existingAdress);

                if (updatedOrder != null)
                {
                    return updatedOrder;
                }


            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }
        return null!;
    }











    public bool DeleteAdress(AdressEntity adress)
    {


        try
        {


            if (_adressRepository.Exists(x => x.Id == adress.Id))
            {
                var deleteOrder = _adressRepository.Delete(x => x.Id == adress.Id);






                return deleteOrder;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }

        return false;


    }




















}

