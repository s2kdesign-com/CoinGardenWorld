using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountExternalLoginsMapper
    {
        public static AccountExternalLoginsDto AdaptToDto(this AccountExternalLogins p1)
        {
            return p1 == null ? null : new AccountExternalLoginsDto()
            {
                AccountId = p1.AccountId,
                DisplayName = p1.DisplayName,
                ObjectIdAzureAd = p1.ObjectIdAzureAd,
                IdentityProvider = p1.IdentityProvider,
                ProfilePictureUrl = p1.ProfilePictureUrl,
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static AccountExternalLoginsDto AdaptTo(this AccountExternalLogins p2, AccountExternalLoginsDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountExternalLoginsDto result = p3 ?? new AccountExternalLoginsDto();
            
            result.AccountId = p2.AccountId;
            result.DisplayName = p2.DisplayName;
            result.ObjectIdAzureAd = p2.ObjectIdAzureAd;
            result.IdentityProvider = p2.IdentityProvider;
            result.ProfilePictureUrl = p2.ProfilePictureUrl;
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<AccountExternalLogins, AccountExternalLoginsDto>> ProjectToDto => p4 => new AccountExternalLoginsDto()
        {
            AccountId = p4.AccountId,
            DisplayName = p4.DisplayName,
            ObjectIdAzureAd = p4.ObjectIdAzureAd,
            IdentityProvider = p4.IdentityProvider,
            ProfilePictureUrl = p4.ProfilePictureUrl,
            Id = p4.Id,
            CreatedOn = p4.CreatedOn,
            UpdatedOn = p4.UpdatedOn,
            DeletedAt = p4.DeletedAt
        };
        public static AccountExternalLoginsList AdaptToList(this AccountExternalLogins p5)
        {
            return p5 == null ? null : new AccountExternalLoginsList()
            {
                AccountId = p5.AccountId,
                DisplayName = p5.DisplayName,
                ObjectIdAzureAd = p5.ObjectIdAzureAd,
                IdentityProvider = p5.IdentityProvider,
                ProfilePictureUrl = p5.ProfilePictureUrl,
                Id = p5.Id,
                CreatedOn = p5.CreatedOn
            };
        }
        public static AccountExternalLoginsList AdaptTo(this AccountExternalLogins p6, AccountExternalLoginsList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            AccountExternalLoginsList result = p7 ?? new AccountExternalLoginsList();
            
            result.AccountId = p6.AccountId;
            result.DisplayName = p6.DisplayName;
            result.ObjectIdAzureAd = p6.ObjectIdAzureAd;
            result.IdentityProvider = p6.IdentityProvider;
            result.ProfilePictureUrl = p6.ProfilePictureUrl;
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            return result;
            
        }
        public static Expression<Func<AccountExternalLogins, AccountExternalLoginsList>> ProjectToList => p8 => new AccountExternalLoginsList()
        {
            AccountId = p8.AccountId,
            DisplayName = p8.DisplayName,
            ObjectIdAzureAd = p8.ObjectIdAzureAd,
            IdentityProvider = p8.IdentityProvider,
            ProfilePictureUrl = p8.ProfilePictureUrl,
            Id = p8.Id,
            CreatedOn = p8.CreatedOn
        };
        public static AccountExternalLogins AdaptToAccountExternalLogins(this AccountExternalLoginsAdd p9)
        {
            return p9 == null ? null : new AccountExternalLogins()
            {
                AccountId = p9.AccountId,
                DisplayName = p9.DisplayName,
                ObjectIdAzureAd = p9.ObjectIdAzureAd,
                IdentityProvider = p9.IdentityProvider,
                ProfilePictureUrl = p9.ProfilePictureUrl
            };
        }
        public static AccountExternalLogins AdaptTo(this AccountExternalLoginsMerge p10, AccountExternalLogins p11)
        {
            if (p10 == null)
            {
                return null;
            }
            AccountExternalLogins result = p11 ?? new AccountExternalLogins();
            
            if (p10.AccountId != null)
            {
                result.AccountId = (Guid)p10.AccountId;
            }
            
            if (p10.DisplayName != null)
            {
                result.DisplayName = p10.DisplayName;
            }
            
            if (p10.ObjectIdAzureAd != null)
            {
                result.ObjectIdAzureAd = p10.ObjectIdAzureAd;
            }
            
            if (p10.IdentityProvider != null)
            {
                result.IdentityProvider = p10.IdentityProvider;
            }
            
            if (p10.ProfilePictureUrl != null)
            {
                result.ProfilePictureUrl = p10.ProfilePictureUrl;
            }
            return result;
            
        }
    }
}