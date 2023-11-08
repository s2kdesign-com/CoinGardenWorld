using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountBadgeMapper
    {
        public static AccountBadgeDto AdaptToDto(this AccountBadge p1)
        {
            return p1 == null ? null : new AccountBadgeDto()
            {
                BadgeId = p1.BadgeId,
                BadgeName = p1.BadgeName,
                BadgeIcon = p1.BadgeIcon,
                BadgeColor = p1.BadgeColor,
                EarnedOn = p1.EarnedOn
            };
        }
        public static AccountBadgeDto AdaptTo(this AccountBadge p2, AccountBadgeDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountBadgeDto result = p3 ?? new AccountBadgeDto();
            
            result.BadgeId = p2.BadgeId;
            result.BadgeName = p2.BadgeName;
            result.BadgeIcon = p2.BadgeIcon;
            result.BadgeColor = p2.BadgeColor;
            result.EarnedOn = p2.EarnedOn;
            return result;
            
        }
        public static Expression<Func<AccountBadge, AccountBadgeDto>> ProjectToDto => p4 => new AccountBadgeDto()
        {
            BadgeId = p4.BadgeId,
            BadgeName = p4.BadgeName,
            BadgeIcon = p4.BadgeIcon,
            BadgeColor = p4.BadgeColor,
            EarnedOn = p4.EarnedOn
        };
        public static AccountBadgeList AdaptToList(this AccountBadge p5)
        {
            return p5 == null ? null : new AccountBadgeList()
            {
                BadgeId = p5.BadgeId,
                BadgeName = p5.BadgeName,
                BadgeIcon = p5.BadgeIcon,
                BadgeColor = p5.BadgeColor,
                EarnedOn = p5.EarnedOn
            };
        }
        public static AccountBadgeList AdaptTo(this AccountBadge p6, AccountBadgeList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            AccountBadgeList result = p7 ?? new AccountBadgeList();
            
            result.BadgeId = p6.BadgeId;
            result.BadgeName = p6.BadgeName;
            result.BadgeIcon = p6.BadgeIcon;
            result.BadgeColor = p6.BadgeColor;
            result.EarnedOn = p6.EarnedOn;
            return result;
            
        }
        public static Expression<Func<AccountBadge, AccountBadgeList>> ProjectToList => p8 => new AccountBadgeList()
        {
            BadgeId = p8.BadgeId,
            BadgeName = p8.BadgeName,
            BadgeIcon = p8.BadgeIcon,
            BadgeColor = p8.BadgeColor,
            EarnedOn = p8.EarnedOn
        };
        public static AccountBadge AdaptToAccountBadge(this AccountBadgeAdd p9)
        {
            return p9 == null ? null : new AccountBadge()
            {
                BadgeId = p9.BadgeId,
                BadgeName = p9.BadgeName,
                BadgeIcon = p9.BadgeIcon,
                BadgeColor = p9.BadgeColor,
                EarnedOn = p9.EarnedOn
            };
        }
        public static AccountBadge AdaptTo(this AccountBadgeMerge p10, AccountBadge p11)
        {
            if (p10 == null)
            {
                return null;
            }
            AccountBadge result = p11 ?? new AccountBadge();
            
            if (p10.BadgeId != null)
            {
                result.BadgeId = (Guid)p10.BadgeId;
            }
            
            if (p10.BadgeName != null)
            {
                result.BadgeName = p10.BadgeName;
            }
            
            if (p10.BadgeIcon != null)
            {
                result.BadgeIcon = p10.BadgeIcon;
            }
            
            if (p10.BadgeColor != null)
            {
                result.BadgeColor = p10.BadgeColor;
            }
            
            if (p10.EarnedOn != null)
            {
                result.EarnedOn = (DateTimeOffset)p10.EarnedOn;
            }
            return result;
            
        }
    }
}