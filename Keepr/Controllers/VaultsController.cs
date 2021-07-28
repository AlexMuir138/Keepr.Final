using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Keepr.Models.Keep;

namespace Keepr.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    private readonly KeepsService _ks;

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
    async public Task<ActionResult<Vault>> GetById(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          Vault vault = _vs.GetById(id);
          if(vault.IsPrivate != true )
          {
            return vault;
          }
          else if (userInfo.Id == vault.CreatorId)
          {
              return vault;
          }
          throw new System.Exception("Invalid!");
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
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newVault.CreatorId = userInfo.Id;
        Vault created = _vs.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
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
    [HttpGet("{id}/keeps")] 
    public async Task<ActionResult<IEnumerable<VaultKeepViewModel>>> GetKeepsByVaultId(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ks.GetKeepsByVaultId(id, userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}