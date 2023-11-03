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
                UpdatedOn = p1.UpdatedOn,
                DeletedFrom = p1.DeletedFrom,
                DeletedAt = p1.DeletedAt
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
            result.DeletedFrom = p3.DeletedFrom;
            result.DeletedAt = p3.DeletedAt;
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
                    UpdatedOn = p8.Role.UpdatedOn,
                    DeletedFrom = p8.Role.DeletedFrom,
                    DeletedAt = p8.Role.DeletedAt
                },
                Id = p8.Id,
                CreatedFrom = p8.CreatedFrom,
                CreatedOn = p8.CreatedOn,
                UpdatedFrom = p8.UpdatedFrom,
                UpdatedOn = p8.UpdatedOn,
                DeletedFrom = p8.DeletedFrom,
                DeletedAt = p8.DeletedAt
            }).ToList<AccountRolesDto>(),
            Id = p7.Id,
            CreatedFrom = p7.CreatedFrom,
            CreatedOn = p7.CreatedOn,
            UpdatedFrom = p7.UpdatedFrom,
            UpdatedOn = p7.UpdatedOn,
            DeletedFrom = p7.DeletedFrom,
            DeletedAt = p7.DeletedAt
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
                UserObjectIdAzureAd = p9.UserObjectIdAzureAd
            };
        }
        public static Account AdaptTo(this AccountMerge p10, Account p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Account result = p11 ?? new Account();
            
            if (p10.Email != null)
            {
                result.Email = p10.Email;
            }
            
            if (p10.Username != null)
            {
                result.Username = p10.Username;
            }
            
            if (p10.DisplayName != null)
            {
                result.DisplayName = p10.DisplayName;
            }
            
            if (p10.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p10.ProfileIntroduction;
            }
            
            if (p10.ProfilePicure != null)
            {
                result.ProfilePicure = p10.ProfilePicure;
            }
            
            if (p10.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p10.UserObjectIdAzureAd;
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
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedFrom = item.Role.DeletedFrom,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn,
                    DeletedFrom = item.DeletedFrom,
                    DeletedAt = item.DeletedAt
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
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedFrom = item.Role.DeletedFrom,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn,
                    DeletedFrom = item.DeletedFrom,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
    }
}