using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.Entities.Enums;
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
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
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
            result.Visibility = Enum<Visibility>.ToString(p2.Visibility);
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
            Visibility = Enum<Visibility>.ToString(p4.Visibility),
            Id = p4.Id,
            CreatedFrom = p4.CreatedFrom,
            CreatedOn = p4.CreatedOn,
            UpdatedFrom = p4.UpdatedFrom,
            UpdatedOn = p4.UpdatedOn,
            DeletedFrom = p4.DeletedFrom,
            DeletedAt = p4.DeletedAt
        };
        public static PostList AdaptToList(this Post p5)
        {
            return p5 == null ? null : new PostList()
            {
                AccountId = p5.AccountId,
                Title = p5.Title,
                Content = p5.Content,
                LinkOrImageUrl = p5.LinkOrImageUrl,
                PostType = Enum<PostType>.ToString(p5.PostType),
                Visibility = Enum<Visibility>.ToString(p5.Visibility)
            };
        }
        public static PostList AdaptTo(this Post p6, PostList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            PostList result = p7 ?? new PostList();
            
            result.AccountId = p6.AccountId;
            result.Title = p6.Title;
            result.Content = p6.Content;
            result.LinkOrImageUrl = p6.LinkOrImageUrl;
            result.PostType = Enum<PostType>.ToString(p6.PostType);
            result.Visibility = Enum<Visibility>.ToString(p6.Visibility);
            return result;
            
        }
        public static Expression<Func<Post, PostList>> ProjectToList => p8 => new PostList()
        {
            AccountId = p8.AccountId,
            Title = p8.Title,
            Content = p8.Content,
            LinkOrImageUrl = p8.LinkOrImageUrl,
            PostType = Enum<PostType>.ToString(p8.PostType),
            Visibility = Enum<Visibility>.ToString(p8.Visibility)
        };
        public static Post AdaptToPost(this PostAdd p9)
        {
            return p9 == null ? null : new Post()
            {
                AccountId = p9.AccountId,
                Title = p9.Title,
                Content = p9.Content,
                LinkOrImageUrl = p9.LinkOrImageUrl,
                PostType = p9.PostType == null ? PostType.Text : Enum<PostType>.Parse(p9.PostType),
                Visibility = p9.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p9.Visibility)
            };
        }
        public static Post AdaptTo(this PostMerge p10, Post p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Post result = p11 ?? new Post();
            
            if (p10.AccountId != null)
            {
                result.AccountId = (Guid)p10.AccountId;
            }
            
            if (p10.Title != null)
            {
                result.Title = p10.Title;
            }
            
            if (p10.Content != null)
            {
                result.Content = p10.Content;
            }
            
            if (p10.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p10.LinkOrImageUrl;
            }
            
            if (p10.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p10.PostType);
            }
            
            if (p10.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p10.Visibility);
            }
            return result;
            
        }
    }
}