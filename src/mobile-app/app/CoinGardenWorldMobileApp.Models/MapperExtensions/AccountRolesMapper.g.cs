using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountRolesMapper
    {
        public static AccountRolesDto AdaptToDto(this AccountRoles p1)
        {
            return p1 == null ? null : new AccountRolesDto()
            {
                AccountId = p1.AccountId,
                RoleId = p1.RoleId,
                Role = p1.Role == null ? null : new RoleDto()
                {
                    Name = p1.Role.Name,
                    Description = p1.Role.Description,
                    Id = p1.Role.Id,
                    CreatedFrom = p1.Role.CreatedFrom,
                    CreatedOn = p1.Role.CreatedOn,
                    UpdatedFrom = p1.Role.UpdatedFrom,
                    UpdatedOn = p1.Role.UpdatedOn
                },
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static AccountRolesDto AdaptTo(this AccountRoles p2, AccountRolesDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountRolesDto result = p3 ?? new AccountRolesDto();
            
            result.AccountId = p2.AccountId;
            result.RoleId = p2.RoleId;
            result.Role = funcMain1(p2.Role, result.Role);
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<AccountRoles, AccountRolesDto>> ProjectToDto => p6 => new AccountRolesDto()
        {
            AccountId = p6.AccountId,
            RoleId = p6.RoleId,
            Role = p6.Role == null ? null : new RoleDto()
            {
                Name = p6.Role.Name,
                Description = p6.Role.Description,
                Id = p6.Role.Id,
                CreatedFrom = p6.Role.CreatedFrom,
                CreatedOn = p6.Role.CreatedOn,
                UpdatedFrom = p6.Role.UpdatedFrom,
                UpdatedOn = p6.Role.UpdatedOn
            },
            Id = p6.Id,
            CreatedFrom = p6.CreatedFrom,
            CreatedOn = p6.CreatedOn,
            UpdatedFrom = p6.UpdatedFrom,
            UpdatedOn = p6.UpdatedOn
        };
        public static AccountRoles AdaptToAccountRoles(this AccountRolesAdd p7)
        {
            return p7 == null ? null : new AccountRoles()
            {
                AccountId = p7.AccountId,
                RoleId = p7.RoleId,
                Role = p7.Role == null ? null : new Role()
                {
                    Name = p7.Role.Name,
                    Description = p7.Role.Description
                }
            };
        }
        public static AccountRoles AdaptTo(this AccountRolesMerge p8, AccountRoles p9)
        {
            if (p8 == null)
            {
                return null;
            }
            AccountRoles result = p9 ?? new AccountRoles();
            
            if (p8.AccountId != null)
            {
                result.AccountId = (Guid)p8.AccountId;
            }
            
            if (p8.RoleId != null)
            {
                result.RoleId = (Guid)p8.RoleId;
            }
            
            if (p8.Role != null)
            {
                result.Role = funcMain2(p8.Role, result.Role);
            }
            return result;
            
        }
        
        private static RoleDto funcMain1(Role p4, RoleDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            RoleDto result = p5 ?? new RoleDto();
            
            result.Name = p4.Name;
            result.Description = p4.Description;
            result.Id = p4.Id;
            result.CreatedFrom = p4.CreatedFrom;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedFrom = p4.UpdatedFrom;
            result.UpdatedOn = p4.UpdatedOn;
            return result;
            
        }
        
        private static Role funcMain2(RoleMerge p10, Role p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Role result = p11 ?? new Role();
            
            if (p10.Name != null)
            {
                result.Name = p10.Name;
            }
            
            if (p10.Description != null)
            {
                result.Description = p10.Description;
            }
            return result;
            
        }
    }
}