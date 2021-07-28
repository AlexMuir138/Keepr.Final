using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;
using static Keepr.Models.Keep;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps
      (name, description, img, views, shares, keeps, creatorId)
      VALUES
      (@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
      SELECT 
      LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }


    internal Keep GetById(int id)
    {
      string sql = @"
      SELECT 
      k.*, 
      a.*
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id
      WHERE k.id = @id;
      ";
      return _db.Query<Keep, Account, Keep>(sql, (k, a)=>
      {
        k.Creator = a;
        return k;
      }, new {id}).FirstOrDefault();
    }

     internal int Update(Keep update)
    {
      string sql = @"
     UPDATE keeps
      SET
     name = @Name,
     description = @Description,
     img = @Img
     WHERE id = @Id;";
      return _db.Execute(sql, update);
    }

   internal int Delete(int id)
    {
      string sql = @"
      DELETE FROM keeps
      WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }

    internal List<Keep> GetAll()
    {
      string sql = @"
      SELECT 
      k.* 
      FROM keeps k
      JOIN accounts a on k.creatorId = a.id;
      ";
      return _db.Query<Keep>(sql).ToList();
    }

  }
}
    //  internal List<VaultKeep> GetKeepsByVaultId(int id)
    // {
    //   string  sql = @"
    //   SELECT 
    //   k.*,
    //   vk.id AS vaultKeepId
    //   FROM vault_keeps vk
    //   JOIN keeps k ON vk.keepId = k.id 
    //   WHERE vaultId = @Id;
    //   ";
    //   return _db.Query<VaultKeepViewModel, VaultKeep, VaultKeepViewModel>(sql, (k, vk) =>
    //   {
    //     vk.Keep = k;
    //     return vk;
    //   }, new {id}, splitOn: "id").ToList();
     
    // }