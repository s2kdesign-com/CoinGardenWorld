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
                Garden = funcMain4(p1.Garden),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static FlowerDto AdaptTo(this Flower p9, FlowerDto p10)
        {
            if (p9 == null)
            {
                return null;
            }
            FlowerDto result = p10 ?? new FlowerDto();
            
            result.Name = p9.Name;
            result.Visibility = Enum<Visibility>.ToString(p9.Visibility);
            result.AccountId = p9.AccountId;
            result.Account = funcMain8(p9.Account, result.Account);
            result.GardenId = p9.GardenId;
            result.Garden = funcMain11(p9.Garden, result.Garden);
            result.Id = p9.Id;
            result.CreatedOn = p9.CreatedOn;
            result.UpdatedOn = p9.UpdatedOn;
            result.DeletedAt = p9.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerDto>> ProjectToDto => p25 => new FlowerDto()
        {
            Name = p25.Name,
            Visibility = Enum<Visibility>.ToString(p25.Visibility),
            AccountId = p25.AccountId,
            Account = p25.Account == null ? null : new AccountDto()
            {
                Email = p25.Account.Email,
                Username = p25.Account.Username,
                DisplayName = p25.Account.DisplayName,
                ProfileIntroduction = p25.Account.ProfileIntroduction,
                ProfilePicure = p25.Account.ProfilePicure,
                Roles = p25.Account.Roles.Select<AccountRoles, AccountRolesDto>(p26 => new AccountRolesDto()
                {
                    AccountId = p26.AccountId,
                    RoleId = p26.RoleId,
                    Role = p26.Role == null ? null : new RoleDto()
                    {
                        Name = p26.Role.Name,
                        Description = p26.Role.Description,
                        Visibility = Enum<Visibility>.ToString(p26.Role.Visibility),
                        Id = p26.Role.Id,
                        CreatedOn = p26.Role.CreatedOn,
                        UpdatedOn = p26.Role.UpdatedOn,
                        DeletedAt = p26.Role.DeletedAt
                    },
                    Id = p26.Id,
                    CreatedOn = p26.CreatedOn,
                    UpdatedOn = p26.UpdatedOn,
                    DeletedAt = p26.DeletedAt
                }).ToList<AccountRolesDto>(),
                ExternalLogins = p25.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p27 => new AccountExternalLoginsDto()
                {
                    AccountId = p27.AccountId,
                    DisplayName = p27.DisplayName,
                    ObjectIdAzureAd = p27.ObjectIdAzureAd,
                    IdentityProvider = p27.IdentityProvider,
                    ProfilePictureUrl = p27.ProfilePictureUrl,
                    Id = p27.Id,
                    CreatedOn = p27.CreatedOn,
                    UpdatedOn = p27.UpdatedOn,
                    DeletedAt = p27.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p25.Account.Id,
                CreatedOn = p25.Account.CreatedOn,
                UpdatedOn = p25.Account.UpdatedOn,
                DeletedAt = p25.Account.DeletedAt
            },
            GardenId = p25.GardenId,
            Garden = p25.Garden == null ? null : new GardenDto()
            {
                Name = p25.Garden.Name,
                AccountId = p25.Garden.AccountId,
                Account = p25.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p25.Garden.Account.Email,
                    Username = p25.Garden.Account.Username,
                    DisplayName = p25.Garden.Account.DisplayName,
                    ProfileIntroduction = p25.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p25.Garden.Account.ProfilePicure,
                    Roles = p25.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p28 => new AccountRolesDto()
                    {
                        AccountId = p28.AccountId,
                        RoleId = p28.RoleId,
                        Role = p28.Role == null ? null : new RoleDto()
                        {
                            Name = p28.Role.Name,
                            Description = p28.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p28.Role.Visibility),
                            Id = p28.Role.Id,
                            CreatedOn = p28.Role.CreatedOn,
                            UpdatedOn = p28.Role.UpdatedOn,
                            DeletedAt = p28.Role.DeletedAt
                        },
                        Id = p28.Id,
                        CreatedOn = p28.CreatedOn,
                        UpdatedOn = p28.UpdatedOn,
                        DeletedAt = p28.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    ExternalLogins = p25.Garden.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p29 => new AccountExternalLoginsDto()
                    {
                        AccountId = p29.AccountId,
                        DisplayName = p29.DisplayName,
                        ObjectIdAzureAd = p29.ObjectIdAzureAd,
                        IdentityProvider = p29.IdentityProvider,
                        ProfilePictureUrl = p29.ProfilePictureUrl,
                        Id = p29.Id,
                        CreatedOn = p29.CreatedOn,
                        UpdatedOn = p29.UpdatedOn,
                        DeletedAt = p29.DeletedAt
                    }).ToList<AccountExternalLoginsDto>(),
                    Id = p25.Garden.Account.Id,
                    CreatedOn = p25.Garden.Account.CreatedOn,
                    UpdatedOn = p25.Garden.Account.UpdatedOn,
                    DeletedAt = p25.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p25.Garden.Visibility),
                Id = p25.Garden.Id,
                CreatedOn = p25.Garden.CreatedOn,
                UpdatedOn = p25.Garden.UpdatedOn,
                DeletedAt = p25.Garden.DeletedAt
            },
            Id = p25.Id,
            CreatedOn = p25.CreatedOn,
            UpdatedOn = p25.UpdatedOn,
            DeletedAt = p25.DeletedAt
        };
        public static FlowerList AdaptToList(this Flower p30)
        {
            return p30 == null ? null : new FlowerList()
            {
                Name = p30.Name,
                Visibility = Enum<Visibility>.ToString(p30.Visibility),
                AccountId = p30.AccountId,
                Account = p30.Account == null ? null : new AccountList()
                {
                    Email = p30.Account.Email,
                    Username = p30.Account.Username,
                    DisplayName = p30.Account.DisplayName,
                    ProfileIntroduction = p30.Account.ProfileIntroduction,
                    ProfilePicure = p30.Account.ProfilePicure,
                    Id = p30.Account.Id,
                    CreatedOn = p30.Account.CreatedOn
                },
                GardenId = p30.GardenId,
                Garden = p30.Garden == null ? null : new GardenList()
                {
                    Name = p30.Garden.Name,
                    AccountId = p30.Garden.AccountId,
                    Account = p30.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p30.Garden.Account.Email,
                        Username = p30.Garden.Account.Username,
                        DisplayName = p30.Garden.Account.DisplayName,
                        ProfileIntroduction = p30.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p30.Garden.Account.ProfilePicure,
                        Id = p30.Garden.Account.Id,
                        CreatedOn = p30.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p30.Garden.Visibility),
                    Id = p30.Garden.Id,
                    CreatedOn = p30.Garden.CreatedOn
                },
                Id = p30.Id,
                CreatedOn = p30.CreatedOn
            };
        }
        public static FlowerList AdaptTo(this Flower p31, FlowerList p32)
        {
            if (p31 == null)
            {
                return null;
            }
            FlowerList result = p32 ?? new FlowerList();
            
            result.Name = p31.Name;
            result.Visibility = Enum<Visibility>.ToString(p31.Visibility);
            result.AccountId = p31.AccountId;
            result.Account = funcMain15(p31.Account, result.Account);
            result.GardenId = p31.GardenId;
            result.Garden = funcMain16(p31.Garden, result.Garden);
            result.Id = p31.Id;
            result.CreatedOn = p31.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerList>> ProjectToList => p39 => new FlowerList()
        {
            Name = p39.Name,
            Visibility = Enum<Visibility>.ToString(p39.Visibility),
            AccountId = p39.AccountId,
            Account = p39.Account == null ? null : new AccountList()
            {
                Email = p39.Account.Email,
                Username = p39.Account.Username,
                DisplayName = p39.Account.DisplayName,
                ProfileIntroduction = p39.Account.ProfileIntroduction,
                ProfilePicure = p39.Account.ProfilePicure,
                Id = p39.Account.Id,
                CreatedOn = p39.Account.CreatedOn
            },
            GardenId = p39.GardenId,
            Garden = p39.Garden == null ? null : new GardenList()
            {
                Name = p39.Garden.Name,
                AccountId = p39.Garden.AccountId,
                Account = p39.Garden.Account == null ? null : new AccountList()
                {
                    Email = p39.Garden.Account.Email,
                    Username = p39.Garden.Account.Username,
                    DisplayName = p39.Garden.Account.DisplayName,
                    ProfileIntroduction = p39.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p39.Garden.Account.ProfilePicure,
                    Id = p39.Garden.Account.Id,
                    CreatedOn = p39.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p39.Garden.Visibility),
                Id = p39.Garden.Id,
                CreatedOn = p39.Garden.CreatedOn
            },
            Id = p39.Id,
            CreatedOn = p39.CreatedOn
        };
        public static Flower AdaptToFlower(this FlowerAdd p40)
        {
            return p40 == null ? null : new Flower()
            {
                Name = p40.Name,
                Visibility = p40.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p40.Visibility),
                AccountId = p40.AccountId
            };
        }
        public static Flower AdaptTo(this FlowerMerge p41, Flower p42)
        {
            if (p41 == null)
            {
                return null;
            }
            Flower result = p42 ?? new Flower();
            
            if (p41.Name != null)
            {
                result.Name = p41.Name;
            }
            
            if (p41.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p41.Visibility);
            }
            
            if (p41.AccountId != null)
            {
                result.AccountId = (Guid)p41.AccountId;
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
        
        private static GardenDto funcMain4(Garden p5)
        {
            return p5 == null ? null : new GardenDto()
            {
                Name = p5.Name,
                AccountId = p5.AccountId,
                Account = funcMain5(p5.Account),
                Visibility = Enum<Visibility>.ToString(p5.Visibility),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn,
                DeletedAt = p5.DeletedAt
            };
        }
        
        private static AccountDto funcMain8(Account p11, AccountDto p12)
        {
            if (p11 == null)
            {
                return null;
            }
            AccountDto result = p12 ?? new AccountDto();
            
            result.Email = p11.Email;
            result.Username = p11.Username;
            result.DisplayName = p11.DisplayName;
            result.ProfileIntroduction = p11.ProfileIntroduction;
            result.ProfilePicure = p11.ProfilePicure;
            result.Roles = funcMain9(p11.Roles, result.Roles);
            result.ExternalLogins = funcMain10(p11.ExternalLogins, result.ExternalLogins);
            result.Id = p11.Id;
            result.CreatedOn = p11.CreatedOn;
            result.UpdatedOn = p11.UpdatedOn;
            result.DeletedAt = p11.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain11(Garden p17, GardenDto p18)
        {
            if (p17 == null)
            {
                return null;
            }
            GardenDto result = p18 ?? new GardenDto();
            
            result.Name = p17.Name;
            result.AccountId = p17.AccountId;
            result.Account = funcMain12(p17.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p17.Visibility);
            result.Id = p17.Id;
            result.CreatedOn = p17.CreatedOn;
            result.UpdatedOn = p17.UpdatedOn;
            result.DeletedAt = p17.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain15(Account p33, AccountList p34)
        {
            if (p33 == null)
            {
                return null;
            }
            AccountList result = p34 ?? new AccountList();
            
            result.Email = p33.Email;
            result.Username = p33.Username;
            result.DisplayName = p33.DisplayName;
            result.ProfileIntroduction = p33.ProfileIntroduction;
            result.ProfilePicure = p33.ProfilePicure;
            result.Id = p33.Id;
            result.CreatedOn = p33.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain16(Garden p35, GardenList p36)
        {
            if (p35 == null)
            {
                return null;
            }
            GardenList result = p36 ?? new GardenList();
            
            result.Name = p35.Name;
            result.AccountId = p35.AccountId;
            result.Account = funcMain17(p35.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p35.Visibility);
            result.Id = p35.Id;
            result.CreatedOn = p35.CreatedOn;
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
        
        private static AccountDto funcMain5(Account p6)
        {
            return p6 == null ? null : new AccountDto()
            {
                Email = p6.Email,
                Username = p6.Username,
                DisplayName = p6.DisplayName,
                ProfileIntroduction = p6.ProfileIntroduction,
                ProfilePicure = p6.ProfilePicure,
                Roles = funcMain6(p6.Roles),
                ExternalLogins = funcMain7(p6.ExternalLogins),
                Id = p6.Id,
                CreatedOn = p6.CreatedOn,
                UpdatedOn = p6.UpdatedOn,
                DeletedAt = p6.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain9(ICollection<AccountRoles> p13, ICollection<AccountRolesDto> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p13.Count);
            
            IEnumerator<AccountRoles> enumerator = p13.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain10(ICollection<AccountExternalLogins> p15, ICollection<AccountExternalLoginsDto> p16)
        {
            if (p15 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p15.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p15.GetEnumerator();
            
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
        
        private static AccountDto funcMain12(Account p19, AccountDto p20)
        {
            if (p19 == null)
            {
                return null;
            }
            AccountDto result = p20 ?? new AccountDto();
            
            result.Email = p19.Email;
            result.Username = p19.Username;
            result.DisplayName = p19.DisplayName;
            result.ProfileIntroduction = p19.ProfileIntroduction;
            result.ProfilePicure = p19.ProfilePicure;
            result.Roles = funcMain13(p19.Roles, result.Roles);
            result.ExternalLogins = funcMain14(p19.ExternalLogins, result.ExternalLogins);
            result.Id = p19.Id;
            result.CreatedOn = p19.CreatedOn;
            result.UpdatedOn = p19.UpdatedOn;
            result.DeletedAt = p19.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain17(Account p37, AccountList p38)
        {
            if (p37 == null)
            {
                return null;
            }
            AccountList result = p38 ?? new AccountList();
            
            result.Email = p37.Email;
            result.Username = p37.Username;
            result.DisplayName = p37.DisplayName;
            result.ProfileIntroduction = p37.ProfileIntroduction;
            result.ProfilePicure = p37.ProfilePicure;
            result.Id = p37.Id;
            result.CreatedOn = p37.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain6(ICollection<AccountRoles> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p7.Count);
            
            IEnumerator<AccountRoles> enumerator = p7.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain7(ICollection<AccountExternalLogins> p8)
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
        
        private static ICollection<AccountRolesDto> funcMain13(ICollection<AccountRoles> p21, ICollection<AccountRolesDto> p22)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p21.Count);
            
            IEnumerator<AccountRoles> enumerator = p21.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain14(ICollection<AccountExternalLogins> p23, ICollection<AccountExternalLoginsDto> p24)
        {
            if (p23 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p23.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p23.GetEnumerator();
            
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