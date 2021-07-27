using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _prepo;

    public ProfilesService(ProfilesRepository prepo)
    {
      _prepo = prepo;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _prepo.GetProfileById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }
  }
}