using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

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
                    Visibility = Enum<Visibility>.ToString(p1.Role.Visibility),
                    Id = p1.Role.Id,
                    CreatedOn = p1.Role.CreatedOn,
                    UpdatedOn = p1.Role.UpdatedOn,
                    DeletedAt = p1.Role.DeletedAt
                },
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
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
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
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
                Visibility = Enum<Visibility>.ToString(p6.Role.Visibility),
                Id = p6.Role.Id,
                CreatedOn = p6.Role.CreatedOn,
                UpdatedOn = p6.Role.UpdatedOn,
                DeletedAt = p6.Role.DeletedAt
            },
            Id = p6.Id,
            CreatedOn = p6.CreatedOn,
            UpdatedOn = p6.UpdatedOn,
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
                    Description = p7.Role.Description,
                    Visibility = Enum<Visibility>.ToString(p7.Role.Visibility),
                    Id = p7.Role.Id,
                    CreatedOn = p7.Role.CreatedOn
                },
                Id = p7.Id,
                CreatedOn = p7.CreatedOn
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
            result.Id = p8.Id;
            result.CreatedOn = p8.CreatedOn;
            return result;
            
        }
        public static Expression<Func<AccountRoles, AccountRolesList>> ProjectToList => p12 => new AccountRolesList()
        {
            AccountId = p12.AccountId,
            RoleId = p12.RoleId,
            Role = p12.Role == null ? null : new RoleList()
            {
                Name = p12.Role.Name,
                Description = p12.Role.Description,
                Visibility = Enum<Visibility>.ToString(p12.Role.Visibility),
                Id = p12.Role.Id,
                CreatedOn = p12.Role.CreatedOn
            },
            Id = p12.Id,
            CreatedOn = p12.CreatedOn
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
                    Description = p13.Role.Description,
                    Visibility = p13.Role.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p13.Role.Visibility)
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
            result.Visibility = Enum<Visibility>.ToString(p4.Visibility);
            result.Id = p4.Id;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedOn = p4.UpdatedOn;
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
            result.Visibility = Enum<Visibility>.ToString(p10.Visibility);
            result.Id = p10.Id;
            result.CreatedOn = p10.CreatedOn;
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
            
            if (p16.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p16.Visibility);
            }
            return result;
            
        }
    }
}