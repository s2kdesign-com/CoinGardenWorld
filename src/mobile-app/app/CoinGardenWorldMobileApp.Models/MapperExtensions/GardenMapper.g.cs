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
                Account = p1.Account == null ? null : new AccountDto()
                {
                    Email = p1.Account.Email,
                    Username = p1.Account.Username,
                    DisplayName = p1.Account.DisplayName,
                    ProfileIntroduction = p1.Account.ProfileIntroduction,
                    ProfilePicure = p1.Account.ProfilePicure,
                    Id = p1.Account.Id,
                    CreatedFrom = p1.Account.CreatedFrom,
                    CreatedOn = p1.Account.CreatedOn,
                    UpdatedFrom = p1.Account.UpdatedFrom,
                    UpdatedOn = p1.Account.UpdatedOn
                },
                Flowers = funcMain1(p1.Flowers),
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static GardenDto AdaptTo(this Garden p3, GardenDto p4)
        {
            if (p3 == null)
            {
                return null;
            }
            GardenDto result = p4 ?? new GardenDto();
            
            result.Name = p3.Name;
            result.AccountId = p3.AccountId;
            result.Account = funcMain2(p3.Account, result.Account);
            result.Flowers = funcMain3(p3.Flowers, result.Flowers);
            result.Id = p3.Id;
            result.CreatedFrom = p3.CreatedFrom;
            result.CreatedOn = p3.CreatedOn;
            result.UpdatedFrom = p3.UpdatedFrom;
            result.UpdatedOn = p3.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenDto>> ProjectToDto => p9 => new GardenDto()
        {
            Name = p9.Name,
            AccountId = p9.AccountId,
            Account = p9.Account == null ? null : new AccountDto()
            {
                Email = p9.Account.Email,
                Username = p9.Account.Username,
                DisplayName = p9.Account.DisplayName,
                ProfileIntroduction = p9.Account.ProfileIntroduction,
                ProfilePicure = p9.Account.ProfilePicure,
                Id = p9.Account.Id,
                CreatedFrom = p9.Account.CreatedFrom,
                CreatedOn = p9.Account.CreatedOn,
                UpdatedFrom = p9.Account.UpdatedFrom,
                UpdatedOn = p9.Account.UpdatedOn
            },
            Flowers = p9.Flowers.Select<Flower, FlowerDto>(p10 => new FlowerDto()
            {
                Name = p10.Name,
                GardenId = p10.GardenId,
                Id = p10.Id,
                CreatedFrom = p10.CreatedFrom,
                CreatedOn = p10.CreatedOn,
                UpdatedFrom = p10.UpdatedFrom,
                UpdatedOn = p10.UpdatedOn
            }).ToList<FlowerDto>(),
            Id = p9.Id,
            CreatedFrom = p9.CreatedFrom,
            CreatedOn = p9.CreatedOn,
            UpdatedFrom = p9.UpdatedFrom,
            UpdatedOn = p9.UpdatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p11)
        {
            return p11 == null ? null : new Garden()
            {
                Name = p11.Name,
                AccountId = p11.AccountId,
                Account = p11.Account == null ? null : new Account()
                {
                    Email = p11.Account.Email,
                    Username = p11.Account.Username,
                    DisplayName = p11.Account.DisplayName,
                    ProfileIntroduction = p11.Account.ProfileIntroduction,
                    ProfilePicure = p11.Account.ProfilePicure
                },
                Flowers = funcMain4(p11.Flowers)
            };
        }
        public static Garden AdaptTo(this GardenMerge p13, Garden p14)
        {
            if (p13 == null)
            {
                return null;
            }
            Garden result = p14 ?? new Garden();
            
            if (p13.Name != null)
            {
                result.Name = p13.Name;
            }
            
            if (p13.AccountId != null)
            {
                result.AccountId = (Guid)p13.AccountId;
            }
            
            if (p13.Account != null)
            {
                result.Account = funcMain5(p13.Account, result.Account);
            }
            
            if (p13.Flowers != null)
            {
                result.Flowers = funcMain6(p13.Flowers, result.Flowers);
            }
            return result;
            
        }
        
        private static ICollection<FlowerDto> funcMain1(ICollection<Flower> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p2.Count);
            
            IEnumerator<Flower> enumerator = p2.GetEnumerator();
            
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
        
        private static AccountDto funcMain2(Account p5, AccountDto p6)
        {
            if (p5 == null)
            {
                return null;
            }
            AccountDto result = p6 ?? new AccountDto();
            
            result.Email = p5.Email;
            result.Username = p5.Username;
            result.DisplayName = p5.DisplayName;
            result.ProfileIntroduction = p5.ProfileIntroduction;
            result.ProfilePicure = p5.ProfilePicure;
            result.Id = p5.Id;
            result.CreatedFrom = p5.CreatedFrom;
            result.CreatedOn = p5.CreatedOn;
            result.UpdatedFrom = p5.UpdatedFrom;
            result.UpdatedOn = p5.UpdatedOn;
            return result;
            
        }
        
        private static ICollection<FlowerDto> funcMain3(ICollection<Flower> p7, ICollection<FlowerDto> p8)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p7.Count);
            
            IEnumerator<Flower> enumerator = p7.GetEnumerator();
            
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
        
        private static ICollection<Flower> funcMain4(ICollection<FlowerAdd> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p12.Count);
            
            IEnumerator<FlowerAdd> enumerator = p12.GetEnumerator();
            
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
        
        private static Account funcMain5(AccountMerge p15, Account p16)
        {
            if (p15 == null)
            {
                return null;
            }
            Account result = p16 ?? new Account();
            
            if (p15.Email != null)
            {
                result.Email = p15.Email;
            }
            
            if (p15.Username != null)
            {
                result.Username = p15.Username;
            }
            
            if (p15.DisplayName != null)
            {
                result.DisplayName = p15.DisplayName;
            }
            
            if (p15.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p15.ProfileIntroduction;
            }
            
            if (p15.ProfilePicure != null)
            {
                result.ProfilePicure = p15.ProfilePicure;
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain6(ICollection<FlowerMerge> p17, ICollection<Flower> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p17.Count);
            
            IEnumerator<FlowerMerge> enumerator = p17.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerMerge item = enumerator.Current;
                result.Add(funcMain7(item));
            }
            return result;
            
        }
        
        private static Flower funcMain7(FlowerMerge p19)
        {
            if (p19 == null)
            {
                return null;
            }
            Flower result = new Flower();
            
            if (p19.Name != null)
            {
                result.Name = p19.Name;
            }
            
            if (p19.GardenId != null)
            {
                result.GardenId = (Guid)p19.GardenId;
            }
            return result;
            
        }
    }
}