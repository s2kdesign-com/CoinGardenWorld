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
                Flowers = funcMain3(p1.Flowers),
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
            result.Flowers = funcMain6(p5.Flowers, result.Flowers);
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
                UserObjectIdAzureAd = p13.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p13.Account.UserIdentityProvider,
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
                Id = p13.Account.Id,
                CreatedOn = p13.Account.CreatedOn,
                UpdatedOn = p13.Account.UpdatedOn,
                DeletedAt = p13.Account.DeletedAt
            },
            Visibility = Enum<Visibility>.ToString(p13.Visibility),
            Flowers = p13.Flowers.Select<Flower, FlowerDto>(p15 => new FlowerDto()
            {
                Name = p15.Name,
                Visibility = Enum<Visibility>.ToString(p15.Visibility),
                GardenId = p15.GardenId,
                Id = p15.Id,
                CreatedOn = p15.CreatedOn,
                UpdatedOn = p15.UpdatedOn,
                DeletedAt = p15.DeletedAt
            }).ToList<FlowerDto>(),
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
                    UserObjectIdAzureAd = p16.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p16.Account.UserIdentityProvider,
                    Id = p16.Account.Id,
                    CreatedOn = p16.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p16.Visibility),
                Flowers = funcMain7(p16.Flowers),
                Id = p16.Id,
                CreatedOn = p16.CreatedOn
            };
        }
        public static GardenList AdaptTo(this Garden p18, GardenList p19)
        {
            if (p18 == null)
            {
                return null;
            }
            GardenList result = p19 ?? new GardenList();
            
            result.Name = p18.Name;
            result.AccountId = p18.AccountId;
            result.Account = funcMain8(p18.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p18.Visibility);
            result.Flowers = funcMain9(p18.Flowers, result.Flowers);
            result.Id = p18.Id;
            result.CreatedOn = p18.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenList>> ProjectToList => p24 => new GardenList()
        {
            Name = p24.Name,
            AccountId = p24.AccountId,
            Account = p24.Account == null ? null : new AccountList()
            {
                Email = p24.Account.Email,
                Username = p24.Account.Username,
                DisplayName = p24.Account.DisplayName,
                ProfileIntroduction = p24.Account.ProfileIntroduction,
                ProfilePicure = p24.Account.ProfilePicure,
                UserObjectIdAzureAd = p24.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p24.Account.UserIdentityProvider,
                Id = p24.Account.Id,
                CreatedOn = p24.Account.CreatedOn
            },
            Visibility = Enum<Visibility>.ToString(p24.Visibility),
            Flowers = p24.Flowers.Select<Flower, FlowerList>(p25 => new FlowerList()
            {
                Name = p25.Name,
                Visibility = Enum<Visibility>.ToString(p25.Visibility),
                GardenId = p25.GardenId,
                Id = p25.Id,
                CreatedOn = p25.CreatedOn
            }).ToList<FlowerList>(),
            Id = p24.Id,
            CreatedOn = p24.CreatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p26)
        {
            return p26 == null ? null : new Garden()
            {
                Name = p26.Name,
                AccountId = p26.AccountId,
                Account = p26.Account == null ? null : new Account()
                {
                    Email = p26.Account.Email,
                    Username = p26.Account.Username,
                    DisplayName = p26.Account.DisplayName,
                    ProfileIntroduction = p26.Account.ProfileIntroduction,
                    ProfilePicure = p26.Account.ProfilePicure,
                    UserObjectIdAzureAd = p26.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p26.Account.UserIdentityProvider
                },
                Visibility = p26.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p26.Visibility),
                Flowers = funcMain10(p26.Flowers)
            };
        }
        public static Garden AdaptTo(this GardenMerge p28, Garden p29)
        {
            if (p28 == null)
            {
                return null;
            }
            Garden result = p29 ?? new Garden();
            
            if (p28.Name != null)
            {
                result.Name = p28.Name;
            }
            
            if (p28.AccountId != null)
            {
                result.AccountId = (Guid)p28.AccountId;
            }
            
            if (p28.Account != null)
            {
                result.Account = funcMain11(p28.Account, result.Account);
            }
            
            if (p28.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p28.Visibility);
            }
            
            if (p28.Flowers != null)
            {
                result.Flowers = funcMain12(p28.Flowers, result.Flowers);
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
        
        private static ICollection<FlowerDto> funcMain3(ICollection<Flower> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p4.Count);
            
            IEnumerator<Flower> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerDto()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
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
            result.UserObjectIdAzureAd = p7.UserObjectIdAzureAd;
            result.UserIdentityProvider = p7.UserIdentityProvider;
            result.Roles = funcMain5(p7.Roles, result.Roles);
            result.Id = p7.Id;
            result.CreatedOn = p7.CreatedOn;
            result.UpdatedOn = p7.UpdatedOn;
            result.DeletedAt = p7.DeletedAt;
            return result;
            
        }
        
        private static ICollection<FlowerDto> funcMain6(ICollection<Flower> p11, ICollection<FlowerDto> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p11.Count);
            
            IEnumerator<Flower> enumerator = p11.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerDto()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlowerList> funcMain7(ICollection<Flower> p17)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<FlowerList> result = new List<FlowerList>(p17.Count);
            
            IEnumerator<Flower> enumerator = p17.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerList()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn
                });
            }
            return result;
            
        }
        
        private static AccountList funcMain8(Account p20, AccountList p21)
        {
            if (p20 == null)
            {
                return null;
            }
            AccountList result = p21 ?? new AccountList();
            
            result.Email = p20.Email;
            result.Username = p20.Username;
            result.DisplayName = p20.DisplayName;
            result.ProfileIntroduction = p20.ProfileIntroduction;
            result.ProfilePicure = p20.ProfilePicure;
            result.UserObjectIdAzureAd = p20.UserObjectIdAzureAd;
            result.UserIdentityProvider = p20.UserIdentityProvider;
            result.Id = p20.Id;
            result.CreatedOn = p20.CreatedOn;
            return result;
            
        }
        
        private static ICollection<FlowerList> funcMain9(ICollection<Flower> p22, ICollection<FlowerList> p23)
        {
            if (p22 == null)
            {
                return null;
            }
            ICollection<FlowerList> result = new List<FlowerList>(p22.Count);
            
            IEnumerator<Flower> enumerator = p22.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerList()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn
                });
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain10(ICollection<FlowerAdd> p27)
        {
            if (p27 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p27.Count);
            
            IEnumerator<FlowerAdd> enumerator = p27.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerAdd item = enumerator.Current;
                result.Add(item == null ? null : new Flower()
                {
                    Name = item.Name,
                    Visibility = item.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(item.Visibility),
                    GardenId = item.GardenId
                });
            }
            return result;
            
        }
        
        private static Account funcMain11(AccountMerge p30, Account p31)
        {
            if (p30 == null)
            {
                return null;
            }
            Account result = p31 ?? new Account();
            
            if (p30.Email != null)
            {
                result.Email = p30.Email;
            }
            
            if (p30.Username != null)
            {
                result.Username = p30.Username;
            }
            
            if (p30.DisplayName != null)
            {
                result.DisplayName = p30.DisplayName;
            }
            
            if (p30.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p30.ProfileIntroduction;
            }
            
            if (p30.ProfilePicure != null)
            {
                result.ProfilePicure = p30.ProfilePicure;
            }
            
            if (p30.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p30.UserObjectIdAzureAd;
            }
            
            if (p30.UserIdentityProvider != null)
            {
                result.UserIdentityProvider = p30.UserIdentityProvider;
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain12(ICollection<FlowerMerge> p32, ICollection<Flower> p33)
        {
            if (p32 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p32.Count);
            
            IEnumerator<FlowerMerge> enumerator = p32.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerMerge item = enumerator.Current;
                result.Add(funcMain13(item));
            }
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
        
        private static Flower funcMain13(FlowerMerge p34)
        {
            if (p34 == null)
            {
                return null;
            }
            Flower result = new Flower();
            
            if (p34.Name != null)
            {
                result.Name = p34.Name;
            }
            
            if (p34.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p34.Visibility);
            }
            
            if (p34.GardenId != null)
            {
                result.GardenId = p34.GardenId;
            }
            return result;
            
        }
    }
}