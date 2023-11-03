using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class GardenMapper
    {
        public static GardenDto AdaptToDto(this Garden p1)
        {
            return p1 == null ? null : new GardenDto()
            {
                Name = p1.Name,
                AccountId = p1.AccountId,
                Account = funcMain1(p1.Account),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static GardenDto AdaptTo(this Garden p4, GardenDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            GardenDto result = p5 ?? new GardenDto();
            
            result.Name = p4.Name;
            result.AccountId = p4.AccountId;
            result.Account = funcMain3(p4.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p4.Visibility);
            result.Id = p4.Id;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedOn = p4.UpdatedOn;
            result.DeletedAt = p4.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Garden, GardenDto>> ProjectToDto => p10 => new GardenDto()
        {
            Name = p10.Name,
            AccountId = p10.AccountId,
            Account = p10.Account == null ? null : new AccountDto()
            {
                Email = p10.Account.Email,
                Username = p10.Account.Username,
                DisplayName = p10.Account.DisplayName,
                ProfileIntroduction = p10.Account.ProfileIntroduction,
                ProfilePicure = p10.Account.ProfilePicure,
                UserObjectIdAzureAd = p10.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p10.Account.UserIdentityProvider,
                Roles = p10.Account.Roles.Select<AccountRoles, AccountRolesDto>(p11 => new AccountRolesDto()
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
                Id = p10.Account.Id,
                CreatedOn = p10.Account.CreatedOn,
                UpdatedOn = p10.Account.UpdatedOn,
                DeletedAt = p10.Account.DeletedAt
            },
            Visibility = Enum<Visibility>.ToString(p10.Visibility),
            Id = p10.Id,
            CreatedOn = p10.CreatedOn,
            UpdatedOn = p10.UpdatedOn,
            DeletedAt = p10.DeletedAt
        };
        public static GardenList AdaptToList(this Garden p12)
        {
            return p12 == null ? null : new GardenList()
            {
                Name = p12.Name,
                AccountId = p12.AccountId,
                Account = p12.Account == null ? null : new AccountList()
                {
                    Email = p12.Account.Email,
                    Username = p12.Account.Username,
                    DisplayName = p12.Account.DisplayName,
                    ProfileIntroduction = p12.Account.ProfileIntroduction,
                    ProfilePicure = p12.Account.ProfilePicure,
                    UserObjectIdAzureAd = p12.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p12.Account.UserIdentityProvider,
                    Id = p12.Account.Id,
                    CreatedOn = p12.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p12.Visibility),
                Id = p12.Id,
                CreatedOn = p12.CreatedOn
            };
        }
        public static GardenList AdaptTo(this Garden p13, GardenList p14)
        {
            if (p13 == null)
            {
                return null;
            }
            GardenList result = p14 ?? new GardenList();
            
            result.Name = p13.Name;
            result.AccountId = p13.AccountId;
            result.Account = funcMain5(p13.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p13.Visibility);
            result.Id = p13.Id;
            result.CreatedOn = p13.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenList>> ProjectToList => p17 => new GardenList()
        {
            Name = p17.Name,
            AccountId = p17.AccountId,
            Account = p17.Account == null ? null : new AccountList()
            {
                Email = p17.Account.Email,
                Username = p17.Account.Username,
                DisplayName = p17.Account.DisplayName,
                ProfileIntroduction = p17.Account.ProfileIntroduction,
                ProfilePicure = p17.Account.ProfilePicure,
                UserObjectIdAzureAd = p17.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p17.Account.UserIdentityProvider,
                Id = p17.Account.Id,
                CreatedOn = p17.Account.CreatedOn
            },
            Visibility = Enum<Visibility>.ToString(p17.Visibility),
            Id = p17.Id,
            CreatedOn = p17.CreatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p18)
        {
            return p18 == null ? null : new Garden()
            {
                Name = p18.Name,
                AccountId = p18.AccountId,
                Visibility = p18.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p18.Visibility)
            };
        }
        public static Garden AdaptTo(this GardenMerge p19, Garden p20)
        {
            if (p19 == null)
            {
                return null;
            }
            Garden result = p20 ?? new Garden();
            
            if (p19.Name != null)
            {
                result.Name = p19.Name;
            }
            
            if (p19.AccountId != null)
            {
                result.AccountId = (Guid)p19.AccountId;
            }
            
            if (p19.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p19.Visibility);
            }
            return result;
            
        }
        
        private static AccountDto funcMain1(Account p2)
        {
            return p2 == null ? null : new AccountDto()
            {
                Email = p2.Email,
                Username = p2.Username,
                DisplayName = p2.DisplayName,
                ProfileIntroduction = p2.ProfileIntroduction,
                ProfilePicure = p2.ProfilePicure,
                UserObjectIdAzureAd = p2.UserObjectIdAzureAd,
                UserIdentityProvider = p2.UserIdentityProvider,
                Roles = funcMain2(p2.Roles),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static AccountDto funcMain3(Account p6, AccountDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            AccountDto result = p7 ?? new AccountDto();
            
            result.Email = p6.Email;
            result.Username = p6.Username;
            result.DisplayName = p6.DisplayName;
            result.ProfileIntroduction = p6.ProfileIntroduction;
            result.ProfilePicure = p6.ProfilePicure;
            result.UserObjectIdAzureAd = p6.UserObjectIdAzureAd;
            result.UserIdentityProvider = p6.UserIdentityProvider;
            result.Roles = funcMain4(p6.Roles, result.Roles);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            result.UpdatedOn = p6.UpdatedOn;
            result.DeletedAt = p6.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain5(Account p15, AccountList p16)
        {
            if (p15 == null)
            {
                return null;
            }
            AccountList result = p16 ?? new AccountList();
            
            result.Email = p15.Email;
            result.Username = p15.Username;
            result.DisplayName = p15.DisplayName;
            result.ProfileIntroduction = p15.ProfileIntroduction;
            result.ProfilePicure = p15.ProfilePicure;
            result.UserObjectIdAzureAd = p15.UserObjectIdAzureAd;
            result.UserIdentityProvider = p15.UserIdentityProvider;
            result.Id = p15.Id;
            result.CreatedOn = p15.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain2(ICollection<AccountRoles> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p3.Count);
            
            IEnumerator<AccountRoles> enumerator = p3.GetEnumerator();
            
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
        
        private static ICollection<AccountRolesDto> funcMain4(ICollection<AccountRoles> p8, ICollection<AccountRolesDto> p9)
        {
            if (p8 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p8.Count);
            
            IEnumerator<AccountRoles> enumerator = p8.GetEnumerator();
            
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
    }
}