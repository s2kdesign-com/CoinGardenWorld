using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

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
                Roles = funcMain1(p1.Roles),
                ExternalLogins = funcMain2(p1.ExternalLogins),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static AccountDto AdaptTo(this Account p4, AccountDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            AccountDto result = p5 ?? new AccountDto();
            
            result.Email = p4.Email;
            result.Username = p4.Username;
            result.DisplayName = p4.DisplayName;
            result.ProfileIntroduction = p4.ProfileIntroduction;
            result.ProfilePicure = p4.ProfilePicure;
            result.Roles = funcMain3(p4.Roles, result.Roles);
            result.ExternalLogins = funcMain4(p4.ExternalLogins, result.ExternalLogins);
            result.Id = p4.Id;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedOn = p4.UpdatedOn;
            result.DeletedAt = p4.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Account, AccountDto>> ProjectToDto => p10 => new AccountDto()
        {
            Email = p10.Email,
            Username = p10.Username,
            DisplayName = p10.DisplayName,
            ProfileIntroduction = p10.ProfileIntroduction,
            ProfilePicure = p10.ProfilePicure,
            Roles = p10.Roles.Select<AccountRoles, AccountRolesDto>(p11 => new AccountRolesDto()
            {
                AccountId = p11.AccountId,
                RoleId = p11.RoleId,
                Role = p11.Role == null ? null : new RoleDto()
                {
                    Name = p11.Role.Name,
                    Description = p11.Role.Description,
                    Visibility = Enum<Visibility>.ToString(p11.Role.Visibility),
                    Id = p11.Role.Id,
                    CreatedOn = p11.Role.CreatedOn,
                    UpdatedOn = p11.Role.UpdatedOn,
                    DeletedAt = p11.Role.DeletedAt
                },
                Id = p11.Id,
                CreatedOn = p11.CreatedOn,
                UpdatedOn = p11.UpdatedOn,
                DeletedAt = p11.DeletedAt
            }).ToList<AccountRolesDto>(),
            ExternalLogins = p10.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p12 => new AccountExternalLoginsDto()
            {
                AccountId = p12.AccountId,
                DisplayName = p12.DisplayName,
                ObjectIdAzureAd = p12.ObjectIdAzureAd,
                IdentityProvider = p12.IdentityProvider,
                ProfilePictureUrl = p12.ProfilePictureUrl,
                Id = p12.Id,
                CreatedOn = p12.CreatedOn,
                UpdatedOn = p12.UpdatedOn,
                DeletedAt = p12.DeletedAt
            }).ToList<AccountExternalLoginsDto>(),
            Id = p10.Id,
            CreatedOn = p10.CreatedOn,
            UpdatedOn = p10.UpdatedOn,
            DeletedAt = p10.DeletedAt
        };
        public static AccountList AdaptToList(this Account p13)
        {
            return p13 == null ? null : new AccountList()
            {
                Email = p13.Email,
                Username = p13.Username,
                DisplayName = p13.DisplayName,
                ProfileIntroduction = p13.ProfileIntroduction,
                ProfilePicure = p13.ProfilePicure,
                Id = p13.Id,
                CreatedOn = p13.CreatedOn
            };
        }
        public static AccountList AdaptTo(this Account p14, AccountList p15)
        {
            if (p14 == null)
            {
                return null;
            }
            AccountList result = p15 ?? new AccountList();
            
            result.Email = p14.Email;
            result.Username = p14.Username;
            result.DisplayName = p14.DisplayName;
            result.ProfileIntroduction = p14.ProfileIntroduction;
            result.ProfilePicure = p14.ProfilePicure;
            result.Id = p14.Id;
            result.CreatedOn = p14.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Account, AccountList>> ProjectToList => p16 => new AccountList()
        {
            Email = p16.Email,
            Username = p16.Username,
            DisplayName = p16.DisplayName,
            ProfileIntroduction = p16.ProfileIntroduction,
            ProfilePicure = p16.ProfilePicure,
            Id = p16.Id,
            CreatedOn = p16.CreatedOn
        };
        public static Account AdaptToAccount(this AccountAdd p17)
        {
            return p17 == null ? null : new Account()
            {
                Email = p17.Email,
                Username = p17.Username,
                DisplayName = p17.DisplayName,
                ProfileIntroduction = p17.ProfileIntroduction,
                ProfilePicure = p17.ProfilePicure
            };
        }
        public static Account AdaptTo(this AccountMerge p18, Account p19)
        {
            if (p18 == null)
            {
                return null;
            }
            Account result = p19 ?? new Account();
            
            if (p18.Email != null)
            {
                result.Email = p18.Email;
            }
            
            if (p18.Username != null)
            {
                result.Username = p18.Username;
            }
            
            if (p18.DisplayName != null)
            {
                result.DisplayName = p18.DisplayName;
            }
            
            if (p18.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p18.ProfileIntroduction;
            }
            
            if (p18.ProfilePicure != null)
            {
                result.ProfilePicure = p18.ProfilePicure;
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
                        Visibility = Enum<Visibility>.ToString(item.Role.Visibility),
                        Id = item.Role.Id,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountExternalLoginsDto> funcMain2(ICollection<AccountExternalLogins> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p3.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p3.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain3(ICollection<AccountRoles> p6, ICollection<AccountRolesDto> p7)
        {
            if (p6 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p6.Count);
            
            IEnumerator<AccountRoles> enumerator = p6.GetEnumerator();
            
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
                        Visibility = Enum<Visibility>.ToString(item.Role.Visibility),
                        Id = item.Role.Id,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountExternalLoginsDto> funcMain4(ICollection<AccountExternalLogins> p8, ICollection<AccountExternalLoginsDto> p9)
        {
            if (p8 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p8.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
    }
}