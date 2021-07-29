using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;
    private readonly KeepsRepository _krepo;
    private readonly VaultsRepository _vrepo;

    public VaultKeepsService(VaultKeepsRepository vkrepo, KeepsRepository krepo, VaultsRepository vrepo)
    {
      _vkrepo = vkrepo;
      _krepo = krepo;
      _vrepo = vrepo;
    }

    public VaultKeep CreateVaultKeep(VaultKeep vkData, string userId)
    {

      VaultKeep vaultKeep = _vkrepo.CreateVaultKeep(vkData);
      vkData.Id = vaultKeep.Id;
      Vault vault = _vrepo.GetById(vkData.VaultId);
      if(vault.CreatorId != userId)
      {
        throw new Exception("Nope. Ain't the owner");

      }
      return vkData;
    }
    internal void Delete(int id, string userId)
    {
       VaultKeep vaultKeep = GetById(id);
      if (vaultKeep.CreatorId != userId)
      {
        throw new Exception("You're an Invalid");
      }
        _vkrepo.Delete(id);
    }

    public VaultKeep GetById(int id)
    {
       VaultKeep vaultKeep = _vkrepo.GetById(id);
       if(vaultKeep == null)
       {
         throw new Exception("Invalid!");
       }
       return vaultKeep;
  
    }
  }
}
