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

    public KeepsService(KeepsRepository prepo, VaultKeepsRepository vkreop)
    {
      _krepo = prepo;
      _vkreop = vkreop;
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
        og.Name = newKeep.Name != null ? newKeep.Name : og.Name;
        og.Description = newKeep.Description != null ? newKeep.Description : og.Description;
        og.Img = newKeep.Img != null ? newKeep.Img : og.Img;

        if (_krepo.Update(newKeep) > 0)
        {
          return newKeep;
        }
        throw new Exception("Your SQL is Rabid");

      }
      throw new Exception("You ain't the owner");
    }
    internal string Delete(int id, string userId)
    {
       Keep keep = GetById(id);
      if (keep?.CreatorId == userId)
      {
        if (_krepo.Delete(id) > 0)
        {
          return "You just lost what you kept";
        }
        return "Bad Id";
      }
      return "You ain't the owner";
    }

    internal List<VaultKeep> GetKeepsByVaultId(int id)
    {
      return _krepo.GetKeepsByVaultId(id);
    }

    
  }
}




