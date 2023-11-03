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
                Title = p1.Title,
                Content = p1.Content,
                LinkOrImageUrl = p1.LinkOrImageUrl,
                PostType = Enum<PostType>.ToString(p1.PostType),
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn,
                DeletedFrom = p1.DeletedFrom,
                DeletedAt = p1.DeletedAt
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
            result.Title = p2.Title;
            result.Content = p2.Content;
            result.LinkOrImageUrl = p2.LinkOrImageUrl;
            result.PostType = Enum<PostType>.ToString(p2.PostType);
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedFrom = p2.DeletedFrom;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p4 => new PostDto()
        {
            AccountId = p4.AccountId,
            Title = p4.Title,
            Content = p4.Content,
            LinkOrImageUrl = p4.LinkOrImageUrl,
            PostType = Enum<PostType>.ToString(p4.PostType),
            Id = p4.Id,
            CreatedFrom = p4.CreatedFrom,
            CreatedOn = p4.CreatedOn,
            UpdatedFrom = p4.UpdatedFrom,
            UpdatedOn = p4.UpdatedOn,
            DeletedFrom = p4.DeletedFrom,
            DeletedAt = p4.DeletedAt
        };
        public static Post AdaptToPost(this PostAdd p5)
        {
            return p5 == null ? null : new Post()
            {
                AccountId = p5.AccountId,
                Title = p5.Title,
                Content = p5.Content,
                LinkOrImageUrl = p5.LinkOrImageUrl,
                PostType = p5.PostType == null ? PostType.Text : Enum<PostType>.Parse(p5.PostType)
            };
        }
        public static Post AdaptTo(this PostMerge p6, Post p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Post result = p7 ?? new Post();
            
            if (p6.AccountId != null)
            {
                result.AccountId = (Guid)p6.AccountId;
            }
            
            if (p6.Title != null)
            {
                result.Title = p6.Title;
            }
            
            if (p6.Content != null)
            {
                result.Content = p6.Content;
            }
            
            if (p6.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p6.LinkOrImageUrl;
            }
            
            if (p6.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p6.PostType);
            }
            return result;
            
        }
    }
}