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
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          vkData.CreatorId = userInfo.Id;
          return Ok(_vks.CreateVaultKeep(vkData));
        
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
          _vks.Delete(id);
          return Ok("She gone bruh");
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

  }
}
