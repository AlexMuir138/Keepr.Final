using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _prepo;
    private readonly AccountsRepository _arepo;

    public ProfilesService(ProfilesRepository prepo, AccountsRepository arepo)
    {
      _prepo = prepo;
      _arepo = arepo;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _arepo.GetById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }
  }
}