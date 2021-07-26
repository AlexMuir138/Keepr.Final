using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }
    [HttpGet]
    public ActionResult<List<Vault>> GetAll()
    {
      try
      {
          return Ok(_vs.GetAll());
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
    {
      try
      {
          Vault vault = _vs.GetById(id);
          return Ok(vault);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        newVault.CreatorId = account.Id;
        return Ok(_vs.Create(newVault));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    async public Task<ActionResult<Vault>> Update(int id, [FromBody] Vault newVault)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        newVault.CreatorId = account.Id;
        newVault.Id = id;
        return Ok(_vs.Update(id, newVault));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_vs.Delete(id, account.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}