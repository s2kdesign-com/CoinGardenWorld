using System;
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
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static AccountDto AdaptTo(this Account p2, AccountDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountDto result = p3 ?? new AccountDto();
            
            result.Email = p2.Email;
            result.Username = p2.Username;
            result.DisplayName = p2.DisplayName;
            result.ProfileIntroduction = p2.ProfileIntroduction;
            result.ProfilePicure = p2.ProfilePicure;
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Account, AccountDto>> ProjectToDto => p4 => new AccountDto()
        {
            Email = p4.Email,
            Username = p4.Username,
            DisplayName = p4.DisplayName,
            ProfileIntroduction = p4.ProfileIntroduction,
            ProfilePicure = p4.ProfilePicure,
            Id = p4.Id,
            CreatedOn = p4.CreatedOn,
            UpdatedOn = p4.UpdatedOn
        };
        public static Account AdaptToAccount(this AccountAdd p5)
        {
            return p5 == null ? null : new Account()
            {
                Email = p5.Email,
                Username = p5.Username,
                DisplayName = p5.DisplayName,
                ProfileIntroduction = p5.ProfileIntroduction,
                ProfilePicure = p5.ProfilePicure,
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn
            };
        }
        public static Account AdaptTo(this AccountUpdate p6, Account p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Account result = p7 ?? new Account();
            
            result.Email = p6.Email;
            result.Username = p6.Username;
            result.DisplayName = p6.DisplayName;
            result.ProfileIntroduction = p6.ProfileIntroduction;
            result.ProfilePicure = p6.ProfilePicure;
            result.CreatedOn = p6.CreatedOn;
            result.UpdatedOn = p6.UpdatedOn;
            return result;
            
        }
        public static Account AdaptTo(this AccountMerge p8, Account p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Account result = p9 ?? new Account();
            
            if (p8.Email != null)
            {
                result.Email = p8.Email;
            }
            
            if (p8.Username != null)
            {
                result.Username = p8.Username;
            }
            
            if (p8.DisplayName != null)
            {
                result.DisplayName = p8.DisplayName;
            }
            
            if (p8.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p8.ProfileIntroduction;
            }
            
            if (p8.ProfilePicure != null)
            {
                result.ProfilePicure = p8.ProfilePicure;
            }
            
            if (p8.CreatedOn != null)
            {
                result.CreatedOn = (DateTime)p8.CreatedOn;
            }
            
            if (p8.UpdatedOn != null)
            {
                result.UpdatedOn = p8.UpdatedOn;
            }
            return result;
            
        }
    }
}