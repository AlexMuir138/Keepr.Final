using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  public class VaultKeepsController :ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeepAsync([FromBody] VaultKeep vkData)
    {
      try
      {
          Account account = await HttpContext.GetUserInfoAsync<Account>();
          vkData.CreatorId = account.Id;
          return Ok(_vks.CreateVaultKeep(vkData, account.Id));
        
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteAsync(int id)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
          _vks.Delete(id, account.Id);
          return Ok("She gone bruh");
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

  }
}
