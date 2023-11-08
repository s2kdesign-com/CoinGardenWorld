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
                Icon = p1.Icon,
                Color = p1.Color,
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
            result.Icon = p2.Icon;
            result.Color = p2.Color;
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
            Icon = p4.Icon,
            Color = p4.Color,
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
                Icon = p5.Icon,
                Color = p5.Color,
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
            result.Icon = p6.Icon;
            result.Color = p6.Color;
            result.Description = p6.Description;
            result.BadgeType = Enum<BadgeTypes>.ToString(p6.BadgeType);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Badge, BadgeList>> ProjectToList => p8 => new BadgeList()
        {
            Name = p8.Name,
            Icon = p8.Icon,
            Color = p8.Color,
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
                Icon = p9.Icon,
                Color = p9.Color,
                Description = p9.Description,
                BadgeType = p9.BadgeType == null ? BadgeTypes.SpeciallyAssigned : Enum<BadgeTypes>.Parse(p9.BadgeType)
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
            
            if (p10.Icon != null)
            {
                result.Icon = p10.Icon;
            }
            
            if (p10.Color != null)
            {
                result.Color = p10.Color;
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