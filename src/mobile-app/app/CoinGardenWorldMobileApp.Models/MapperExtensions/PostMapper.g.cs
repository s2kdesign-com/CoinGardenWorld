using System;
using System.Collections.Generic;
using System.Linq;
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
                GardenId = p1.GardenId,
                Garden = funcMain1(p1.Garden),
                FlowerId = p1.FlowerId,
                Flower = p1.Flower == null ? null : new FlowerDto()
                {
                    Name = p1.Flower.Name,
                    Visibility = Enum<Visibility>.ToString(p1.Flower.Visibility),
                    GardenId = p1.Flower.GardenId,
                    Id = p1.Flower.Id,
                    CreatedOn = p1.Flower.CreatedOn,
                    UpdatedOn = p1.Flower.UpdatedOn,
                    DeletedAt = p1.Flower.DeletedAt
                },
                PostType = Enum<PostType>.ToString(p1.PostType),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static PostDto AdaptTo(this Post p6, PostDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            PostDto result = p7 ?? new PostDto();
            
            result.AccountId = p6.AccountId;
            result.Title = p6.Title;
            result.Content = p6.Content;
            result.LinkOrImageUrl = p6.LinkOrImageUrl;
            result.GardenId = p6.GardenId;
            result.Garden = funcMain5(p6.Garden, result.Garden);
            result.FlowerId = p6.FlowerId;
            result.Flower = funcMain9(p6.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p6.PostType);
            result.Visibility = Enum<Visibility>.ToString(p6.Visibility);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            result.UpdatedOn = p6.UpdatedOn;
            result.DeletedAt = p6.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p18 => new PostDto()
        {
            AccountId = p18.AccountId,
            Title = p18.Title,
            Content = p18.Content,
            LinkOrImageUrl = p18.LinkOrImageUrl,
            GardenId = p18.GardenId,
            Garden = p18.Garden == null ? null : new GardenDto()
            {
                Name = p18.Garden.Name,
                AccountId = p18.Garden.AccountId,
                Account = p18.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p18.Garden.Account.Email,
                    Username = p18.Garden.Account.Username,
                    DisplayName = p18.Garden.Account.DisplayName,
                    ProfileIntroduction = p18.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p18.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p18.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p18.Garden.Account.UserIdentityProvider,
                    Roles = p18.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p19 => new AccountRolesDto()
                    {
                        AccountId = p19.AccountId,
                        RoleId = p19.RoleId,
                        Role = p19.Role == null ? null : new RoleDto()
                        {
                            Name = p19.Role.Name,
                            Description = p19.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p19.Role.Visibility),
                            Id = p19.Role.Id,
                            CreatedOn = p19.Role.CreatedOn,
                            UpdatedOn = p19.Role.UpdatedOn,
                            DeletedAt = p19.Role.DeletedAt
                        },
                        Id = p19.Id,
                        CreatedOn = p19.CreatedOn,
                        UpdatedOn = p19.UpdatedOn,
                        DeletedAt = p19.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    Id = p18.Garden.Account.Id,
                    CreatedOn = p18.Garden.Account.CreatedOn,
                    UpdatedOn = p18.Garden.Account.UpdatedOn,
                    DeletedAt = p18.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p18.Garden.Visibility),
                Flowers = p18.Garden.Flowers.Select<Flower, FlowerDto>(p20 => new FlowerDto()
                {
                    Name = p20.Name,
                    Visibility = Enum<Visibility>.ToString(p20.Visibility),
                    GardenId = p20.GardenId,
                    Id = p20.Id,
                    CreatedOn = p20.CreatedOn,
                    UpdatedOn = p20.UpdatedOn,
                    DeletedAt = p20.DeletedAt
                }).ToList<FlowerDto>(),
                Id = p18.Garden.Id,
                CreatedOn = p18.Garden.CreatedOn,
                UpdatedOn = p18.Garden.UpdatedOn,
                DeletedAt = p18.Garden.DeletedAt
            },
            FlowerId = p18.FlowerId,
            Flower = p18.Flower == null ? null : new FlowerDto()
            {
                Name = p18.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p18.Flower.Visibility),
                GardenId = p18.Flower.GardenId,
                Id = p18.Flower.Id,
                CreatedOn = p18.Flower.CreatedOn,
                UpdatedOn = p18.Flower.UpdatedOn,
                DeletedAt = p18.Flower.DeletedAt
            },
            PostType = Enum<PostType>.ToString(p18.PostType),
            Visibility = Enum<Visibility>.ToString(p18.Visibility),
            Id = p18.Id,
            CreatedOn = p18.CreatedOn,
            UpdatedOn = p18.UpdatedOn,
            DeletedAt = p18.DeletedAt
        };
        public static PostList AdaptToList(this Post p21)
        {
            return p21 == null ? null : new PostList()
            {
                AccountId = p21.AccountId,
                Title = p21.Title,
                Content = p21.Content,
                LinkOrImageUrl = p21.LinkOrImageUrl,
                GardenId = p21.GardenId,
                Garden = funcMain10(p21.Garden),
                FlowerId = p21.FlowerId,
                Flower = p21.Flower == null ? null : new FlowerList()
                {
                    Name = p21.Flower.Name,
                    Visibility = Enum<Visibility>.ToString(p21.Flower.Visibility),
                    GardenId = p21.Flower.GardenId,
                    Id = p21.Flower.Id,
                    CreatedOn = p21.Flower.CreatedOn
                },
                PostType = Enum<PostType>.ToString(p21.PostType),
                Visibility = Enum<Visibility>.ToString(p21.Visibility),
                Id = p21.Id,
                CreatedOn = p21.CreatedOn
            };
        }
        public static PostList AdaptTo(this Post p24, PostList p25)
        {
            if (p24 == null)
            {
                return null;
            }
            PostList result = p25 ?? new PostList();
            
            result.AccountId = p24.AccountId;
            result.Title = p24.Title;
            result.Content = p24.Content;
            result.LinkOrImageUrl = p24.LinkOrImageUrl;
            result.GardenId = p24.GardenId;
            result.Garden = funcMain12(p24.Garden, result.Garden);
            result.FlowerId = p24.FlowerId;
            result.Flower = funcMain15(p24.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p24.PostType);
            result.Visibility = Enum<Visibility>.ToString(p24.Visibility);
            result.Id = p24.Id;
            result.CreatedOn = p24.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Post, PostList>> ProjectToList => p34 => new PostList()
        {
            AccountId = p34.AccountId,
            Title = p34.Title,
            Content = p34.Content,
            LinkOrImageUrl = p34.LinkOrImageUrl,
            GardenId = p34.GardenId,
            Garden = p34.Garden == null ? null : new GardenList()
            {
                Name = p34.Garden.Name,
                AccountId = p34.Garden.AccountId,
                Account = p34.Garden.Account == null ? null : new AccountList()
                {
                    Email = p34.Garden.Account.Email,
                    Username = p34.Garden.Account.Username,
                    DisplayName = p34.Garden.Account.DisplayName,
                    ProfileIntroduction = p34.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p34.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p34.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p34.Garden.Account.UserIdentityProvider,
                    Id = p34.Garden.Account.Id,
                    CreatedOn = p34.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p34.Garden.Visibility),
                Flowers = p34.Garden.Flowers.Select<Flower, FlowerList>(p35 => new FlowerList()
                {
                    Name = p35.Name,
                    Visibility = Enum<Visibility>.ToString(p35.Visibility),
                    GardenId = p35.GardenId,
                    Id = p35.Id,
                    CreatedOn = p35.CreatedOn
                }).ToList<FlowerList>(),
                Id = p34.Garden.Id,
                CreatedOn = p34.Garden.CreatedOn
            },
            FlowerId = p34.FlowerId,
            Flower = p34.Flower == null ? null : new FlowerList()
            {
                Name = p34.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p34.Flower.Visibility),
                GardenId = p34.Flower.GardenId,
                Id = p34.Flower.Id,
                CreatedOn = p34.Flower.CreatedOn
            },
            PostType = Enum<PostType>.ToString(p34.PostType),
            Visibility = Enum<Visibility>.ToString(p34.Visibility),
            Id = p34.Id,
            CreatedOn = p34.CreatedOn
        };
        public static Post AdaptToPost(this PostAdd p36)
        {
            return p36 == null ? null : new Post()
            {
                AccountId = p36.AccountId,
                Title = p36.Title,
                Content = p36.Content,
                LinkOrImageUrl = p36.LinkOrImageUrl,
                GardenId = p36.GardenId,
                Garden = funcMain16(p36.Garden),
                FlowerId = p36.FlowerId,
                Flower = p36.Flower == null ? null : new Flower()
                {
                    Name = p36.Flower.Name,
                    Visibility = p36.Flower.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p36.Flower.Visibility),
                    GardenId = p36.Flower.GardenId
                },
                PostType = p36.PostType == null ? PostType.Text : Enum<PostType>.Parse(p36.PostType),
                Visibility = p36.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p36.Visibility)
            };
        }
        public static Post AdaptTo(this PostMerge p39, Post p40)
        {
            if (p39 == null)
            {
                return null;
            }
            Post result = p40 ?? new Post();
            
            if (p39.AccountId != null)
            {
                result.AccountId = (Guid)p39.AccountId;
            }
            
            if (p39.Title != null)
            {
                result.Title = p39.Title;
            }
            
            if (p39.Content != null)
            {
                result.Content = p39.Content;
            }
            
            if (p39.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p39.LinkOrImageUrl;
            }
            
            if (p39.GardenId != null)
            {
                result.GardenId = p39.GardenId;
            }
            
            if (p39.Garden != null)
            {
                result.Garden = funcMain18(p39.Garden, result.Garden);
            }
            
            if (p39.FlowerId != null)
            {
                result.FlowerId = p39.FlowerId;
            }
            
            if (p39.Flower != null)
            {
                result.Flower = funcMain22(p39.Flower, result.Flower);
            }
            
            if (p39.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p39.PostType);
            }
            
            if (p39.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p39.Visibility);
            }
            return result;
            
        }
        
        private static GardenDto funcMain1(Garden p2)
        {
            return p2 == null ? null : new GardenDto()
            {
                Name = p2.Name,
                AccountId = p2.AccountId,
                Account = funcMain2(p2.Account),
                Visibility = Enum<Visibility>.ToString(p2.Visibility),
                Flowers = funcMain4(p2.Flowers),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static GardenDto funcMain5(Garden p8, GardenDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            GardenDto result = p9 ?? new GardenDto();
            
            result.Name = p8.Name;
            result.AccountId = p8.AccountId;
            result.Account = funcMain6(p8.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p8.Visibility);
            result.Flowers = funcMain8(p8.Flowers, result.Flowers);
            result.Id = p8.Id;
            result.CreatedOn = p8.CreatedOn;
            result.UpdatedOn = p8.UpdatedOn;
            result.DeletedAt = p8.DeletedAt;
            return result;
            
        }
        
        private static FlowerDto funcMain9(Flower p16, FlowerDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            FlowerDto result = p17 ?? new FlowerDto();
            
            result.Name = p16.Name;
            result.Visibility = Enum<Visibility>.ToString(p16.Visibility);
            result.GardenId = p16.GardenId;
            result.Id = p16.Id;
            result.CreatedOn = p16.CreatedOn;
            result.UpdatedOn = p16.UpdatedOn;
            result.DeletedAt = p16.DeletedAt;
            return result;
            
        }
        
        private static GardenList funcMain10(Garden p22)
        {
            return p22 == null ? null : new GardenList()
            {
                Name = p22.Name,
                AccountId = p22.AccountId,
                Account = p22.Account == null ? null : new AccountList()
                {
                    Email = p22.Account.Email,
                    Username = p22.Account.Username,
                    DisplayName = p22.Account.DisplayName,
                    ProfileIntroduction = p22.Account.ProfileIntroduction,
                    ProfilePicure = p22.Account.ProfilePicure,
                    UserObjectIdAzureAd = p22.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p22.Account.UserIdentityProvider,
                    Id = p22.Account.Id,
                    CreatedOn = p22.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p22.Visibility),
                Flowers = funcMain11(p22.Flowers),
                Id = p22.Id,
                CreatedOn = p22.CreatedOn
            };
        }
        
        private static GardenList funcMain12(Garden p26, GardenList p27)
        {
            if (p26 == null)
            {
                return null;
            }
            GardenList result = p27 ?? new GardenList();
            
            result.Name = p26.Name;
            result.AccountId = p26.AccountId;
            result.Account = funcMain13(p26.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p26.Visibility);
            result.Flowers = funcMain14(p26.Flowers, result.Flowers);
            result.Id = p26.Id;
            result.CreatedOn = p26.CreatedOn;
            return result;
            
        }
        
        private static FlowerList funcMain15(Flower p32, FlowerList p33)
        {
            if (p32 == null)
            {
                return null;
            }
            FlowerList result = p33 ?? new FlowerList();
            
            result.Name = p32.Name;
            result.Visibility = Enum<Visibility>.ToString(p32.Visibility);
            result.GardenId = p32.GardenId;
            result.Id = p32.Id;
            result.CreatedOn = p32.CreatedOn;
            return result;
            
        }
        
        private static Garden funcMain16(GardenAdd p37)
        {
            return p37 == null ? null : new Garden()
            {
                Name = p37.Name,
                AccountId = p37.AccountId,
                Account = p37.Account == null ? null : new Account()
                {
                    Email = p37.Account.Email,
                    Username = p37.Account.Username,
                    DisplayName = p37.Account.DisplayName,
                    ProfileIntroduction = p37.Account.ProfileIntroduction,
                    ProfilePicure = p37.Account.ProfilePicure,
                    UserObjectIdAzureAd = p37.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p37.Account.UserIdentityProvider
                },
                Visibility = p37.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p37.Visibility),
                Flowers = funcMain17(p37.Flowers)
            };
        }
        
        private static Garden funcMain18(GardenMerge p41, Garden p42)
        {
            if (p41 == null)
            {
                return null;
            }
            Garden result = p42 ?? new Garden();
            
            if (p41.Name != null)
            {
                result.Name = p41.Name;
            }
            
            if (p41.AccountId != null)
            {
                result.AccountId = (Guid)p41.AccountId;
            }
            
            if (p41.Account != null)
            {
                result.Account = funcMain19(p41.Account, result.Account);
            }
            
            if (p41.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p41.Visibility);
            }
            
            if (p41.Flowers != null)
            {
                result.Flowers = funcMain20(p41.Flowers, result.Flowers);
            }
            return result;
            
        }
        
        private static Flower funcMain22(FlowerMerge p48, Flower p49)
        {
            if (p48 == null)
            {
                return null;
            }
            Flower result = p49 ?? new Flower();
            
            if (p48.Name != null)
            {
                result.Name = p48.Name;
            }
            
            if (p48.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p48.Visibility);
            }
            
            if (p48.GardenId != null)
            {
                result.GardenId = p48.GardenId;
            }
            return result;
            
        }
        
        private static AccountDto funcMain2(Account p3)
        {
            return p3 == null ? null : new AccountDto()
            {
                Email = p3.Email,
                Username = p3.Username,
                DisplayName = p3.DisplayName,
                ProfileIntroduction = p3.ProfileIntroduction,
                ProfilePicure = p3.ProfilePicure,
                UserObjectIdAzureAd = p3.UserObjectIdAzureAd,
                UserIdentityProvider = p3.UserIdentityProvider,
                Roles = funcMain3(p3.Roles),
                Id = p3.Id,
                CreatedOn = p3.CreatedOn,
                UpdatedOn = p3.UpdatedOn,
                DeletedAt = p3.DeletedAt
            };
        }
        
        private static ICollection<FlowerDto> funcMain4(ICollection<Flower> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p5.Count);
            
            IEnumerator<Flower> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerDto()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static AccountDto funcMain6(Account p10, AccountDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            AccountDto result = p11 ?? new AccountDto();
            
            result.Email = p10.Email;
            result.Username = p10.Username;
            result.DisplayName = p10.DisplayName;
            result.ProfileIntroduction = p10.ProfileIntroduction;
            result.ProfilePicure = p10.ProfilePicure;
            result.UserObjectIdAzureAd = p10.UserObjectIdAzureAd;
            result.UserIdentityProvider = p10.UserIdentityProvider;
            result.Roles = funcMain7(p10.Roles, result.Roles);
            result.Id = p10.Id;
            result.CreatedOn = p10.CreatedOn;
            result.UpdatedOn = p10.UpdatedOn;
            result.DeletedAt = p10.DeletedAt;
            return result;
            
        }
        
        private static ICollection<FlowerDto> funcMain8(ICollection<Flower> p14, ICollection<FlowerDto> p15)
        {
            if (p14 == null)
            {
                return null;
            }
            ICollection<FlowerDto> result = new List<FlowerDto>(p14.Count);
            
            IEnumerator<Flower> enumerator = p14.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerDto()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlowerList> funcMain11(ICollection<Flower> p23)
        {
            if (p23 == null)
            {
                return null;
            }
            ICollection<FlowerList> result = new List<FlowerList>(p23.Count);
            
            IEnumerator<Flower> enumerator = p23.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerList()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn
                });
            }
            return result;
            
        }
        
        private static AccountList funcMain13(Account p28, AccountList p29)
        {
            if (p28 == null)
            {
                return null;
            }
            AccountList result = p29 ?? new AccountList();
            
            result.Email = p28.Email;
            result.Username = p28.Username;
            result.DisplayName = p28.DisplayName;
            result.ProfileIntroduction = p28.ProfileIntroduction;
            result.ProfilePicure = p28.ProfilePicure;
            result.UserObjectIdAzureAd = p28.UserObjectIdAzureAd;
            result.UserIdentityProvider = p28.UserIdentityProvider;
            result.Id = p28.Id;
            result.CreatedOn = p28.CreatedOn;
            return result;
            
        }
        
        private static ICollection<FlowerList> funcMain14(ICollection<Flower> p30, ICollection<FlowerList> p31)
        {
            if (p30 == null)
            {
                return null;
            }
            ICollection<FlowerList> result = new List<FlowerList>(p30.Count);
            
            IEnumerator<Flower> enumerator = p30.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Flower item = enumerator.Current;
                result.Add(item == null ? null : new FlowerList()
                {
                    Name = item.Name,
                    Visibility = Enum<Visibility>.ToString(item.Visibility),
                    GardenId = item.GardenId,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn
                });
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain17(ICollection<FlowerAdd> p38)
        {
            if (p38 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p38.Count);
            
            IEnumerator<FlowerAdd> enumerator = p38.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerAdd item = enumerator.Current;
                result.Add(item == null ? null : new Flower()
                {
                    Name = item.Name,
                    Visibility = item.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(item.Visibility),
                    GardenId = item.GardenId
                });
            }
            return result;
            
        }
        
        private static Account funcMain19(AccountMerge p43, Account p44)
        {
            if (p43 == null)
            {
                return null;
            }
            Account result = p44 ?? new Account();
            
            if (p43.Email != null)
            {
                result.Email = p43.Email;
            }
            
            if (p43.Username != null)
            {
                result.Username = p43.Username;
            }
            
            if (p43.DisplayName != null)
            {
                result.DisplayName = p43.DisplayName;
            }
            
            if (p43.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p43.ProfileIntroduction;
            }
            
            if (p43.ProfilePicure != null)
            {
                result.ProfilePicure = p43.ProfilePicure;
            }
            
            if (p43.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p43.UserObjectIdAzureAd;
            }
            
            if (p43.UserIdentityProvider != null)
            {
                result.UserIdentityProvider = p43.UserIdentityProvider;
            }
            return result;
            
        }
        
        private static ICollection<Flower> funcMain20(ICollection<FlowerMerge> p45, ICollection<Flower> p46)
        {
            if (p45 == null)
            {
                return null;
            }
            ICollection<Flower> result = new List<Flower>(p45.Count);
            
            IEnumerator<FlowerMerge> enumerator = p45.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlowerMerge item = enumerator.Current;
                result.Add(funcMain21(item));
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain3(ICollection<AccountRoles> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p4.Count);
            
            IEnumerator<AccountRoles> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRoles item = enumerator.Current;
                result.Add(item == null ? null : new AccountRolesDto()
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Role = item.Role == null ? null : new RoleDto()
                    {
                        Name = item.Role.Name,
                        Description = item.Role.Description,
                        Visibility = Enum<Visibility>.ToString(item.Role.Visibility),
                        Id = item.Role.Id,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain7(ICollection<AccountRoles> p12, ICollection<AccountRolesDto> p13)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p12.Count);
            
            IEnumerator<AccountRoles> enumerator = p12.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountRoles item = enumerator.Current;
                result.Add(item == null ? null : new AccountRolesDto()
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Role = item.Role == null ? null : new RoleDto()
                    {
                        Name = item.Role.Name,
                        Description = item.Role.Description,
                        Visibility = Enum<Visibility>.ToString(item.Role.Visibility),
                        Id = item.Role.Id,
                        CreatedOn = item.Role.CreatedOn,
                        UpdatedOn = item.Role.UpdatedOn,
                        DeletedAt = item.Role.DeletedAt
                    },
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static Flower funcMain21(FlowerMerge p47)
        {
            if (p47 == null)
            {
                return null;
            }
            Flower result = new Flower();
            
            if (p47.Name != null)
            {
                result.Name = p47.Name;
            }
            
            if (p47.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p47.Visibility);
            }
            
            if (p47.GardenId != null)
            {
                result.GardenId = p47.GardenId;
            }
            return result;
            
        }
    }
}