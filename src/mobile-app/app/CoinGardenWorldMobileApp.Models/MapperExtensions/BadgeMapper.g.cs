using System;
using System.Linq.Expressions;
using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class BadgeMapper
    {
        public static BadgeDto AdaptToDto(this Badge p1)
        {
            return p1 == null ? null : new BadgeDto()
            {
                Name = p1.Name,
                Description = p1.Description,
                BadgeType = Enum<BadgeTypes>.ToString(p1.BadgeType),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static BadgeDto AdaptTo(this Badge p2, BadgeDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            BadgeDto result = p3 ?? new BadgeDto();
            
            result.Name = p2.Name;
            result.Description = p2.Description;
            result.BadgeType = Enum<BadgeTypes>.ToString(p2.BadgeType);
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Badge, BadgeDto>> ProjectToDto => p4 => new BadgeDto()
        {
            Name = p4.Name,
            Description = p4.Description,
            BadgeType = Enum<BadgeTypes>.ToString(p4.BadgeType),
            Id = p4.Id,
            CreatedOn = p4.CreatedOn,
            UpdatedOn = p4.UpdatedOn,
            DeletedAt = p4.DeletedAt
        };
        public static BadgeList AdaptToList(this Badge p5)
        {
            return p5 == null ? null : new BadgeList()
            {
                Name = p5.Name,
                Description = p5.Description,
                BadgeType = Enum<BadgeTypes>.ToString(p5.BadgeType),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn
            };
        }
        public static BadgeList AdaptTo(this Badge p6, BadgeList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            BadgeList result = p7 ?? new BadgeList();
            
            result.Name = p6.Name;
            result.Description = p6.Description;
            result.BadgeType = Enum<BadgeTypes>.ToString(p6.BadgeType);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Badge, BadgeList>> ProjectToList => p8 => new BadgeList()
        {
            Name = p8.Name,
            Description = p8.Description,
            BadgeType = Enum<BadgeTypes>.ToString(p8.BadgeType),
            Id = p8.Id,
            CreatedOn = p8.CreatedOn
        };
        public static Badge AdaptToBadge(this BadgeAdd p9)
        {
            return p9 == null ? null : new Badge()
            {
                Name = p9.Name,
                Description = p9.Description,
                BadgeType = p9.BadgeType == null ? BadgeTypes.BasedOnTimeRegistered : Enum<BadgeTypes>.Parse(p9.BadgeType)
            };
        }
        public static Badge AdaptTo(this BadgeMerge p10, Badge p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Badge result = p11 ?? new Badge();
            
            if (p10.Name != null)
            {
                result.Name = p10.Name;
            }
            
            if (p10.Description != null)
            {
                result.Description = p10.Description;
            }
            
            if (p10.BadgeType != null)
            {
                result.BadgeType = Enum<BadgeTypes>.Parse(p10.BadgeType);
            }
            return result;
            
        }
    }
}