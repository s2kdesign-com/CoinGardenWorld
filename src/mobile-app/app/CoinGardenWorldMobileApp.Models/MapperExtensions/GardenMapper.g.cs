using System;
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
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static GardenDto AdaptTo(this Garden p2, GardenDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            GardenDto result = p3 ?? new GardenDto();
            
            result.Name = p2.Name;
            result.AccountId = p2.AccountId;
            result.Account = funcMain1(p2.Account, result.Account);
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenDto>> ProjectToDto => p6 => new GardenDto()
        {
            Name = p6.Name,
            AccountId = p6.AccountId,
            Account = p6.Account == null ? null : new AccountDto()
            {
                Email = p6.Account.Email,
                Username = p6.Account.Username,
                DisplayName = p6.Account.DisplayName,
                ProfileIntroduction = p6.Account.ProfileIntroduction,
                ProfilePicure = p6.Account.ProfilePicure,
                Id = p6.Account.Id,
                CreatedFrom = p6.Account.CreatedFrom,
                CreatedOn = p6.Account.CreatedOn,
                UpdatedFrom = p6.Account.UpdatedFrom,
                UpdatedOn = p6.Account.UpdatedOn
            },
            Id = p6.Id,
            CreatedFrom = p6.CreatedFrom,
            CreatedOn = p6.CreatedOn,
            UpdatedFrom = p6.UpdatedFrom,
            UpdatedOn = p6.UpdatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p7)
        {
            return p7 == null ? null : new Garden()
            {
                Name = p7.Name,
                AccountId = p7.AccountId,
                Account = p7.Account == null ? null : new Account()
                {
                    Email = p7.Account.Email,
                    Username = p7.Account.Username,
                    DisplayName = p7.Account.DisplayName,
                    ProfileIntroduction = p7.Account.ProfileIntroduction,
                    ProfilePicure = p7.Account.ProfilePicure
                }
            };
        }
        public static Garden AdaptTo(this GardenUpdate p8, Garden p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Garden result = p9 ?? new Garden();
            
            result.Name = p8.Name;
            result.AccountId = p8.AccountId;
            result.Account = funcMain2(p8.Account, result.Account);
            return result;
            
        }
        public static Garden AdaptTo(this GardenMerge p12, Garden p13)
        {
            if (p12 == null)
            {
                return null;
            }
            Garden result = p13 ?? new Garden();
            
            if (p12.Name != null)
            {
                result.Name = p12.Name;
            }
            
            if (p12.AccountId != null)
            {
                result.AccountId = (Guid)p12.AccountId;
            }
            
            if (p12.Account != null)
            {
                result.Account = funcMain3(p12.Account, result.Account);
            }
            return result;
            
        }
        
        private static AccountDto funcMain1(Account p4, AccountDto p5)
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
            result.Id = p4.Id;
            result.CreatedFrom = p4.CreatedFrom;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedFrom = p4.UpdatedFrom;
            result.UpdatedOn = p4.UpdatedOn;
            return result;
            
        }
        
        private static Account funcMain2(AccountUpdate p10, Account p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Account result = p11 ?? new Account();
            
            result.Email = p10.Email;
            result.Username = p10.Username;
            result.DisplayName = p10.DisplayName;
            result.ProfileIntroduction = p10.ProfileIntroduction;
            result.ProfilePicure = p10.ProfilePicure;
            return result;
            
        }
        
        private static Account funcMain3(AccountMerge p14, Account p15)
        {
            if (p14 == null)
            {
                return null;
            }
            Account result = p15 ?? new Account();
            
            if (p14.Email != null)
            {
                result.Email = p14.Email;
            }
            
            if (p14.Username != null)
            {
                result.Username = p14.Username;
            }
            
            if (p14.DisplayName != null)
            {
                result.DisplayName = p14.DisplayName;
            }
            
            if (p14.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p14.ProfileIntroduction;
            }
            
            if (p14.ProfilePicure != null)
            {
                result.ProfilePicure = p14.ProfilePicure;
            }
            return result;
            
        }
    }
}