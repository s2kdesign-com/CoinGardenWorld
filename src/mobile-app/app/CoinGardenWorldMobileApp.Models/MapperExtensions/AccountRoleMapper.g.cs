using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountRoleMapper
    {
        public static AccountRoleDto AdaptToDto(this AccountRole p1)
        {
            return p1 == null ? null : new AccountRoleDto()
            {
                RoleId = p1.RoleId,
                RoleName = p1.RoleName,
                AssignedOn = p1.AssignedOn
            };
        }
        public static AccountRoleDto AdaptTo(this AccountRole p2, AccountRoleDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountRoleDto result = p3 ?? new AccountRoleDto();
            
            result.RoleId = p2.RoleId;
            result.RoleName = p2.RoleName;
            result.AssignedOn = p2.AssignedOn;
            return result;
            
        }
        public static Expression<Func<AccountRole, AccountRoleDto>> ProjectToDto => p4 => new AccountRoleDto()
        {
            RoleId = p4.RoleId,
            RoleName = p4.RoleName,
            AssignedOn = p4.AssignedOn
        };
        public static AccountRoleList AdaptToList(this AccountRole p5)
        {
            return p5 == null ? null : new AccountRoleList()
            {
                RoleId = p5.RoleId,
                RoleName = p5.RoleName,
                AssignedOn = p5.AssignedOn
            };
        }
        public static AccountRoleList AdaptTo(this AccountRole p6, AccountRoleList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            AccountRoleList result = p7 ?? new AccountRoleList();
            
            result.RoleId = p6.RoleId;
            result.RoleName = p6.RoleName;
            result.AssignedOn = p6.AssignedOn;
            return result;
            
        }
        public static Expression<Func<AccountRole, AccountRoleList>> ProjectToList => p8 => new AccountRoleList()
        {
            RoleId = p8.RoleId,
            RoleName = p8.RoleName,
            AssignedOn = p8.AssignedOn
        };
        public static AccountRole AdaptToAccountRole(this AccountRoleAdd p9)
        {
            return p9 == null ? null : new AccountRole()
            {
                RoleId = p9.RoleId,
                RoleName = p9.RoleName,
                AssignedOn = p9.AssignedOn
            };
        }
        public static AccountRole AdaptTo(this AccountRoleMerge p10, AccountRole p11)
        {
            if (p10 == null)
            {
                return null;
            }
            AccountRole result = p11 ?? new AccountRole();
            
            if (p10.RoleId != null)
            {
                result.RoleId = (Guid)p10.RoleId;
            }
            
            if (p10.RoleName != null)
            {
                result.RoleName = p10.RoleName;
            }
            
            if (p10.AssignedOn != null)
            {
                result.AssignedOn = (DateTimeOffset)p10.AssignedOn;
            }
            return result;
            
        }
    }
}