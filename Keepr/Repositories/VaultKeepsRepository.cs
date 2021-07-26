using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

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
      limit 1;
      ";
      _db.Execute(sql, new{ id });
    }

    //come back to this vv

    // internal List<VaultKeep> GetKeepsByVaultId(int keepId)
    // {
    //   string  sql = @"
    //   SELECT
    //   k.*,
    //   vk.*
    //   FROM vault_keeps vk
    //   JOIN keeps k ON k.id = vk.keepId`
    //   WHERE vk.vaultId = @VaultId;
    //   ";
    //   return _db.Query<Keep, VaultKeep, Keep>(sql, (k, vk) =>
    //   {
    //     k.
    //   }, new { keepId }, splitOn: "id").ToList();
     
    // }
  }
}
//  internal List<GroupMember> GetMembersByGroupId(int id)
//         {
//             // REVIEW joining data and mapping to two classes
//             string sql = @"
//             SELECT *
//             FROM group_members gm
//             JOIN accounts a ON a.id = gm.accountId
//             WHERE groupId = @id; 
//             ";
//             //               vv g         vv p     vv return type of the entire Query
//             return _db.Query<GroupMember, Profile, GroupMember>(sql, (g, p) =>
//             {
//                 g.Profile = p;
//                 return g;
//             }, new { id }).ToList();