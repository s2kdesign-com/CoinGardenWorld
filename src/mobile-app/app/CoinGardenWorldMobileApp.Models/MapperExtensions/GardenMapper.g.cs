using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

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
                Flowers = funcMain3(p1.Flowers),
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
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
            result.Flowers = funcMain6(p5.Flowers, result.Flowers);
            result.Id = p5.Id;
            result.CreatedFrom = p5.CreatedFrom;
            result.CreatedOn = p5.CreatedOn;
            result.UpdatedFrom = p5.UpdatedFrom;
            result.UpdatedOn = p5.UpdatedOn;
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
                Roles = p13.Account.Roles.Select<AccountRoles, AccountRolesDto>(p14 => new AccountRolesDto()
                {
                    AccountId = p14.AccountId,
                    RoleId = p14.RoleId,
                    Role = p14.Role == null ? null : new RoleDto()
                    {
                        Name = p14.Role.Name,
                        Description = p14.Role.Description,
                        Id = p14.Role.Id,
                        CreatedFrom = p14.Role.CreatedFrom,
                        CreatedOn = p14.Role.CreatedOn,
                        UpdatedFrom = p14.Role.UpdatedFrom,
                        UpdatedOn = p14.Role.UpdatedOn
                    },
                    Id = p14.Id,
                    CreatedFrom = p14.CreatedFrom,
                    CreatedOn = p14.CreatedOn,
                    UpdatedFrom = p14.UpdatedFrom,
                    UpdatedOn = p14.UpdatedOn
                }).ToList<AccountRolesDto>(),
                Id = p13.Account.Id,
                CreatedFrom = p13.Account.CreatedFrom,
                CreatedOn = p13.Account.CreatedOn,
                UpdatedFrom = p13.Account.UpdatedFrom,
                UpdatedOn = p13.Account.UpdatedOn
            },
            Flowers = p13.Flowers.Select<Flower, FlowerDto>(p15 => new FlowerDto()
            {
                Name = p15.Name,
                GardenId = p15.GardenId,
                Id = p15.Id,
                CreatedFrom = p15.CreatedFrom,
                CreatedOn = p15.CreatedOn,
                UpdatedFrom = p15.UpdatedFrom,
                UpdatedOn = p15.UpdatedOn
            }).ToList<FlowerDto>(),
            Id = p13.Id,
            CreatedFrom = p13.CreatedFrom,
            CreatedOn = p13.CreatedOn,
            UpdatedFrom = p13.UpdatedFrom,
            UpdatedOn = p13.UpdatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p16)
        {
            return p16 == null ? null : new Garden()
            {
                Name = p16.Name,
                AccountId = p16.AccountId,
                Account = funcMain7(p16.Account),
                Flowers = funcMain9(p16.Flowers)
            };
        }
        public static Garden AdaptTo(this GardenMerge p20, Garden p21)
        {
            if (p20 == null)
            {
                return null;
            }
            Garden result = p21 ?? new Garden();
            
            if (p20.Name != null)
            {
                result.Name = p20.Name;
            }
            
            if (p20.AccountId != null)
            {
                result.AccountId = (Guid)p20.AccountId;
            }
            
            if (p20.Account != null)
            {
                result.Account = funcMain10(p20.Account, result.Account);
            }
            
            if (p20.Flowers != null)
            {
                result.Flowers = funcMain14(p20.Flowers, result.Flowers);
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
                Roles = funcMain2(p2.Roles),
                Id = p2.Id,
                CreatedFrom = p2.CreatedFrom,
                CreatedOn = p2.CreatedOn,
                UpdatedFrom = p2.UpdatedFrom,
                UpdatedOn = p2.UpdatedOn
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
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn
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
            result.Roles = funcMain5(p7.Roles, result.Roles);
            result.Id = p7.Id;
            result.CreatedFrom = p7.CreatedFrom;
            result.CreatedOn = p7.CreatedOn;
            result.UpdatedFrom = p7.UpdatedFrom;
            result.UpdatedOn = p7.UpdatedOn;
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
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedFrom = item.CreatedFrom,
                    CreatedOn = item.CreatedOn,
                    UpdatedFrom = item.UpdatedFrom,
                    UpdatedOn = item.UpdatedOn
                });
            }
            return result;
            
        }
        
        private static Account funcMain7(AccountAdd p17)
        {
            return p17 == null ? null : new Account()
            {
                Email = p17.Email,
                Username = p17.Username,
                DisplayName = p17.DisplayName,
                ProfileIntroduction = p17.ProfileIntroduction,
                ProfilePicure = p17.ProfilePicure,
                UserObjectIdAzureAd = p17.UserObjectIdAzureAd,
                Roles = funcMain8(p17.Roles)
            };
        }
        
        private static ICollection<Flower> funcMain9(ICollection<FlowerAdd> p19)
        {
            if (p19 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p19.Count);
            
            IEnumerator<FlowerAdd> enumerator = p19.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerAdd item = enumerator.Current;
                result.Add(item == null ? null : new Flower()
                {
                    Name = item.Name,
                    GardenId = item.GardenId
                });
            }
            return result;
            
        }
        
        private static Account funcMain10(AccountMerge p22, Account p23)
        {
            if (p22 == null)
            {
                return null;
            }
            Account result = p23 ?? new Account();
            
            if (p22.Email != null)
            {
                result.Email = p22.Email;
            }
            
            if (p22.Username != null)
            {
                result.Username = p22.Username;
            }
            
            if (p22.DisplayName != null)
            {
                result.DisplayName = p22.DisplayName;
            }
            
            if (p22.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p22.ProfileIntroduction;
            }
            
            if (p22.ProfilePicure != null)
            {
                result.ProfilePicure = p22.ProfilePicure;
            }
            
            if (p22.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p22.UserObjectIdAzureAd;
            }
            
            if (p22.Roles != null)
            {
                result.Roles = funcMain11(p22.Roles, result.Roles);
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain14(ICollection<FlowerMerge> p28, ICollection<Flower> p29)
        {
            if (p28 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p28.Count);
            
            IEnumerator<FlowerMerge> enumerator = p28.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerMerge item = enumerator.Current;
                result.Add(funcMain15(item));
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
        
        private static ICollection<AccountRoles> funcMain8(ICollection<AccountRolesAdd> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            ICollection<AccountRoles> result = new List<AccountRoles>(p18.Count);
            
            IEnumerator<AccountRolesAdd> enumerator = p18.GetEnumerator();
            
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
        
        private static ICollection<AccountRoles> funcMain11(ICollection<AccountRolesMerge> p24, ICollection<AccountRoles> p25)
        {
            if (p24 == null)
            {
                return null;
            }
            ICollection<AccountRoles> result = new List<AccountRoles>(p24.Count);
            
            IEnumerator<AccountRolesMerge> enumerator = p24.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRolesMerge item = enumerator.Current;
                result.Add(funcMain12(item));
            }
            return result;
            
        }
        
        private static Flower funcMain15(FlowerMerge p30)
        {
            if (p30 == null)
            {
                return null;
            }
            Flower result = new Flower();
            
            if (p30.Name != null)
            {
                result.Name = p30.Name;
            }
            
            if (p30.GardenId != null)
            {
                result.GardenId = (Guid)p30.GardenId;
            }
            return result;
            
        }
        
        private static AccountRoles funcMain12(AccountRolesMerge p26)
        {
            if (p26 == null)
            {
                return null;
            }
            AccountRoles result = new AccountRoles();
            
            if (p26.AccountId != null)
            {
                result.AccountId = (Guid)p26.AccountId;
            }
            
            if (p26.RoleId != null)
            {
                result.RoleId = (Guid)p26.RoleId;
            }
            
            if (p26.Role != null)
            {
                result.Role = funcMain13(p26.Role);
            }
            return result;
            
        }
        
        private static Role funcMain13(RoleMerge p27)
        {
            if (p27 == null)
            {
                return null;
            }
            Role result = new Role();
            
            if (p27.Name != null)
            {
                result.Name = p27.Name;
            }
            
            if (p27.Description != null)
            {
                result.Description = p27.Description;
            }
            return result;
            
        }
    }
}