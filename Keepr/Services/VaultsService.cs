using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vrepo;

    public VaultsService(VaultsRepository vrepo)
    {
      _vrepo = vrepo;
    }

    internal Vault Create(Vault newVault)
    {
      int id = _vrepo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    internal List<Vault> GetAll()
    {
      return _vrepo.GetAll();
    }

    public Vault GetById(int id)
    {
       Vault vault = _vrepo.GetById(id);
       if(vault == null)
       {
         throw new Exception("Invalid!");
       }
       return vault;
  
    }

     internal Vault Update(int id, Vault newVault)
    {
      Vault og = GetById(id);
      if (og.CreatorId == newVault.CreatorId)
      {
        og.Name = newVault.Name != null ? newVault.Name : og.Name;
        og.Description = newVault.Description != null ? newVault.Description : og.Description;
        og.IsPrivate = newVault.IsPrivate;

        if (_vrepo.Update(newVault) > 0)
        {
          return newVault;
        }
        throw new Exception("Your SQL is Rabid");

      }
      throw new Exception("You ain't the owner");
    }
    internal string Delete(int id, string userId)
    {
       Vault vault = GetById(id);
      if (vault.CreatorId == userId)
      {
        if (_vrepo.Delete(id) > 0)
        {
          return "You vaulted outta here";
        }
        return "Bad Id";
      }
      throw new Exception("You're an Invalid");
      
    }

    internal List<Vault> GetPublicVaults(string id)
    {
      List<Vault> profileVaults = _vrepo.GetVaultsByProfileId(id);
      List<Vault> newProfileVaults = profileVaults.Where(v => v.IsPrivate != true).ToList();
      return newProfileVaults;
    }

   

    internal object GetVaultsByProfileId(string id)
    {
      List<Vault> profileVaults = _vrepo.GetVaultsByProfileId(id);
      List<Vault> newProfileVaults = profileVaults.Where(v => v.CreatorId == id).ToList();
      return newProfileVaults;
    }
  }
}