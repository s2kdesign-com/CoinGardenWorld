using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountMapper
    {
        public static AccountDto AdaptToDto(this Account p1)
        {
            return p1 == null ? null : new AccountDto()
            {
                Email = p1.Email,
                Username = p1.Username,
                DisplayName = p1.DisplayName,
                ProfileIntroduction = p1.ProfileIntroduction,
                ProfilePicure = p1.ProfilePicure,
                UserObjectIdAzureAd = p1.UserObjectIdAzureAd,
                Roles = funcMain1(p1.Roles),
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static AccountDto AdaptTo(this Account p3, AccountDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            AccountDto result = p4 ?? new AccountDto();
            
            result.Email = p3.Email;
            result.Username = p3.Username;
            result.DisplayName = p3.DisplayName;
            result.ProfileIntroduction = p3.ProfileIntroduction;
            result.ProfilePicure = p3.ProfilePicure;
            result.UserObjectIdAzureAd = p3.UserObjectIdAzureAd;
            result.Roles = funcMain2(p3.Roles, result.Roles);
            result.Id = p3.Id;
            result.CreatedFrom = p3.CreatedFrom;
            result.CreatedOn = p3.CreatedOn;
            result.UpdatedFrom = p3.UpdatedFrom;
            result.UpdatedOn = p3.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Account, AccountDto>> ProjectToDto => p7 => new AccountDto()
        {
            Email = p7.Email,
            Username = p7.Username,
            DisplayName = p7.DisplayName,
            ProfileIntroduction = p7.ProfileIntroduction,
            ProfilePicure = p7.ProfilePicure,
            UserObjectIdAzureAd = p7.UserObjectIdAzureAd,
            Roles = p7.Roles.Select<AccountRoles, AccountRolesDto>(p8 => new AccountRolesDto()
            {
                AccountId = p8.AccountId,
                RoleId = p8.RoleId,
                Role = p8.Role == null ? null : new RoleDto()
                {
                    Name = p8.Role.Name,
                    Description = p8.Role.Description,
                    Id = p8.Role.Id,
                    CreatedFrom = p8.Role.CreatedFrom,
                    CreatedOn = p8.Role.CreatedOn,
                    UpdatedFrom = p8.Role.UpdatedFrom,
                    UpdatedOn = p8.Role.UpdatedOn
                },
                Id = p8.Id,
                CreatedFrom = p8.CreatedFrom,
                CreatedOn = p8.CreatedOn,
                UpdatedFrom = p8.UpdatedFrom,
                UpdatedOn = p8.UpdatedOn
            }).ToList<AccountRolesDto>(),
            Id = p7.Id,
            CreatedFrom = p7.CreatedFrom,
            CreatedOn = p7.CreatedOn,
            UpdatedFrom = p7.UpdatedFrom,
            UpdatedOn = p7.UpdatedOn
        };
        public static Account AdaptToAccount(this AccountAdd p9)
        {
            return p9 == null ? null : new Account()
            {
                Email = p9.Email,
                Username = p9.Username,
                DisplayName = p9.DisplayName,
                ProfileIntroduction = p9.ProfileIntroduction,
                ProfilePicure = p9.ProfilePicure,
                UserObjectIdAzureAd = p9.UserObjectIdAzureAd,
                Roles = funcMain3(p9.Roles)
            };
        }
        public static Account AdaptTo(this AccountMerge p11, Account p12)
        {
            if (p11 == null)
            {
                return null;
            }
            Account result = p12 ?? new Account();
            
            if (p11.Email != null)
            {
                result.Email = p11.Email;
            }
            
            if (p11.Username != null)
            {
                result.Username = p11.Username;
            }
            
            if (p11.DisplayName != null)
            {
                result.DisplayName = p11.DisplayName;
            }
            
            if (p11.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p11.ProfileIntroduction;
            }
            
            if (p11.ProfilePicure != null)
            {
                result.ProfilePicure = p11.ProfilePicure;
            }
            
            if (p11.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p11.UserObjectIdAzureAd;
            }
            
            if (p11.Roles != null)
            {
                result.Roles = funcMain4(p11.Roles, result.Roles);
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain1(ICollection<AccountRoles> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p2.Count);
            
            IEnumerator<AccountRoles> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRoles item = enumerator.Current;
                result.Add(item == null ? null : new AccountRolesDto()
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Role = item.Role == null ? null : new RoleDto()
                    {
                        Name = item.Role.Name,
                        Description = item.Role.Description,
                        Id = item.Role.Id,
                        CreatedFrom = item.Role.CreatedFrom,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedFrom = item.Role.UpdatedFrom,
                        UpdatedOn = item.Role.UpdatedOn
                    },
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain2(ICollection<AccountRoles> p5, ICollection<AccountRolesDto> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p5.Count);
            
            IEnumerator<AccountRoles> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRoles item = enumerator.Current;
                result.Add(item == null ? null : new AccountRolesDto()
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Role = item.Role == null ? null : new RoleDto()
                    {
                        Name = item.Role.Name,
                        Description = item.Role.Description,
                        Id = item.Role.Id,
                        CreatedFrom = item.Role.CreatedFrom,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedFrom = item.Role.UpdatedFrom,
                        UpdatedOn = item.Role.UpdatedOn
                    },
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRoles> funcMain3(ICollection<AccountRolesAdd> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            ICollection<AccountRoles> result = new List<AccountRoles>(p10.Count);
            
            IEnumerator<AccountRolesAdd> enumerator = p10.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRolesAdd item = enumerator.Current;
                result.Add(item == null ? null : new AccountRoles()
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Role = item.Role == null ? null : new Role()
                    {
                        Name = item.Role.Name,
                        Description = item.Role.Description
                    }
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRoles> funcMain4(ICollection<AccountRolesMerge> p13, ICollection<AccountRoles> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<AccountRoles> result = new List<AccountRoles>(p13.Count);
            
            IEnumerator<AccountRolesMerge> enumerator = p13.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRolesMerge item = enumerator.Current;
                result.Add(funcMain5(item));
            }
            return result;
            
        }
        
        private static AccountRoles funcMain5(AccountRolesMerge p15)
        {
            if (p15 == null)
            {
                return null;
            }
            AccountRoles result = new AccountRoles();
            
            if (p15.AccountId != null)
            {
                result.AccountId = (Guid)p15.AccountId;
            }
            
            if (p15.RoleId != null)
            {
                result.RoleId = (Guid)p15.RoleId;
            }
            
            if (p15.Role != null)
            {
                result.Role = funcMain6(p15.Role);
            }
            return result;
            
        }
        
        private static Role funcMain6(RoleMerge p16)
        {
            if (p16 == null)
            {
                return null;
            }
            Role result = new Role();
            
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