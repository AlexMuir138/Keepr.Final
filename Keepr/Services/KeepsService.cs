using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using static Keepr.Models.Keep;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _krepo;
    private readonly VaultKeepsRepository _vkreop;
    private readonly VaultsRepository _vrepo;

    public KeepsService(KeepsRepository krepo, VaultKeepsRepository vkreop, VaultsRepository vrepo)
    {
      _krepo = krepo;
      _vkreop = vkreop;
      _vrepo = vrepo;
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _krepo.Create(newKeep);
      return newKeep;
    }

    internal List<Keep> GetAll()
    {
      return _krepo.GetAll();
    }

    public Keep GetById(int id)
    {
       Keep keep = _krepo.GetById(id);
       if( keep != null)
       {
         return keep;
       }
       throw new Exception("Object doesn't exist fool");
    }

     internal Keep Update(int id, Keep newKeep)
    {
      Keep og = GetById(id);
      if (og.CreatorId == newKeep.CreatorId)
      {
        newKeep.Name = newKeep.Name != null ? newKeep.Name : og.Name;
        newKeep.Description = newKeep.Description != null ? newKeep.Description : og.Description;
        newKeep.Img = newKeep.Img != null ? newKeep.Img : og.Img;
        newKeep.Views = newKeep.Views == (og.Views += 1)  ? newKeep.Views : og.Views;
        newKeep.Keeps = newKeep.Keeps == (og.Keeps += 1)  ? newKeep.Keeps : og.Keeps;

        if (_krepo.Update(newKeep) > 0)
        {
          return newKeep;
        }
        throw new Exception("Your SQL is Rabid");

      }
      throw new Exception("You ain't the owner");
    }

    public List<Keep> GetKeepsByProfileId(string id, Account userInfo)
    {
      var keeps = _krepo.GetKeepsByProfileId(id);
      return keeps;
    }

    internal string Delete(int id, string userId)
    {
       Keep keep = GetById(id);
      if (keep.CreatorId == userId)
      {
        if (_krepo.Delete(id) > 0)
        {
          return "You just lost what you kept";
        }
        return "Bad Id";
      }
      throw new Exception("You're an Invalid");
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, Account userInfo)
    {
      var vault = _vrepo.GetById(id);
      if(vault.IsPrivate == true)
      {
        if(vault.CreatorId == userInfo.Id)
        {
        return _krepo.GetKeepsByVaultId(id);
        }
        throw new Exception("Private");
      }
      return _krepo.GetKeepsByVaultId(id);
    }

    internal object GetKeepsByVaultId(int id)
    {
       var vault = _vrepo.GetById(id);
       if(vault.IsPrivate == true)
      {
        throw new Exception("Private");
      }
      return _krepo.GetKeepsByVaultId(id);
    }
  }
}




