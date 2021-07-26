using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;

    public VaultKeepsService(VaultKeepsRepository vkrepo)
    {
      _vkrepo = vkrepo;
    }

    public VaultKeep CreateVaultKeep(VaultKeep vkData)
    {
      return _vkrepo.CreateVaultKeep(vkData);
    }
    public void Delete(int id)
    {
      _vkrepo.Delete(id);
    }
  }
}
