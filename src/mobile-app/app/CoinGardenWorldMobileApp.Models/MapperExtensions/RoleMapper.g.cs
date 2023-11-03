using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

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
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn,
                DeletedFrom = p1.DeletedFrom,
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
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedFrom = p2.DeletedFrom;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Role, RoleDto>> ProjectToDto => p4 => new RoleDto()
        {
            Name = p4.Name,
            Description = p4.Description,
            Id = p4.Id,
            CreatedFrom = p4.CreatedFrom,
            CreatedOn = p4.CreatedOn,
            UpdatedFrom = p4.UpdatedFrom,
            UpdatedOn = p4.UpdatedOn,
            DeletedFrom = p4.DeletedFrom,
            DeletedAt = p4.DeletedAt
        };
        public static Role AdaptToRole(this RoleAdd p5)
        {
            return p5 == null ? null : new Role()
            {
                Name = p5.Name,
                Description = p5.Description
            };
        }
        public static Role AdaptTo(this RoleMerge p6, Role p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Role result = p7 ?? new Role();
            
            if (p6.Name != null)
            {
                result.Name = p6.Name;
            }
            
            if (p6.Description != null)
            {
                result.Description = p6.Description;
            }
            return result;
            
        }
    }
}