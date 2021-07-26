using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _prepo;
    private readonly VaultKeepsRepository _vkreop;

    public KeepsService(KeepsRepository prepo, VaultKeepsRepository vkreop)
    {
      _prepo = prepo;
      _vkreop = vkreop;
    }

    internal Keep Create(Keep newKeep)
    {
      newKeep.Id = _prepo.Create(newKeep);
      return newKeep;
    }

    internal List<Keep> GetAll()
    {
      return _prepo.GetAll();
    }

    public Keep GetById(int id)
    {
       Keep keep = _prepo.GetById(id);
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

        if (_prepo.Update(newKeep) > 0)
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
        if (_prepo.Delete(id) > 0)
        {
          return "You just lost what you kept";
        }
        return "Bad Id";
      }
      return "You ain't the owner";
    }

    // come back to this vvv
  //  public List<VaultKeep> GetKeepsByVaultId(int id)
  //   {
  //     return _vkreop.GetKeepsByVaultId(id);
  //   }

  }
}




