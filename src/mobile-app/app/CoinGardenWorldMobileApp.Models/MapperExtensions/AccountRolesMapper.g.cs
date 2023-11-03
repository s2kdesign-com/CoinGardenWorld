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
                    UpdatedOn = p1.Role.UpdatedOn,
                    DeletedFrom = p1.Role.DeletedFrom,
                    DeletedAt = p1.Role.DeletedAt
                },
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn,
                DeletedFrom = p1.DeletedFrom,
                DeletedAt = p1.DeletedAt
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
            result.DeletedFrom = p2.DeletedFrom;
            result.DeletedAt = p2.DeletedAt;
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
                UpdatedOn = p6.Role.UpdatedOn,
                DeletedFrom = p6.Role.DeletedFrom,
                DeletedAt = p6.Role.DeletedAt
            },
            Id = p6.Id,
            CreatedFrom = p6.CreatedFrom,
            CreatedOn = p6.CreatedOn,
            UpdatedFrom = p6.UpdatedFrom,
            UpdatedOn = p6.UpdatedOn,
            DeletedFrom = p6.DeletedFrom,
            DeletedAt = p6.DeletedAt
        };
        public static AccountRolesList AdaptToList(this AccountRoles p7)
        {
            return p7 == null ? null : new AccountRolesList()
            {
                AccountId = p7.AccountId,
                RoleId = p7.RoleId,
                Role = p7.Role == null ? null : new RoleList()
                {
                    Name = p7.Role.Name,
                    Description = p7.Role.Description
                }
            };
        }
        public static AccountRolesList AdaptTo(this AccountRoles p8, AccountRolesList p9)
        {
            if (p8 == null)
            {
                return null;
            }
            AccountRolesList result = p9 ?? new AccountRolesList();
            
            result.AccountId = p8.AccountId;
            result.RoleId = p8.RoleId;
            result.Role = funcMain2(p8.Role, result.Role);
            return result;
            
        }
        public static Expression<Func<AccountRoles, AccountRolesList>> ProjectToList => p12 => new AccountRolesList()
        {
            AccountId = p12.AccountId,
            RoleId = p12.RoleId,
            Role = p12.Role == null ? null : new RoleList()
            {
                Name = p12.Role.Name,
                Description = p12.Role.Description
            }
        };
        public static AccountRoles AdaptToAccountRoles(this AccountRolesAdd p13)
        {
            return p13 == null ? null : new AccountRoles()
            {
                AccountId = p13.AccountId,
                RoleId = p13.RoleId,
                Role = p13.Role == null ? null : new Role()
                {
                    Name = p13.Role.Name,
                    Description = p13.Role.Description
                }
            };
        }
        public static AccountRoles AdaptTo(this AccountRolesMerge p14, AccountRoles p15)
        {
            if (p14 == null)
            {
                return null;
            }
            AccountRoles result = p15 ?? new AccountRoles();
            
            if (p14.AccountId != null)
            {
                result.AccountId = (Guid)p14.AccountId;
            }
            
            if (p14.RoleId != null)
            {
                result.RoleId = (Guid)p14.RoleId;
            }
            
            if (p14.Role != null)
            {
                result.Role = funcMain3(p14.Role, result.Role);
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
            result.DeletedFrom = p4.DeletedFrom;
            result.DeletedAt = p4.DeletedAt;
            return result;
            
        }
        
        private static RoleList funcMain2(Role p10, RoleList p11)
        {
            if (p10 == null)
            {
                return null;
            }
            RoleList result = p11 ?? new RoleList();
            
            result.Name = p10.Name;
            result.Description = p10.Description;
            return result;
            
        }
        
        private static Role funcMain3(RoleMerge p16, Role p17)
        {
            if (p16 == null)
            {
                return null;
            }
            Role result = p17 ?? new Role();
            
            if (p16.Name != null)
            {
                result.Name = p16.Name;
            }
            
            if (p16.Description != null)
            {
                result.Description = p16.Description;
            }
            return result;
            
        }
    }
}