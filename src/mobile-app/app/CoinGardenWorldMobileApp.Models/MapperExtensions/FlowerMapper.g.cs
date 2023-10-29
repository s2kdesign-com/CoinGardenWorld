using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class FlowerMapper
    {
        public static FlowerDto AdaptToDto(this Flower p1)
        {
            return p1 == null ? null : new FlowerDto()
            {
                Name = p1.Name,
                GardenId = p1.GardenId,
                Id = p1.Id,
                CreatedFrom = p1.CreatedFrom,
                CreatedOn = p1.CreatedOn,
                UpdatedFrom = p1.UpdatedFrom,
                UpdatedOn = p1.UpdatedOn
            };
        }
        public static FlowerDto AdaptTo(this Flower p2, FlowerDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlowerDto result = p3 ?? new FlowerDto();
            
            result.Name = p2.Name;
            result.GardenId = p2.GardenId;
            result.Id = p2.Id;
            result.CreatedFrom = p2.CreatedFrom;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedFrom = p2.UpdatedFrom;
            result.UpdatedOn = p2.UpdatedOn;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerDto>> ProjectToDto => p4 => new FlowerDto()
        {
            Name = p4.Name,
            GardenId = p4.GardenId,
            Id = p4.Id,
            CreatedFrom = p4.CreatedFrom,
            CreatedOn = p4.CreatedOn,
            UpdatedFrom = p4.UpdatedFrom,
            UpdatedOn = p4.UpdatedOn
        };
        public static Flower AdaptToFlower(this FlowerAdd p5)
        {
            return p5 == null ? null : new Flower()
            {
                Name = p5.Name,
                GardenId = p5.GardenId,
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn
            };
        }
        public static Flower AdaptTo(this FlowerUpdate p6, Flower p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Flower result = p7 ?? new Flower();
            
            result.Name = p6.Name;
            result.GardenId = p6.GardenId;
            return result;
            
        }
        public static Flower AdaptTo(this FlowerMerge p8, Flower p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Flower result = p9 ?? new Flower();
            
            if (p8.Name != null)
            {
                result.Name = p8.Name;
            }
            
            if (p8.GardenId != null)
            {
                result.GardenId = (Guid)p8.GardenId;
            }
            return result;
            
        }
    }
}