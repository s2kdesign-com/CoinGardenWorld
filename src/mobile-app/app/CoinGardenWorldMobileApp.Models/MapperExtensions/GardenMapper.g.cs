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
        public static GardenDto AdaptTo(this Garden p5, GardenDto p6)
        {
            if (p5 == null)
            {
                return null;
            }
            GardenDto result = p6 ?? new GardenDto();
            
            result.Name = p5.Name;
            result.AccountId = p5.AccountId;
            result.Account = funcMain4(p5.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p5.Visibility);
            result.Id = p5.Id;
            result.CreatedOn = p5.CreatedOn;
            result.UpdatedOn = p5.UpdatedOn;
            result.DeletedAt = p5.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Garden, GardenDto>> ProjectToDto => p13 => new GardenDto()
        {
            Name = p13.Name,
            AccountId = p13.AccountId,
            Account = p13.Account == null ? null : new AccountDto()
            {
                Email = p13.Account.Email,
                Username = p13.Account.Username,
                DisplayName = p13.Account.DisplayName,
                ProfileIntroduction = p13.Account.ProfileIntroduction,
                ProfilePicure = p13.Account.ProfilePicure,
                Roles = p13.Account.Roles.Select<AccountRoles, AccountRolesDto>(p14 => new AccountRolesDto()
                {
                    AccountId = p14.AccountId,
                    RoleId = p14.RoleId,
                    Role = p14.Role == null ? null : new RoleDto()
                    {
                        Name = p14.Role.Name,
                        Description = p14.Role.Description,
                        Visibility = Enum<Visibility>.ToString(p14.Role.Visibility),
                        Id = p14.Role.Id,
                        CreatedOn = p14.Role.CreatedOn,
                        UpdatedOn = p14.Role.UpdatedOn,
                        DeletedAt = p14.Role.DeletedAt
                    },
                    Id = p14.Id,
                    CreatedOn = p14.CreatedOn,
                    UpdatedOn = p14.UpdatedOn,
                    DeletedAt = p14.DeletedAt
                }).ToList<AccountRolesDto>(),
                ExternalLogins = p13.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p15 => new AccountExternalLoginsDto()
                {
                    AccountId = p15.AccountId,
                    DisplayName = p15.DisplayName,
                    ObjectIdAzureAd = p15.ObjectIdAzureAd,
                    IdentityProvider = p15.IdentityProvider,
                    ProfilePictureUrl = p15.ProfilePictureUrl,
                    Id = p15.Id,
                    CreatedOn = p15.CreatedOn,
                    UpdatedOn = p15.UpdatedOn,
                    DeletedAt = p15.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p13.Account.Id,
                CreatedOn = p13.Account.CreatedOn,
                UpdatedOn = p13.Account.UpdatedOn,
                DeletedAt = p13.Account.DeletedAt
            },
            Visibility = Enum<Visibility>.ToString(p13.Visibility),
            Id = p13.Id,
            CreatedOn = p13.CreatedOn,
            UpdatedOn = p13.UpdatedOn,
            DeletedAt = p13.DeletedAt
        };
        public static GardenList AdaptToList(this Garden p16)
        {
            return p16 == null ? null : new GardenList()
            {
                Name = p16.Name,
                AccountId = p16.AccountId,
                Account = p16.Account == null ? null : new AccountList()
                {
                    Email = p16.Account.Email,
                    Username = p16.Account.Username,
                    DisplayName = p16.Account.DisplayName,
                    ProfileIntroduction = p16.Account.ProfileIntroduction,
                    ProfilePicure = p16.Account.ProfilePicure,
                    Id = p16.Account.Id,
                    CreatedOn = p16.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p16.Visibility),
                Id = p16.Id,
                CreatedOn = p16.CreatedOn
            };
        }
        public static GardenList AdaptTo(this Garden p17, GardenList p18)
        {
            if (p17 == null)
            {
                return null;
            }
            GardenList result = p18 ?? new GardenList();
            
            result.Name = p17.Name;
            result.AccountId = p17.AccountId;
            result.Account = funcMain7(p17.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p17.Visibility);
            result.Id = p17.Id;
            result.CreatedOn = p17.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenList>> ProjectToList => p21 => new GardenList()
        {
            Name = p21.Name,
            AccountId = p21.AccountId,
            Account = p21.Account == null ? null : new AccountList()
            {
                Email = p21.Account.Email,
                Username = p21.Account.Username,
                DisplayName = p21.Account.DisplayName,
                ProfileIntroduction = p21.Account.ProfileIntroduction,
                ProfilePicure = p21.Account.ProfilePicure,
                Id = p21.Account.Id,
                CreatedOn = p21.Account.CreatedOn
            },
            Visibility = Enum<Visibility>.ToString(p21.Visibility),
            Id = p21.Id,
            CreatedOn = p21.CreatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p22)
        {
            return p22 == null ? null : new Garden()
            {
                Name = p22.Name,
                AccountId = p22.AccountId,
                Visibility = p22.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p22.Visibility)
            };
        }
        public static Garden AdaptTo(this GardenMerge p23, Garden p24)
        {
            if (p23 == null)
            {
                return null;
            }
            Garden result = p24 ?? new Garden();
            
            if (p23.Name != null)
            {
                result.Name = p23.Name;
            }
            
            if (p23.AccountId != null)
            {
                result.AccountId = (Guid)p23.AccountId;
            }
            
            if (p23.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p23.Visibility);
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
                Roles = funcMain2(p2.Roles),
                ExternalLogins = funcMain3(p2.ExternalLogins),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static AccountDto funcMain4(Account p7, AccountDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            AccountDto result = p8 ?? new AccountDto();
            
            result.Email = p7.Email;
            result.Username = p7.Username;
            result.DisplayName = p7.DisplayName;
            result.ProfileIntroduction = p7.ProfileIntroduction;
            result.ProfilePicure = p7.ProfilePicure;
            result.Roles = funcMain5(p7.Roles, result.Roles);
            result.ExternalLogins = funcMain6(p7.ExternalLogins, result.ExternalLogins);
            result.Id = p7.Id;
            result.CreatedOn = p7.CreatedOn;
            result.UpdatedOn = p7.UpdatedOn;
            result.DeletedAt = p7.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain7(Account p19, AccountList p20)
        {
            if (p19 == null)
            {
                return null;
            }
            AccountList result = p20 ?? new AccountList();
            
            result.Email = p19.Email;
            result.Username = p19.Username;
            result.DisplayName = p19.DisplayName;
            result.ProfileIntroduction = p19.ProfileIntroduction;
            result.ProfilePicure = p19.ProfilePicure;
            result.Id = p19.Id;
            result.CreatedOn = p19.CreatedOn;
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain3(ICollection<AccountExternalLogins> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p4.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p4.GetEnumerator();
            
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
        
        private static ICollection<AccountRolesDto> funcMain5(ICollection<AccountRoles> p9, ICollection<AccountRolesDto> p10)
        {
            if (p9 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p9.Count);
            
            IEnumerator<AccountRoles> enumerator = p9.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain6(ICollection<AccountExternalLogins> p11, ICollection<AccountExternalLoginsDto> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p11.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p11.GetEnumerator();
            
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