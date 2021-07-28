using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly KeepsService _ks;
    private readonly VaultsService _vs;

    public ProfilesController(ProfilesService ps, KeepsService ks, VaultsService vs)
    {
      _ps = ps;
      _ks = ks;
      _vs = vs;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _ps.GetProfileById(id);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public async  Task<ActionResult<List<Keep>>> GetKeepsByProfileId(string id)
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      try
      {
          List<Keep> keeps = _ks.GetKeepsByProfileId(id, userInfo);
          return Ok(keeps);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/vaults")]
    public async  Task<ActionResult<List<Keep>>> GetVaultsByProfileId(string id)
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      try
      {
          List<Vault> vaults = _vs.GetVaultsByProfileId(id, userInfo);
          return Ok(vaults);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}