using System;
using System.Linq.Expressions;
using CoinGardenWorld.Constants;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountBadgesMapper
    {
        public static AccountBadgesDto AdaptToDto(this AccountBadges p1)
        {
            return p1 == null ? null : new AccountBadgesDto()
            {
                AccountId = p1.AccountId,
                BadgeId = p1.BadgeId,
                Badge = p1.Badge == null ? null : new BadgeDto()
                {
                    Name = p1.Badge.Name,
                    Description = p1.Badge.Description,
                    BadgeType = Enum<BadgeTypes>.ToString(p1.Badge.BadgeType),
                    Id = p1.Badge.Id,
                    CreatedOn = p1.Badge.CreatedOn,
                    UpdatedOn = p1.Badge.UpdatedOn,
                    DeletedAt = p1.Badge.DeletedAt
                },
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static AccountBadgesDto AdaptTo(this AccountBadges p2, AccountBadgesDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            AccountBadgesDto result = p3 ?? new AccountBadgesDto();
            
            result.AccountId = p2.AccountId;
            result.BadgeId = p2.BadgeId;
            result.Badge = funcMain1(p2.Badge, result.Badge);
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<AccountBadges, AccountBadgesDto>> ProjectToDto => p6 => new AccountBadgesDto()
        {
            AccountId = p6.AccountId,
            BadgeId = p6.BadgeId,
            Badge = p6.Badge == null ? null : new BadgeDto()
            {
                Name = p6.Badge.Name,
                Description = p6.Badge.Description,
                BadgeType = Enum<BadgeTypes>.ToString(p6.Badge.BadgeType),
                Id = p6.Badge.Id,
                CreatedOn = p6.Badge.CreatedOn,
                UpdatedOn = p6.Badge.UpdatedOn,
                DeletedAt = p6.Badge.DeletedAt
            },
            Id = p6.Id,
            CreatedOn = p6.CreatedOn,
            UpdatedOn = p6.UpdatedOn,
            DeletedAt = p6.DeletedAt
        };
        public static AccountBadgesList AdaptToList(this AccountBadges p7)
        {
            return p7 == null ? null : new AccountBadgesList()
            {
                AccountId = p7.AccountId,
                BadgeId = p7.BadgeId,
                Badge = p7.Badge == null ? null : new BadgeList()
                {
                    Name = p7.Badge.Name,
                    Description = p7.Badge.Description,
                    BadgeType = Enum<BadgeTypes>.ToString(p7.Badge.BadgeType),
                    Id = p7.Badge.Id,
                    CreatedOn = p7.Badge.CreatedOn
                },
                Id = p7.Id,
                CreatedOn = p7.CreatedOn
            };
        }
        public static AccountBadgesList AdaptTo(this AccountBadges p8, AccountBadgesList p9)
        {
            if (p8 == null)
            {
                return null;
            }
            AccountBadgesList result = p9 ?? new AccountBadgesList();
            
            result.AccountId = p8.AccountId;
            result.BadgeId = p8.BadgeId;
            result.Badge = funcMain2(p8.Badge, result.Badge);
            result.Id = p8.Id;
            result.CreatedOn = p8.CreatedOn;
            return result;
            
        }
        public static Expression<Func<AccountBadges, AccountBadgesList>> ProjectToList => p12 => new AccountBadgesList()
        {
            AccountId = p12.AccountId,
            BadgeId = p12.BadgeId,
            Badge = p12.Badge == null ? null : new BadgeList()
            {
                Name = p12.Badge.Name,
                Description = p12.Badge.Description,
                BadgeType = Enum<BadgeTypes>.ToString(p12.Badge.BadgeType),
                Id = p12.Badge.Id,
                CreatedOn = p12.Badge.CreatedOn
            },
            Id = p12.Id,
            CreatedOn = p12.CreatedOn
        };
        public static AccountBadges AdaptToAccountBadges(this AccountBadgesAdd p13)
        {
            return p13 == null ? null : new AccountBadges()
            {
                AccountId = p13.AccountId,
                BadgeId = p13.BadgeId,
                Badge = p13.Badge == null ? null : new Badge()
                {
                    Name = p13.Badge.Name,
                    Description = p13.Badge.Description,
                    BadgeType = p13.Badge.BadgeType == null ? BadgeTypes.BasedOnTimeRegistered : Enum<BadgeTypes>.Parse(p13.Badge.BadgeType)
                }
            };
        }
        public static AccountBadges AdaptTo(this AccountBadgesMerge p14, AccountBadges p15)
        {
            if (p14 == null)
            {
                return null;
            }
            AccountBadges result = p15 ?? new AccountBadges();
            
            if (p14.AccountId != null)
            {
                result.AccountId = (Guid)p14.AccountId;
            }
            
            if (p14.BadgeId != null)
            {
                result.BadgeId = (Guid)p14.BadgeId;
            }
            
            if (p14.Badge != null)
            {
                result.Badge = funcMain3(p14.Badge, result.Badge);
            }
            return result;
            
        }
        
        private static BadgeDto funcMain1(Badge p4, BadgeDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            BadgeDto result = p5 ?? new BadgeDto();
            
            result.Name = p4.Name;
            result.Description = p4.Description;
            result.BadgeType = Enum<BadgeTypes>.ToString(p4.BadgeType);
            result.Id = p4.Id;
            result.CreatedOn = p4.CreatedOn;
            result.UpdatedOn = p4.UpdatedOn;
            result.DeletedAt = p4.DeletedAt;
            return result;
            
        }
        
        private static BadgeList funcMain2(Badge p10, BadgeList p11)
        {
            if (p10 == null)
            {
                return null;
            }
            BadgeList result = p11 ?? new BadgeList();
            
            result.Name = p10.Name;
            result.Description = p10.Description;
            result.BadgeType = Enum<BadgeTypes>.ToString(p10.BadgeType);
            result.Id = p10.Id;
            result.CreatedOn = p10.CreatedOn;
            return result;
            
        }
        
        private static Badge funcMain3(BadgeMerge p16, Badge p17)
        {
            if (p16 == null)
            {
                return null;
            }
            Badge result = p17 ?? new Badge();
            
            if (p16.Name != null)
            {
                result.Name = p16.Name;
            }
            
            if (p16.Description != null)
            {
                result.Description = p16.Description;
            }
            
            if (p16.BadgeType != null)
            {
                result.BadgeType = Enum<BadgeTypes>.Parse(p16.BadgeType);
            }
            return result;
            
        }
    }
}