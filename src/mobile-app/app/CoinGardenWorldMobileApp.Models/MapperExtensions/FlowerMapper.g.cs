using System;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class FlowerMapper
    {
        public static FlowerDto AdaptToDto(this Flower p1)
        {
            return p1 == null ? null : new FlowerDto()
            {
                Name = p1.Name,
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                GardenId = p1.GardenId,
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
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
            result.Visibility = Enum<Visibility>.ToString(p2.Visibility);
            result.GardenId = p2.GardenId;
            result.Id = p2.Id;
            result.CreatedOn = p2.CreatedOn;
            result.UpdatedOn = p2.UpdatedOn;
            result.DeletedAt = p2.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerDto>> ProjectToDto => p4 => new FlowerDto()
        {
            Name = p4.Name,
            Visibility = Enum<Visibility>.ToString(p4.Visibility),
            GardenId = p4.GardenId,
            Id = p4.Id,
            CreatedOn = p4.CreatedOn,
            UpdatedOn = p4.UpdatedOn,
            DeletedAt = p4.DeletedAt
        };
        public static FlowerList AdaptToList(this Flower p5)
        {
            return p5 == null ? null : new FlowerList()
            {
                Name = p5.Name,
                Visibility = Enum<Visibility>.ToString(p5.Visibility),
                GardenId = p5.GardenId,
                Id = p5.Id,
                CreatedOn = p5.CreatedOn
            };
        }
        public static FlowerList AdaptTo(this Flower p6, FlowerList p7)
        {
            if (p6 == null)
            {
                return null;
            }
            FlowerList result = p7 ?? new FlowerList();
            
            result.Name = p6.Name;
            result.Visibility = Enum<Visibility>.ToString(p6.Visibility);
            result.GardenId = p6.GardenId;
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerList>> ProjectToList => p8 => new FlowerList()
        {
            Name = p8.Name,
            Visibility = Enum<Visibility>.ToString(p8.Visibility),
            GardenId = p8.GardenId,
            Id = p8.Id,
            CreatedOn = p8.CreatedOn
        };
        public static Flower AdaptToFlower(this FlowerAdd p9)
        {
            return p9 == null ? null : new Flower()
            {
                Name = p9.Name,
                Visibility = p9.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p9.Visibility),
                GardenId = p9.GardenId
            };
        }
        public static Flower AdaptTo(this FlowerMerge p10, Flower p11)
        {
            if (p10 == null)
            {
                return null;
            }
            Flower result = p11 ?? new Flower();
            
            if (p10.Name != null)
            {
                result.Name = p10.Name;
            }
            
            if (p10.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p10.Visibility);
            }
            
            if (p10.GardenId != null)
            {
                result.GardenId = p10.GardenId;
            }
            return result;
            
        }
    }
}