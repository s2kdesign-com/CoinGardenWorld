using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class PostMapper
    {
        public static PostDto AdaptToDto(this Post p1)
        {
            return p1 == null ? null : new PostDto()
            {
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
                Title = p1.Title,
                Content = p1.Content,
                LinkOrImageUrl = p1.LinkOrImageUrl,
                PostType = Enum<PostType>.ToString(p1.PostType),
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static PostDto AdaptTo(this Post p2, PostDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PostDto result = p3 ?? new PostDto();
            
            result.AccountId = p2.AccountId;
            result.Account = funcMain1(p2.Account, result.Account);
            result.Title = p2.Title;
            result.Content = p2.Content;
            result.LinkOrImageUrl = p2.LinkOrImageUrl;
            result.PostType = Enum<PostType>.ToString(p2.PostType);
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p6 => new PostDto()
        {
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
            Title = p6.Title,
            Content = p6.Content,
            LinkOrImageUrl = p6.LinkOrImageUrl,
            PostType = Enum<PostType>.ToString(p6.PostType),
            Id = p6.Id,
            CreatedFrom = p6.CreatedFrom,
            CreatedOn = p6.CreatedOn,
            UpdatedFrom = p6.UpdatedFrom,
            UpdatedOn = p6.UpdatedOn
        };
        public static Post AdaptToPost(this PostAdd p7)
        {
            return p7 == null ? null : new Post()
            {
                AccountId = p7.AccountId,
                Account = p7.Account == null ? null : new Account()
                {
                    Email = p7.Account.Email,
                    Username = p7.Account.Username,
                    DisplayName = p7.Account.DisplayName,
                    ProfileIntroduction = p7.Account.ProfileIntroduction,
                    ProfilePicure = p7.Account.ProfilePicure
                },
                Title = p7.Title,
                Content = p7.Content,
                LinkOrImageUrl = p7.LinkOrImageUrl,
                PostType = p7.PostType == null ? PostType.Text : Enum<PostType>.Parse(p7.PostType)
            };
        }
        public static Post AdaptTo(this PostUpdate p8, Post p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Post result = p9 ?? new Post();
            
            result.AccountId = p8.AccountId;
            result.Account = funcMain2(p8.Account, result.Account);
            result.Title = p8.Title;
            result.Content = p8.Content;
            result.LinkOrImageUrl = p8.LinkOrImageUrl;
            result.PostType = p8.PostType == null ? PostType.Text : Enum<PostType>.Parse(p8.PostType);
            return result;
            
        }
        public static Post AdaptTo(this PostMerge p12, Post p13)
        {
            if (p12 == null)
            {
                return null;
            }
            Post result = p13 ?? new Post();
            
            if (p12.AccountId != null)
            {
                result.AccountId = (Guid)p12.AccountId;
            }
            
            if (p12.Account != null)
            {
                result.Account = funcMain3(p12.Account, result.Account);
            }
            
            if (p12.Title != null)
            {
                result.Title = p12.Title;
            }
            
            if (p12.Content != null)
            {
                result.Content = p12.Content;
            }
            
            if (p12.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p12.LinkOrImageUrl;
            }
            
            if (p12.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p12.PostType);
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