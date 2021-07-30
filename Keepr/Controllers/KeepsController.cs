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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;

    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetAll()
    {
      try
      {
          return Ok(_ks.GetAll());
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
          Keep keep = _ks.GetById(id);
          return Ok(keep);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Keep>> Create([FromBody] Keep newKeep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newKeep.CreatorId = userInfo.Id;
        Keep created = _ks.Create(newKeep);
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
    async public Task<ActionResult<Keep>> Update(int id, [FromBody] Keep newKeep)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        newKeep.Id = id;
        newKeep.CreatorId = account.Id;
        return Ok(_ks.Update(id, newKeep));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("/views/{id}")]
    public ActionResult<Keep> UpdateKeep(int id, [FromBody] Keep newKeep)
    {
      try
      {
        newKeep.CreatorId = null;
        newKeep.Id = id;
        newKeep.Name = null;
        newKeep.Description = null;
        newKeep.Img = null;
        return Ok(_ks.Update(id, newKeep));
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
        return Ok(_ks.Delete(id, account.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}