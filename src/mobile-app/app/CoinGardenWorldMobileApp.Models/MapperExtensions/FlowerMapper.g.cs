using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class FlowerMapper
    {
        public static FlowerDto AdaptToDto(this Flower p1)
        {
            return p1 == null ? null : new FlowerDto()
            {
                Name = p1.Name,
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                AccountId = p1.AccountId,
                Account = funcMain1(p1.Account),
                GardenId = p1.GardenId,
                Garden = funcMain3(p1.Garden),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static FlowerDto AdaptTo(this Flower p7, FlowerDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            FlowerDto result = p8 ?? new FlowerDto();
            
            result.Name = p7.Name;
            result.Visibility = Enum<Visibility>.ToString(p7.Visibility);
            result.AccountId = p7.AccountId;
            result.Account = funcMain6(p7.Account, result.Account);
            result.GardenId = p7.GardenId;
            result.Garden = funcMain8(p7.Garden, result.Garden);
            result.Id = p7.Id;
            result.CreatedOn = p7.CreatedOn;
            result.UpdatedOn = p7.UpdatedOn;
            result.DeletedAt = p7.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerDto>> ProjectToDto => p19 => new FlowerDto()
        {
            Name = p19.Name,
            Visibility = Enum<Visibility>.ToString(p19.Visibility),
            AccountId = p19.AccountId,
            Account = p19.Account == null ? null : new AccountDto()
            {
                Email = p19.Account.Email,
                Username = p19.Account.Username,
                DisplayName = p19.Account.DisplayName,
                ProfileIntroduction = p19.Account.ProfileIntroduction,
                ProfilePicure = p19.Account.ProfilePicure,
                UserObjectIdAzureAd = p19.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p19.Account.UserIdentityProvider,
                Roles = p19.Account.Roles.Select<AccountRoles, AccountRolesDto>(p20 => new AccountRolesDto()
                {
                    AccountId = p20.AccountId,
                    RoleId = p20.RoleId,
                    Role = p20.Role == null ? null : new RoleDto()
                    {
                        Name = p20.Role.Name,
                        Description = p20.Role.Description,
                        Visibility = Enum<Visibility>.ToString(p20.Role.Visibility),
                        Id = p20.Role.Id,
                        CreatedOn = p20.Role.CreatedOn,
                        UpdatedOn = p20.Role.UpdatedOn,
                        DeletedAt = p20.Role.DeletedAt
                    },
                    Id = p20.Id,
                    CreatedOn = p20.CreatedOn,
                    UpdatedOn = p20.UpdatedOn,
                    DeletedAt = p20.DeletedAt
                }).ToList<AccountRolesDto>(),
                Id = p19.Account.Id,
                CreatedOn = p19.Account.CreatedOn,
                UpdatedOn = p19.Account.UpdatedOn,
                DeletedAt = p19.Account.DeletedAt
            },
            GardenId = p19.GardenId,
            Garden = p19.Garden == null ? null : new GardenDto()
            {
                Name = p19.Garden.Name,
                AccountId = p19.Garden.AccountId,
                Account = p19.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p19.Garden.Account.Email,
                    Username = p19.Garden.Account.Username,
                    DisplayName = p19.Garden.Account.DisplayName,
                    ProfileIntroduction = p19.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p19.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p19.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p19.Garden.Account.UserIdentityProvider,
                    Roles = p19.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p21 => new AccountRolesDto()
                    {
                        AccountId = p21.AccountId,
                        RoleId = p21.RoleId,
                        Role = p21.Role == null ? null : new RoleDto()
                        {
                            Name = p21.Role.Name,
                            Description = p21.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p21.Role.Visibility),
                            Id = p21.Role.Id,
                            CreatedOn = p21.Role.CreatedOn,
                            UpdatedOn = p21.Role.UpdatedOn,
                            DeletedAt = p21.Role.DeletedAt
                        },
                        Id = p21.Id,
                        CreatedOn = p21.CreatedOn,
                        UpdatedOn = p21.UpdatedOn,
                        DeletedAt = p21.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    Id = p19.Garden.Account.Id,
                    CreatedOn = p19.Garden.Account.CreatedOn,
                    UpdatedOn = p19.Garden.Account.UpdatedOn,
                    DeletedAt = p19.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p19.Garden.Visibility),
                Id = p19.Garden.Id,
                CreatedOn = p19.Garden.CreatedOn,
                UpdatedOn = p19.Garden.UpdatedOn,
                DeletedAt = p19.Garden.DeletedAt
            },
            Id = p19.Id,
            CreatedOn = p19.CreatedOn,
            UpdatedOn = p19.UpdatedOn,
            DeletedAt = p19.DeletedAt
        };
        public static FlowerList AdaptToList(this Flower p22)
        {
            return p22 == null ? null : new FlowerList()
            {
                Name = p22.Name,
                Visibility = Enum<Visibility>.ToString(p22.Visibility),
                AccountId = p22.AccountId,
                Account = p22.Account == null ? null : new AccountList()
                {
                    Email = p22.Account.Email,
                    Username = p22.Account.Username,
                    DisplayName = p22.Account.DisplayName,
                    ProfileIntroduction = p22.Account.ProfileIntroduction,
                    ProfilePicure = p22.Account.ProfilePicure,
                    UserObjectIdAzureAd = p22.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p22.Account.UserIdentityProvider,
                    Id = p22.Account.Id,
                    CreatedOn = p22.Account.CreatedOn
                },
                GardenId = p22.GardenId,
                Garden = p22.Garden == null ? null : new GardenList()
                {
                    Name = p22.Garden.Name,
                    AccountId = p22.Garden.AccountId,
                    Account = p22.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p22.Garden.Account.Email,
                        Username = p22.Garden.Account.Username,
                        DisplayName = p22.Garden.Account.DisplayName,
                        ProfileIntroduction = p22.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p22.Garden.Account.ProfilePicure,
                        UserObjectIdAzureAd = p22.Garden.Account.UserObjectIdAzureAd,
                        UserIdentityProvider = p22.Garden.Account.UserIdentityProvider,
                        Id = p22.Garden.Account.Id,
                        CreatedOn = p22.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p22.Garden.Visibility),
                    Id = p22.Garden.Id,
                    CreatedOn = p22.Garden.CreatedOn
                },
                Id = p22.Id,
                CreatedOn = p22.CreatedOn
            };
        }
        public static FlowerList AdaptTo(this Flower p23, FlowerList p24)
        {
            if (p23 == null)
            {
                return null;
            }
            FlowerList result = p24 ?? new FlowerList();
            
            result.Name = p23.Name;
            result.Visibility = Enum<Visibility>.ToString(p23.Visibility);
            result.AccountId = p23.AccountId;
            result.Account = funcMain11(p23.Account, result.Account);
            result.GardenId = p23.GardenId;
            result.Garden = funcMain12(p23.Garden, result.Garden);
            result.Id = p23.Id;
            result.CreatedOn = p23.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerList>> ProjectToList => p31 => new FlowerList()
        {
            Name = p31.Name,
            Visibility = Enum<Visibility>.ToString(p31.Visibility),
            AccountId = p31.AccountId,
            Account = p31.Account == null ? null : new AccountList()
            {
                Email = p31.Account.Email,
                Username = p31.Account.Username,
                DisplayName = p31.Account.DisplayName,
                ProfileIntroduction = p31.Account.ProfileIntroduction,
                ProfilePicure = p31.Account.ProfilePicure,
                UserObjectIdAzureAd = p31.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p31.Account.UserIdentityProvider,
                Id = p31.Account.Id,
                CreatedOn = p31.Account.CreatedOn
            },
            GardenId = p31.GardenId,
            Garden = p31.Garden == null ? null : new GardenList()
            {
                Name = p31.Garden.Name,
                AccountId = p31.Garden.AccountId,
                Account = p31.Garden.Account == null ? null : new AccountList()
                {
                    Email = p31.Garden.Account.Email,
                    Username = p31.Garden.Account.Username,
                    DisplayName = p31.Garden.Account.DisplayName,
                    ProfileIntroduction = p31.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p31.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p31.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p31.Garden.Account.UserIdentityProvider,
                    Id = p31.Garden.Account.Id,
                    CreatedOn = p31.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p31.Garden.Visibility),
                Id = p31.Garden.Id,
                CreatedOn = p31.Garden.CreatedOn
            },
            Id = p31.Id,
            CreatedOn = p31.CreatedOn
        };
        public static Flower AdaptToFlower(this FlowerAdd p32)
        {
            return p32 == null ? null : new Flower()
            {
                Name = p32.Name,
                Visibility = p32.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p32.Visibility),
                AccountId = p32.AccountId
            };
        }
        public static Flower AdaptTo(this FlowerMerge p33, Flower p34)
        {
            if (p33 == null)
            {
                return null;
            }
            Flower result = p34 ?? new Flower();
            
            if (p33.Name != null)
            {
                result.Name = p33.Name;
            }
            
            if (p33.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p33.Visibility);
            }
            
            if (p33.AccountId != null)
            {
                result.AccountId = (Guid)p33.AccountId;
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
        
        private static GardenDto funcMain3(Garden p4)
        {
            return p4 == null ? null : new GardenDto()
            {
                Name = p4.Name,
                AccountId = p4.AccountId,
                Account = funcMain4(p4.Account),
                Visibility = Enum<Visibility>.ToString(p4.Visibility),
                Id = p4.Id,
                CreatedOn = p4.CreatedOn,
                UpdatedOn = p4.UpdatedOn,
                DeletedAt = p4.DeletedAt
            };
        }
        
        private static AccountDto funcMain6(Account p9, AccountDto p10)
        {
            if (p9 == null)
            {
                return null;
            }
            AccountDto result = p10 ?? new AccountDto();
            
            result.Email = p9.Email;
            result.Username = p9.Username;
            result.DisplayName = p9.DisplayName;
            result.ProfileIntroduction = p9.ProfileIntroduction;
            result.ProfilePicure = p9.ProfilePicure;
            result.UserObjectIdAzureAd = p9.UserObjectIdAzureAd;
            result.UserIdentityProvider = p9.UserIdentityProvider;
            result.Roles = funcMain7(p9.Roles, result.Roles);
            result.Id = p9.Id;
            result.CreatedOn = p9.CreatedOn;
            result.UpdatedOn = p9.UpdatedOn;
            result.DeletedAt = p9.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain8(Garden p13, GardenDto p14)
        {
            if (p13 == null)
            {
                return null;
            }
            GardenDto result = p14 ?? new GardenDto();
            
            result.Name = p13.Name;
            result.AccountId = p13.AccountId;
            result.Account = funcMain9(p13.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p13.Visibility);
            result.Id = p13.Id;
            result.CreatedOn = p13.CreatedOn;
            result.UpdatedOn = p13.UpdatedOn;
            result.DeletedAt = p13.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain11(Account p25, AccountList p26)
        {
            if (p25 == null)
            {
                return null;
            }
            AccountList result = p26 ?? new AccountList();
            
            result.Email = p25.Email;
            result.Username = p25.Username;
            result.DisplayName = p25.DisplayName;
            result.ProfileIntroduction = p25.ProfileIntroduction;
            result.ProfilePicure = p25.ProfilePicure;
            result.UserObjectIdAzureAd = p25.UserObjectIdAzureAd;
            result.UserIdentityProvider = p25.UserIdentityProvider;
            result.Id = p25.Id;
            result.CreatedOn = p25.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain12(Garden p27, GardenList p28)
        {
            if (p27 == null)
            {
                return null;
            }
            GardenList result = p28 ?? new GardenList();
            
            result.Name = p27.Name;
            result.AccountId = p27.AccountId;
            result.Account = funcMain13(p27.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p27.Visibility);
            result.Id = p27.Id;
            result.CreatedOn = p27.CreatedOn;
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
        
        private static AccountDto funcMain4(Account p5)
        {
            return p5 == null ? null : new AccountDto()
            {
                Email = p5.Email,
                Username = p5.Username,
                DisplayName = p5.DisplayName,
                ProfileIntroduction = p5.ProfileIntroduction,
                ProfilePicure = p5.ProfilePicure,
                UserObjectIdAzureAd = p5.UserObjectIdAzureAd,
                UserIdentityProvider = p5.UserIdentityProvider,
                Roles = funcMain5(p5.Roles),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn,
                DeletedAt = p5.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain7(ICollection<AccountRoles> p11, ICollection<AccountRolesDto> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p11.Count);
            
            IEnumerator<AccountRoles> enumerator = p11.GetEnumerator();
            
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
        
        private static AccountDto funcMain9(Account p15, AccountDto p16)
        {
            if (p15 == null)
            {
                return null;
            }
            AccountDto result = p16 ?? new AccountDto();
            
            result.Email = p15.Email;
            result.Username = p15.Username;
            result.DisplayName = p15.DisplayName;
            result.ProfileIntroduction = p15.ProfileIntroduction;
            result.ProfilePicure = p15.ProfilePicure;
            result.UserObjectIdAzureAd = p15.UserObjectIdAzureAd;
            result.UserIdentityProvider = p15.UserIdentityProvider;
            result.Roles = funcMain10(p15.Roles, result.Roles);
            result.Id = p15.Id;
            result.CreatedOn = p15.CreatedOn;
            result.UpdatedOn = p15.UpdatedOn;
            result.DeletedAt = p15.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain13(Account p29, AccountList p30)
        {
            if (p29 == null)
            {
                return null;
            }
            AccountList result = p30 ?? new AccountList();
            
            result.Email = p29.Email;
            result.Username = p29.Username;
            result.DisplayName = p29.DisplayName;
            result.ProfileIntroduction = p29.ProfileIntroduction;
            result.ProfilePicure = p29.ProfilePicure;
            result.UserObjectIdAzureAd = p29.UserObjectIdAzureAd;
            result.UserIdentityProvider = p29.UserIdentityProvider;
            result.Id = p29.Id;
            result.CreatedOn = p29.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain5(ICollection<AccountRoles> p6)
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
        
        private static ICollection<AccountRolesDto> funcMain10(ICollection<AccountRoles> p17, ICollection<AccountRolesDto> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p17.Count);
            
            IEnumerator<AccountRoles> enumerator = p17.GetEnumerator();
            
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