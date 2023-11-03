using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class RoleMapper
    {
        public static RoleDto AdaptToDto(this Role p1)
        {
            return p1 == null ? null : new RoleDto()
            {
                Name = p1.Name,
                Description = p1.Description,
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static RoleDto AdaptTo(this Role p2, RoleDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            RoleDto result = p3 ?? new RoleDto();
            
            result.Name = p2.Name;
            result.Description = p2.Description;
            result.Visibility = Enum<Visibility>.ToString(p2.Visibility);
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Role, RoleDto>> ProjectToDto => p4 => new RoleDto()
        {
            Name = p4.Name,
            Description = p4.Description,
            Visibility = Enum<Visibility>.ToString(p4.Visibility),
            Id = p4.Id,
            CreatedOn = p4.CreatedOn,
            UpdatedOn = p4.UpdatedOn,
            DeletedAt = p4.DeletedAt
        };
        public static RoleList AdaptToList(this Role p5)
        {
            return p5 == null ? null : new RoleList()
            {
                Name = p5.Name,
                Description = p5.Description,
                Visibility = Enum<Visibility>.ToString(p5.Visibility),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn
            };
        }
        public static RoleList AdaptTo(this Role p6, RoleList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            RoleList result = p7 ?? new RoleList();
            
            result.Name = p6.Name;
            result.Description = p6.Description;
            result.Visibility = Enum<Visibility>.ToString(p6.Visibility);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Role, RoleList>> ProjectToList => p8 => new RoleList()
        {
            Name = p8.Name,
            Description = p8.Description,
            Visibility = Enum<Visibility>.ToString(p8.Visibility),
            Id = p8.Id,
            CreatedOn = p8.CreatedOn
        };
        public static Role AdaptToRole(this RoleAdd p9)
        {
            return p9 == null ? null : new Role()
            {
                Name = p9.Name,
                Description = p9.Description,
                Visibility = p9.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p9.Visibility)
            };
        }
        public static Role AdaptTo(this RoleMerge p10, Role p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Role result = p11 ?? new Role();
            
            if (p10.Name != null)
            {
                result.Name = p10.Name;
            }
            
            if (p10.Description != null)
            {
                result.Description = p10.Description;
            }
            
            if (p10.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p10.Visibility);
            }
            return result;
            
        }
    }
}