﻿using FdSoft.CodeGenerator.Common.Attribute;
using FdSoft.CodeGenerator.Common.Extensions;
using SqlSugar;
using System.Collections.Generic;
using FdSoft.CodeGenerator.Model;
using FdSoft.CodeGenerator.Model.System;
using FdSoft.CodeGenerator.Model.System.Dto;

namespace FdSoft.CodeGenerator.Repository.System
{
    [AppService(ServiceLifetime = LifeTime.Transient)]
    public class SysUserRoleRepository : BaseRepository<SysUserRole>
    {
        /// <summary>
        /// 批量删除角色对应用户
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="userIds">用户id集合</param>
        /// <returns></returns>
        public int DeleteRoleUserByUserIds(long roleId, List<long> userIds)
        {
            return Context.Deleteable<SysUserRole>().Where(it => it.RoleId == roleId && userIds.Contains(it.UserId))
                .ExecuteCommand();
        }

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysUser> GetSysUsersByRoleId(long roleId)
        {
            return Context.Queryable<SysUserRole, SysUser>((t1, u) => new JoinQueryInfos(
                JoinType.Left, t1.UserId == u.UserId))
                .Where((t1, u) => t1.RoleId == roleId && u.DelFlag == "0")
                .Select((t1, u) => u)
                .ToList();
        }

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="roleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetSysUsersByRoleId(RoleUserQueryDto roleUserQueryDto)
        {
            var query = Context.Queryable<SysUserRole, SysUser>((t1, u) => new JoinQueryInfos(
                JoinType.Left, t1.UserId == u.UserId))
                .Where((t1, u) => t1.RoleId == roleUserQueryDto.RoleId && u.DelFlag == "0");
            if (!string.IsNullOrEmpty(roleUserQueryDto.UserName))
            {
                query = query.Where((t1, u) => u.UserName.Contains(roleUserQueryDto.UserName));
            }
            return query.Select((t1, u) => u).ToPage(roleUserQueryDto);
        }

        /// <summary>
        /// 获取尚未指派的用户数据根据角色id
        /// </summary>
        /// <param name="roleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetExcludedSysUsersByRoleId(RoleUserQueryDto roleUserQueryDto)
        {
            var query = Context.Queryable<SysUser>()
                .Where(it => it.DelFlag == "0")
                .Where(it => SqlFunc.Subqueryable<SysUserRole>().Where(s => s.UserId == it.UserId && s.RoleId == roleUserQueryDto.RoleId).NotAny())
                .WhereIF(roleUserQueryDto.UserName.IsNotEmpty(), it => it.UserName.Contains(roleUserQueryDto.UserName));

            return query.ToPage(roleUserQueryDto);
        }
    }
}
