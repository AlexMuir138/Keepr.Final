using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;
using static Keepr.Models.Keep;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
     private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vkData)
    {
      string sql = @"INSERT INTO vault_keeps
      (vaultId, keepId, creatorId)
      VALUES
      (@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();";


      int id = _db.ExecuteScalar<int>(sql, vkData);
      vkData.Id = id;
      return vkData;
    }

    internal void Delete(int id)
    {
      string sql = @"
      DELETE FROM vault_keeps
      WHERE id = @Id
      LIMIT 1;
      ";
      _db.Execute(sql, new{ id });
    }


   
  }
}