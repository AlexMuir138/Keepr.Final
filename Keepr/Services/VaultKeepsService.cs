using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkrepo;
    private readonly KeepsRepository _krepo;

    public VaultKeepsService(VaultKeepsRepository vkrepo, KeepsRepository krepo)
    {
      _vkrepo = vkrepo;
      _krepo = krepo;
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
