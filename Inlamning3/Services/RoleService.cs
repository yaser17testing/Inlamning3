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

internal class RoleService
{

    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }




    public RoleEntity CreateRole(string roleName)
    {

        var roleEntity = _roleRepository.GetOne(x => x.RoleName == roleName);
        roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });

        return roleEntity;



    }



    public RoleEntity GetRoleByName(string Rolename)
    {

        var roleGet = _roleRepository.GetOne(x => x.RoleName == Rolename);

        if (roleGet != null)
        {

            return roleGet;


        }
        else
        {


            return null!;

        }


    }


    public RoleEntity GetRoleById(int id)
    {

        var roleGet = _roleRepository.GetOne(x => x.Id == id);

        if (roleGet != null)
        {

            return roleGet;


        }
        else
        {


            return null!;

        }




    }



    public IEnumerable<RoleEntity> GetAllRoles()
    {

        var allRoles = _roleRepository.GetAll();


        return allRoles;



    }




    public RoleEntity updateRole(RoleEntity roleEntity)
    {

        try
        {


          








                var updatedEntity = _roleRepository.Update(x => x.Id == roleEntity.Id,roleEntity);

                if (updatedEntity != null)
                {
                    return updatedEntity;
                }


            
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }
        return null!;
    }











    public bool DeleteRole(RoleEntity RoleName)
    {


        try
        {


            if (_roleRepository.Exists(x => x.Id == RoleName.Id))
            {
                var deleteRole = _roleRepository.Delete(x => x.Id == RoleName.Id);






                return deleteRole;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR  :: " + ex.Message); }

        return false;


    }



























}








