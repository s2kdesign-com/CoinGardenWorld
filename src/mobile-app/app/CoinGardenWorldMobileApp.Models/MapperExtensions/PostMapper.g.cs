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
                Account = funcMain1(p1.Account),
                Title = p1.Title,
                Content = p1.Content,
                LinkOrImageUrl = p1.LinkOrImageUrl,
                GardenId = p1.GardenId,
                Garden = funcMain3(p1.Garden),
                FlowerId = p1.FlowerId,
                Flower = funcMain6(p1.Flower),
                PostType = Enum<PostType>.ToString(p1.PostType),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static PostDto AdaptTo(this Post p13, PostDto p14)
        {
            if (p13 == null)
            {
                return null;
            }
            PostDto result = p14 ?? new PostDto();
            
            result.AccountId = p13.AccountId;
            result.Account = funcMain12(p13.Account, result.Account);
            result.Title = p13.Title;
            result.Content = p13.Content;
            result.LinkOrImageUrl = p13.LinkOrImageUrl;
            result.GardenId = p13.GardenId;
            result.Garden = funcMain14(p13.Garden, result.Garden);
            result.FlowerId = p13.FlowerId;
            result.Flower = funcMain17(p13.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p13.PostType);
            result.Visibility = Enum<Visibility>.ToString(p13.Visibility);
            result.Id = p13.Id;
            result.CreatedOn = p13.CreatedOn;
            result.UpdatedOn = p13.UpdatedOn;
            result.DeletedAt = p13.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p37 => new PostDto()
        {
            AccountId = p37.AccountId,
            Account = p37.Account == null ? null : new AccountDto()
            {
                Email = p37.Account.Email,
                Username = p37.Account.Username,
                DisplayName = p37.Account.DisplayName,
                ProfileIntroduction = p37.Account.ProfileIntroduction,
                ProfilePicure = p37.Account.ProfilePicure,
                UserObjectIdAzureAd = p37.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p37.Account.UserIdentityProvider,
                Roles = p37.Account.Roles.Select<AccountRoles, AccountRolesDto>(p38 => new AccountRolesDto()
                {
                    AccountId = p38.AccountId,
                    RoleId = p38.RoleId,
                    Role = p38.Role == null ? null : new RoleDto()
                    {
                        Name = p38.Role.Name,
                        Description = p38.Role.Description,
                        Visibility = Enum<Visibility>.ToString(p38.Role.Visibility),
                        Id = p38.Role.Id,
                        CreatedOn = p38.Role.CreatedOn,
                        UpdatedOn = p38.Role.UpdatedOn,
                        DeletedAt = p38.Role.DeletedAt
                    },
                    Id = p38.Id,
                    CreatedOn = p38.CreatedOn,
                    UpdatedOn = p38.UpdatedOn,
                    DeletedAt = p38.DeletedAt
                }).ToList<AccountRolesDto>(),
                Id = p37.Account.Id,
                CreatedOn = p37.Account.CreatedOn,
                UpdatedOn = p37.Account.UpdatedOn,
                DeletedAt = p37.Account.DeletedAt
            },
            Title = p37.Title,
            Content = p37.Content,
            LinkOrImageUrl = p37.LinkOrImageUrl,
            GardenId = p37.GardenId,
            Garden = p37.Garden == null ? null : new GardenDto()
            {
                Name = p37.Garden.Name,
                AccountId = p37.Garden.AccountId,
                Account = p37.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p37.Garden.Account.Email,
                    Username = p37.Garden.Account.Username,
                    DisplayName = p37.Garden.Account.DisplayName,
                    ProfileIntroduction = p37.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p37.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p37.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p37.Garden.Account.UserIdentityProvider,
                    Roles = p37.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p39 => new AccountRolesDto()
                    {
                        AccountId = p39.AccountId,
                        RoleId = p39.RoleId,
                        Role = p39.Role == null ? null : new RoleDto()
                        {
                            Name = p39.Role.Name,
                            Description = p39.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p39.Role.Visibility),
                            Id = p39.Role.Id,
                            CreatedOn = p39.Role.CreatedOn,
                            UpdatedOn = p39.Role.UpdatedOn,
                            DeletedAt = p39.Role.DeletedAt
                        },
                        Id = p39.Id,
                        CreatedOn = p39.CreatedOn,
                        UpdatedOn = p39.UpdatedOn,
                        DeletedAt = p39.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    Id = p37.Garden.Account.Id,
                    CreatedOn = p37.Garden.Account.CreatedOn,
                    UpdatedOn = p37.Garden.Account.UpdatedOn,
                    DeletedAt = p37.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p37.Garden.Visibility),
                Id = p37.Garden.Id,
                CreatedOn = p37.Garden.CreatedOn,
                UpdatedOn = p37.Garden.UpdatedOn,
                DeletedAt = p37.Garden.DeletedAt
            },
            FlowerId = p37.FlowerId,
            Flower = p37.Flower == null ? null : new FlowerDto()
            {
                Name = p37.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p37.Flower.Visibility),
                AccountId = p37.Flower.AccountId,
                Account = p37.Flower.Account == null ? null : new AccountDto()
                {
                    Email = p37.Flower.Account.Email,
                    Username = p37.Flower.Account.Username,
                    DisplayName = p37.Flower.Account.DisplayName,
                    ProfileIntroduction = p37.Flower.Account.ProfileIntroduction,
                    ProfilePicure = p37.Flower.Account.ProfilePicure,
                    UserObjectIdAzureAd = p37.Flower.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p37.Flower.Account.UserIdentityProvider,
                    Roles = p37.Flower.Account.Roles.Select<AccountRoles, AccountRolesDto>(p40 => new AccountRolesDto()
                    {
                        AccountId = p40.AccountId,
                        RoleId = p40.RoleId,
                        Role = p40.Role == null ? null : new RoleDto()
                        {
                            Name = p40.Role.Name,
                            Description = p40.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p40.Role.Visibility),
                            Id = p40.Role.Id,
                            CreatedOn = p40.Role.CreatedOn,
                            UpdatedOn = p40.Role.UpdatedOn,
                            DeletedAt = p40.Role.DeletedAt
                        },
                        Id = p40.Id,
                        CreatedOn = p40.CreatedOn,
                        UpdatedOn = p40.UpdatedOn,
                        DeletedAt = p40.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    Id = p37.Flower.Account.Id,
                    CreatedOn = p37.Flower.Account.CreatedOn,
                    UpdatedOn = p37.Flower.Account.UpdatedOn,
                    DeletedAt = p37.Flower.Account.DeletedAt
                },
                GardenId = p37.Flower.GardenId,
                Garden = p37.Flower.Garden == null ? null : new GardenDto()
                {
                    Name = p37.Flower.Garden.Name,
                    AccountId = p37.Flower.Garden.AccountId,
                    Account = p37.Flower.Garden.Account == null ? null : new AccountDto()
                    {
                        Email = p37.Flower.Garden.Account.Email,
                        Username = p37.Flower.Garden.Account.Username,
                        DisplayName = p37.Flower.Garden.Account.DisplayName,
                        ProfileIntroduction = p37.Flower.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p37.Flower.Garden.Account.ProfilePicure,
                        UserObjectIdAzureAd = p37.Flower.Garden.Account.UserObjectIdAzureAd,
                        UserIdentityProvider = p37.Flower.Garden.Account.UserIdentityProvider,
                        Roles = p37.Flower.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p41 => new AccountRolesDto()
                        {
                            AccountId = p41.AccountId,
                            RoleId = p41.RoleId,
                            Role = p41.Role == null ? null : new RoleDto()
                            {
                                Name = p41.Role.Name,
                                Description = p41.Role.Description,
                                Visibility = Enum<Visibility>.ToString(p41.Role.Visibility),
                                Id = p41.Role.Id,
                                CreatedOn = p41.Role.CreatedOn,
                                UpdatedOn = p41.Role.UpdatedOn,
                                DeletedAt = p41.Role.DeletedAt
                            },
                            Id = p41.Id,
                            CreatedOn = p41.CreatedOn,
                            UpdatedOn = p41.UpdatedOn,
                            DeletedAt = p41.DeletedAt
                        }).ToList<AccountRolesDto>(),
                        Id = p37.Flower.Garden.Account.Id,
                        CreatedOn = p37.Flower.Garden.Account.CreatedOn,
                        UpdatedOn = p37.Flower.Garden.Account.UpdatedOn,
                        DeletedAt = p37.Flower.Garden.Account.DeletedAt
                    },
                    Visibility = Enum<Visibility>.ToString(p37.Flower.Garden.Visibility),
                    Id = p37.Flower.Garden.Id,
                    CreatedOn = p37.Flower.Garden.CreatedOn,
                    UpdatedOn = p37.Flower.Garden.UpdatedOn,
                    DeletedAt = p37.Flower.Garden.DeletedAt
                },
                Id = p37.Flower.Id,
                CreatedOn = p37.Flower.CreatedOn,
                UpdatedOn = p37.Flower.UpdatedOn,
                DeletedAt = p37.Flower.DeletedAt
            },
            PostType = Enum<PostType>.ToString(p37.PostType),
            Visibility = Enum<Visibility>.ToString(p37.Visibility),
            Id = p37.Id,
            CreatedOn = p37.CreatedOn,
            UpdatedOn = p37.UpdatedOn,
            DeletedAt = p37.DeletedAt
        };
        public static PostList AdaptToList(this Post p42)
        {
            return p42 == null ? null : new PostList()
            {
                AccountId = p42.AccountId,
                Account = p42.Account == null ? null : new AccountList()
                {
                    Email = p42.Account.Email,
                    Username = p42.Account.Username,
                    DisplayName = p42.Account.DisplayName,
                    ProfileIntroduction = p42.Account.ProfileIntroduction,
                    ProfilePicure = p42.Account.ProfilePicure,
                    UserObjectIdAzureAd = p42.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p42.Account.UserIdentityProvider,
                    Id = p42.Account.Id,
                    CreatedOn = p42.Account.CreatedOn
                },
                Title = p42.Title,
                Content = p42.Content,
                LinkOrImageUrl = p42.LinkOrImageUrl,
                GardenId = p42.GardenId,
                Garden = p42.Garden == null ? null : new GardenList()
                {
                    Name = p42.Garden.Name,
                    AccountId = p42.Garden.AccountId,
                    Account = p42.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p42.Garden.Account.Email,
                        Username = p42.Garden.Account.Username,
                        DisplayName = p42.Garden.Account.DisplayName,
                        ProfileIntroduction = p42.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p42.Garden.Account.ProfilePicure,
                        UserObjectIdAzureAd = p42.Garden.Account.UserObjectIdAzureAd,
                        UserIdentityProvider = p42.Garden.Account.UserIdentityProvider,
                        Id = p42.Garden.Account.Id,
                        CreatedOn = p42.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p42.Garden.Visibility),
                    Id = p42.Garden.Id,
                    CreatedOn = p42.Garden.CreatedOn
                },
                FlowerId = p42.FlowerId,
                Flower = p42.Flower == null ? null : new FlowerList()
                {
                    Name = p42.Flower.Name,
                    Visibility = Enum<Visibility>.ToString(p42.Flower.Visibility),
                    AccountId = p42.Flower.AccountId,
                    Account = p42.Flower.Account == null ? null : new AccountList()
                    {
                        Email = p42.Flower.Account.Email,
                        Username = p42.Flower.Account.Username,
                        DisplayName = p42.Flower.Account.DisplayName,
                        ProfileIntroduction = p42.Flower.Account.ProfileIntroduction,
                        ProfilePicure = p42.Flower.Account.ProfilePicure,
                        UserObjectIdAzureAd = p42.Flower.Account.UserObjectIdAzureAd,
                        UserIdentityProvider = p42.Flower.Account.UserIdentityProvider,
                        Id = p42.Flower.Account.Id,
                        CreatedOn = p42.Flower.Account.CreatedOn
                    },
                    GardenId = p42.Flower.GardenId,
                    Garden = p42.Flower.Garden == null ? null : new GardenList()
                    {
                        Name = p42.Flower.Garden.Name,
                        AccountId = p42.Flower.Garden.AccountId,
                        Account = p42.Flower.Garden.Account == null ? null : new AccountList()
                        {
                            Email = p42.Flower.Garden.Account.Email,
                            Username = p42.Flower.Garden.Account.Username,
                            DisplayName = p42.Flower.Garden.Account.DisplayName,
                            ProfileIntroduction = p42.Flower.Garden.Account.ProfileIntroduction,
                            ProfilePicure = p42.Flower.Garden.Account.ProfilePicure,
                            UserObjectIdAzureAd = p42.Flower.Garden.Account.UserObjectIdAzureAd,
                            UserIdentityProvider = p42.Flower.Garden.Account.UserIdentityProvider,
                            Id = p42.Flower.Garden.Account.Id,
                            CreatedOn = p42.Flower.Garden.Account.CreatedOn
                        },
                        Visibility = Enum<Visibility>.ToString(p42.Flower.Garden.Visibility),
                        Id = p42.Flower.Garden.Id,
                        CreatedOn = p42.Flower.Garden.CreatedOn
                    },
                    Id = p42.Flower.Id,
                    CreatedOn = p42.Flower.CreatedOn
                },
                PostType = Enum<PostType>.ToString(p42.PostType),
                Visibility = Enum<Visibility>.ToString(p42.Visibility),
                Id = p42.Id,
                CreatedOn = p42.CreatedOn
            };
        }
        public static PostList AdaptTo(this Post p43, PostList p44)
        {
            if (p43 == null)
            {
                return null;
            }
            PostList result = p44 ?? new PostList();
            
            result.AccountId = p43.AccountId;
            result.Account = funcMain23(p43.Account, result.Account);
            result.Title = p43.Title;
            result.Content = p43.Content;
            result.LinkOrImageUrl = p43.LinkOrImageUrl;
            result.GardenId = p43.GardenId;
            result.Garden = funcMain24(p43.Garden, result.Garden);
            result.FlowerId = p43.FlowerId;
            result.Flower = funcMain26(p43.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p43.PostType);
            result.Visibility = Enum<Visibility>.ToString(p43.Visibility);
            result.Id = p43.Id;
            result.CreatedOn = p43.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Post, PostList>> ProjectToList => p59 => new PostList()
        {
            AccountId = p59.AccountId,
            Account = p59.Account == null ? null : new AccountList()
            {
                Email = p59.Account.Email,
                Username = p59.Account.Username,
                DisplayName = p59.Account.DisplayName,
                ProfileIntroduction = p59.Account.ProfileIntroduction,
                ProfilePicure = p59.Account.ProfilePicure,
                UserObjectIdAzureAd = p59.Account.UserObjectIdAzureAd,
                UserIdentityProvider = p59.Account.UserIdentityProvider,
                Id = p59.Account.Id,
                CreatedOn = p59.Account.CreatedOn
            },
            Title = p59.Title,
            Content = p59.Content,
            LinkOrImageUrl = p59.LinkOrImageUrl,
            GardenId = p59.GardenId,
            Garden = p59.Garden == null ? null : new GardenList()
            {
                Name = p59.Garden.Name,
                AccountId = p59.Garden.AccountId,
                Account = p59.Garden.Account == null ? null : new AccountList()
                {
                    Email = p59.Garden.Account.Email,
                    Username = p59.Garden.Account.Username,
                    DisplayName = p59.Garden.Account.DisplayName,
                    ProfileIntroduction = p59.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p59.Garden.Account.ProfilePicure,
                    UserObjectIdAzureAd = p59.Garden.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p59.Garden.Account.UserIdentityProvider,
                    Id = p59.Garden.Account.Id,
                    CreatedOn = p59.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p59.Garden.Visibility),
                Id = p59.Garden.Id,
                CreatedOn = p59.Garden.CreatedOn
            },
            FlowerId = p59.FlowerId,
            Flower = p59.Flower == null ? null : new FlowerList()
            {
                Name = p59.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p59.Flower.Visibility),
                AccountId = p59.Flower.AccountId,
                Account = p59.Flower.Account == null ? null : new AccountList()
                {
                    Email = p59.Flower.Account.Email,
                    Username = p59.Flower.Account.Username,
                    DisplayName = p59.Flower.Account.DisplayName,
                    ProfileIntroduction = p59.Flower.Account.ProfileIntroduction,
                    ProfilePicure = p59.Flower.Account.ProfilePicure,
                    UserObjectIdAzureAd = p59.Flower.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p59.Flower.Account.UserIdentityProvider,
                    Id = p59.Flower.Account.Id,
                    CreatedOn = p59.Flower.Account.CreatedOn
                },
                GardenId = p59.Flower.GardenId,
                Garden = p59.Flower.Garden == null ? null : new GardenList()
                {
                    Name = p59.Flower.Garden.Name,
                    AccountId = p59.Flower.Garden.AccountId,
                    Account = p59.Flower.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p59.Flower.Garden.Account.Email,
                        Username = p59.Flower.Garden.Account.Username,
                        DisplayName = p59.Flower.Garden.Account.DisplayName,
                        ProfileIntroduction = p59.Flower.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p59.Flower.Garden.Account.ProfilePicure,
                        UserObjectIdAzureAd = p59.Flower.Garden.Account.UserObjectIdAzureAd,
                        UserIdentityProvider = p59.Flower.Garden.Account.UserIdentityProvider,
                        Id = p59.Flower.Garden.Account.Id,
                        CreatedOn = p59.Flower.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p59.Flower.Garden.Visibility),
                    Id = p59.Flower.Garden.Id,
                    CreatedOn = p59.Flower.Garden.CreatedOn
                },
                Id = p59.Flower.Id,
                CreatedOn = p59.Flower.CreatedOn
            },
            PostType = Enum<PostType>.ToString(p59.PostType),
            Visibility = Enum<Visibility>.ToString(p59.Visibility),
            Id = p59.Id,
            CreatedOn = p59.CreatedOn
        };
        public static Post AdaptToPost(this PostAdd p60)
        {
            return p60 == null ? null : new Post()
            {
                AccountId = p60.AccountId,
                Account = p60.Account == null ? null : new Account()
                {
                    Email = p60.Account.Email,
                    Username = p60.Account.Username,
                    DisplayName = p60.Account.DisplayName,
                    ProfileIntroduction = p60.Account.ProfileIntroduction,
                    ProfilePicure = p60.Account.ProfilePicure,
                    UserObjectIdAzureAd = p60.Account.UserObjectIdAzureAd,
                    UserIdentityProvider = p60.Account.UserIdentityProvider
                },
                Title = p60.Title,
                Content = p60.Content,
                LinkOrImageUrl = p60.LinkOrImageUrl,
                GardenId = p60.GardenId,
                FlowerId = p60.FlowerId,
                PostType = p60.PostType == null ? PostType.Text : Enum<PostType>.Parse(p60.PostType),
                Visibility = p60.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p60.Visibility)
            };
        }
        public static Post AdaptTo(this PostMerge p61, Post p62)
        {
            if (p61 == null)
            {
                return null;
            }
            Post result = p62 ?? new Post();
            
            if (p61.AccountId != null)
            {
                result.AccountId = (Guid)p61.AccountId;
            }
            
            if (p61.Account != null)
            {
                result.Account = funcMain30(p61.Account, result.Account);
            }
            
            if (p61.Title != null)
            {
                result.Title = p61.Title;
            }
            
            if (p61.Content != null)
            {
                result.Content = p61.Content;
            }
            
            if (p61.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p61.LinkOrImageUrl;
            }
            
            if (p61.GardenId != null)
            {
                result.GardenId = p61.GardenId;
            }
            
            if (p61.FlowerId != null)
            {
                result.FlowerId = p61.FlowerId;
            }
            
            if (p61.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p61.PostType);
            }
            
            if (p61.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p61.Visibility);
            }
            return result;
            
        }
        
        private static AccountDto funcMain1(Account p2)
        {
            return p2 == null ? null : new AccountDto()
            {
                Email = p2.Email,
                Username = p2.Username,
                DisplayName = p2.DisplayName,
                ProfileIntroduction = p2.ProfileIntroduction,
                ProfilePicure = p2.ProfilePicure,
                UserObjectIdAzureAd = p2.UserObjectIdAzureAd,
                UserIdentityProvider = p2.UserIdentityProvider,
                Roles = funcMain2(p2.Roles),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static GardenDto funcMain3(Garden p4)
        {
            return p4 == null ? null : new GardenDto()
            {
                Name = p4.Name,
                AccountId = p4.AccountId,
                Account = funcMain4(p4.Account),
                Visibility = Enum<Visibility>.ToString(p4.Visibility),
                Id = p4.Id,
                CreatedOn = p4.CreatedOn,
                UpdatedOn = p4.UpdatedOn,
                DeletedAt = p4.DeletedAt
            };
        }
        
        private static FlowerDto funcMain6(Flower p7)
        {
            return p7 == null ? null : new FlowerDto()
            {
                Name = p7.Name,
                Visibility = Enum<Visibility>.ToString(p7.Visibility),
                AccountId = p7.AccountId,
                Account = funcMain7(p7.Account),
                GardenId = p7.GardenId,
                Garden = funcMain9(p7.Garden),
                Id = p7.Id,
                CreatedOn = p7.CreatedOn,
                UpdatedOn = p7.UpdatedOn,
                DeletedAt = p7.DeletedAt
            };
        }
        
        private static AccountDto funcMain12(Account p15, AccountDto p16)
        {
            if (p15 == null)
            {
                return null;
            }
            AccountDto result = p16 ?? new AccountDto();
            
            result.Email = p15.Email;
            result.Username = p15.Username;
            result.DisplayName = p15.DisplayName;
            result.ProfileIntroduction = p15.ProfileIntroduction;
            result.ProfilePicure = p15.ProfilePicure;
            result.UserObjectIdAzureAd = p15.UserObjectIdAzureAd;
            result.UserIdentityProvider = p15.UserIdentityProvider;
            result.Roles = funcMain13(p15.Roles, result.Roles);
            result.Id = p15.Id;
            result.CreatedOn = p15.CreatedOn;
            result.UpdatedOn = p15.UpdatedOn;
            result.DeletedAt = p15.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain14(Garden p19, GardenDto p20)
        {
            if (p19 == null)
            {
                return null;
            }
            GardenDto result = p20 ?? new GardenDto();
            
            result.Name = p19.Name;
            result.AccountId = p19.AccountId;
            result.Account = funcMain15(p19.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p19.Visibility);
            result.Id = p19.Id;
            result.CreatedOn = p19.CreatedOn;
            result.UpdatedOn = p19.UpdatedOn;
            result.DeletedAt = p19.DeletedAt;
            return result;
            
        }
        
        private static FlowerDto funcMain17(Flower p25, FlowerDto p26)
        {
            if (p25 == null)
            {
                return null;
            }
            FlowerDto result = p26 ?? new FlowerDto();
            
            result.Name = p25.Name;
            result.Visibility = Enum<Visibility>.ToString(p25.Visibility);
            result.AccountId = p25.AccountId;
            result.Account = funcMain18(p25.Account, result.Account);
            result.GardenId = p25.GardenId;
            result.Garden = funcMain20(p25.Garden, result.Garden);
            result.Id = p25.Id;
            result.CreatedOn = p25.CreatedOn;
            result.UpdatedOn = p25.UpdatedOn;
            result.DeletedAt = p25.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain23(Account p45, AccountList p46)
        {
            if (p45 == null)
            {
                return null;
            }
            AccountList result = p46 ?? new AccountList();
            
            result.Email = p45.Email;
            result.Username = p45.Username;
            result.DisplayName = p45.DisplayName;
            result.ProfileIntroduction = p45.ProfileIntroduction;
            result.ProfilePicure = p45.ProfilePicure;
            result.UserObjectIdAzureAd = p45.UserObjectIdAzureAd;
            result.UserIdentityProvider = p45.UserIdentityProvider;
            result.Id = p45.Id;
            result.CreatedOn = p45.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain24(Garden p47, GardenList p48)
        {
            if (p47 == null)
            {
                return null;
            }
            GardenList result = p48 ?? new GardenList();
            
            result.Name = p47.Name;
            result.AccountId = p47.AccountId;
            result.Account = funcMain25(p47.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p47.Visibility);
            result.Id = p47.Id;
            result.CreatedOn = p47.CreatedOn;
            return result;
            
        }
        
        private static FlowerList funcMain26(Flower p51, FlowerList p52)
        {
            if (p51 == null)
            {
                return null;
            }
            FlowerList result = p52 ?? new FlowerList();
            
            result.Name = p51.Name;
            result.Visibility = Enum<Visibility>.ToString(p51.Visibility);
            result.AccountId = p51.AccountId;
            result.Account = funcMain27(p51.Account, result.Account);
            result.GardenId = p51.GardenId;
            result.Garden = funcMain28(p51.Garden, result.Garden);
            result.Id = p51.Id;
            result.CreatedOn = p51.CreatedOn;
            return result;
            
        }
        
        private static Account funcMain30(AccountMerge p63, Account p64)
        {
            if (p63 == null)
            {
                return null;
            }
            Account result = p64 ?? new Account();
            
            if (p63.Email != null)
            {
                result.Email = p63.Email;
            }
            
            if (p63.Username != null)
            {
                result.Username = p63.Username;
            }
            
            if (p63.DisplayName != null)
            {
                result.DisplayName = p63.DisplayName;
            }
            
            if (p63.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p63.ProfileIntroduction;
            }
            
            if (p63.ProfilePicure != null)
            {
                result.ProfilePicure = p63.ProfilePicure;
            }
            
            if (p63.UserObjectIdAzureAd != null)
            {
                result.UserObjectIdAzureAd = p63.UserObjectIdAzureAd;
            }
            
            if (p63.UserIdentityProvider != null)
            {
                result.UserIdentityProvider = p63.UserIdentityProvider;
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain2(ICollection<AccountRoles> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p3.Count);
            
            IEnumerator<AccountRoles> enumerator = p3.GetEnumerator();
            
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
        
        private static AccountDto funcMain4(Account p5)
        {
            return p5 == null ? null : new AccountDto()
            {
                Email = p5.Email,
                Username = p5.Username,
                DisplayName = p5.DisplayName,
                ProfileIntroduction = p5.ProfileIntroduction,
                ProfilePicure = p5.ProfilePicure,
                UserObjectIdAzureAd = p5.UserObjectIdAzureAd,
                UserIdentityProvider = p5.UserIdentityProvider,
                Roles = funcMain5(p5.Roles),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn,
                DeletedAt = p5.DeletedAt
            };
        }
        
        private static AccountDto funcMain7(Account p8)
        {
            return p8 == null ? null : new AccountDto()
            {
                Email = p8.Email,
                Username = p8.Username,
                DisplayName = p8.DisplayName,
                ProfileIntroduction = p8.ProfileIntroduction,
                ProfilePicure = p8.ProfilePicure,
                UserObjectIdAzureAd = p8.UserObjectIdAzureAd,
                UserIdentityProvider = p8.UserIdentityProvider,
                Roles = funcMain8(p8.Roles),
                Id = p8.Id,
                CreatedOn = p8.CreatedOn,
                UpdatedOn = p8.UpdatedOn,
                DeletedAt = p8.DeletedAt
            };
        }
        
        private static GardenDto funcMain9(Garden p10)
        {
            return p10 == null ? null : new GardenDto()
            {
                Name = p10.Name,
                AccountId = p10.AccountId,
                Account = funcMain10(p10.Account),
                Visibility = Enum<Visibility>.ToString(p10.Visibility),
                Id = p10.Id,
                CreatedOn = p10.CreatedOn,
                UpdatedOn = p10.UpdatedOn,
                DeletedAt = p10.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain13(ICollection<AccountRoles> p17, ICollection<AccountRolesDto> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p17.Count);
            
            IEnumerator<AccountRoles> enumerator = p17.GetEnumerator();
            
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
        
        private static AccountDto funcMain15(Account p21, AccountDto p22)
        {
            if (p21 == null)
            {
                return null;
            }
            AccountDto result = p22 ?? new AccountDto();
            
            result.Email = p21.Email;
            result.Username = p21.Username;
            result.DisplayName = p21.DisplayName;
            result.ProfileIntroduction = p21.ProfileIntroduction;
            result.ProfilePicure = p21.ProfilePicure;
            result.UserObjectIdAzureAd = p21.UserObjectIdAzureAd;
            result.UserIdentityProvider = p21.UserIdentityProvider;
            result.Roles = funcMain16(p21.Roles, result.Roles);
            result.Id = p21.Id;
            result.CreatedOn = p21.CreatedOn;
            result.UpdatedOn = p21.UpdatedOn;
            result.DeletedAt = p21.DeletedAt;
            return result;
            
        }
        
        private static AccountDto funcMain18(Account p27, AccountDto p28)
        {
            if (p27 == null)
            {
                return null;
            }
            AccountDto result = p28 ?? new AccountDto();
            
            result.Email = p27.Email;
            result.Username = p27.Username;
            result.DisplayName = p27.DisplayName;
            result.ProfileIntroduction = p27.ProfileIntroduction;
            result.ProfilePicure = p27.ProfilePicure;
            result.UserObjectIdAzureAd = p27.UserObjectIdAzureAd;
            result.UserIdentityProvider = p27.UserIdentityProvider;
            result.Roles = funcMain19(p27.Roles, result.Roles);
            result.Id = p27.Id;
            result.CreatedOn = p27.CreatedOn;
            result.UpdatedOn = p27.UpdatedOn;
            result.DeletedAt = p27.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain20(Garden p31, GardenDto p32)
        {
            if (p31 == null)
            {
                return null;
            }
            GardenDto result = p32 ?? new GardenDto();
            
            result.Name = p31.Name;
            result.AccountId = p31.AccountId;
            result.Account = funcMain21(p31.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p31.Visibility);
            result.Id = p31.Id;
            result.CreatedOn = p31.CreatedOn;
            result.UpdatedOn = p31.UpdatedOn;
            result.DeletedAt = p31.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain25(Account p49, AccountList p50)
        {
            if (p49 == null)
            {
                return null;
            }
            AccountList result = p50 ?? new AccountList();
            
            result.Email = p49.Email;
            result.Username = p49.Username;
            result.DisplayName = p49.DisplayName;
            result.ProfileIntroduction = p49.ProfileIntroduction;
            result.ProfilePicure = p49.ProfilePicure;
            result.UserObjectIdAzureAd = p49.UserObjectIdAzureAd;
            result.UserIdentityProvider = p49.UserIdentityProvider;
            result.Id = p49.Id;
            result.CreatedOn = p49.CreatedOn;
            return result;
            
        }
        
        private static AccountList funcMain27(Account p53, AccountList p54)
        {
            if (p53 == null)
            {
                return null;
            }
            AccountList result = p54 ?? new AccountList();
            
            result.Email = p53.Email;
            result.Username = p53.Username;
            result.DisplayName = p53.DisplayName;
            result.ProfileIntroduction = p53.ProfileIntroduction;
            result.ProfilePicure = p53.ProfilePicure;
            result.UserObjectIdAzureAd = p53.UserObjectIdAzureAd;
            result.UserIdentityProvider = p53.UserIdentityProvider;
            result.Id = p53.Id;
            result.CreatedOn = p53.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain28(Garden p55, GardenList p56)
        {
            if (p55 == null)
            {
                return null;
            }
            GardenList result = p56 ?? new GardenList();
            
            result.Name = p55.Name;
            result.AccountId = p55.AccountId;
            result.Account = funcMain29(p55.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p55.Visibility);
            result.Id = p55.Id;
            result.CreatedOn = p55.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain5(ICollection<AccountRoles> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p6.Count);
            
            IEnumerator<AccountRoles> enumerator = p6.GetEnumerator();
            
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
        
        private static ICollection<AccountRolesDto> funcMain8(ICollection<AccountRoles> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p9.Count);
            
            IEnumerator<AccountRoles> enumerator = p9.GetEnumerator();
            
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
        
        private static AccountDto funcMain10(Account p11)
        {
            return p11 == null ? null : new AccountDto()
            {
                Email = p11.Email,
                Username = p11.Username,
                DisplayName = p11.DisplayName,
                ProfileIntroduction = p11.ProfileIntroduction,
                ProfilePicure = p11.ProfilePicure,
                UserObjectIdAzureAd = p11.UserObjectIdAzureAd,
                UserIdentityProvider = p11.UserIdentityProvider,
                Roles = funcMain11(p11.Roles),
                Id = p11.Id,
                CreatedOn = p11.CreatedOn,
                UpdatedOn = p11.UpdatedOn,
                DeletedAt = p11.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain16(ICollection<AccountRoles> p23, ICollection<AccountRolesDto> p24)
        {
            if (p23 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p23.Count);
            
            IEnumerator<AccountRoles> enumerator = p23.GetEnumerator();
            
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
        
        private static ICollection<AccountRolesDto> funcMain19(ICollection<AccountRoles> p29, ICollection<AccountRolesDto> p30)
        {
            if (p29 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p29.Count);
            
            IEnumerator<AccountRoles> enumerator = p29.GetEnumerator();
            
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
        
        private static AccountDto funcMain21(Account p33, AccountDto p34)
        {
            if (p33 == null)
            {
                return null;
            }
            AccountDto result = p34 ?? new AccountDto();
            
            result.Email = p33.Email;
            result.Username = p33.Username;
            result.DisplayName = p33.DisplayName;
            result.ProfileIntroduction = p33.ProfileIntroduction;
            result.ProfilePicure = p33.ProfilePicure;
            result.UserObjectIdAzureAd = p33.UserObjectIdAzureAd;
            result.UserIdentityProvider = p33.UserIdentityProvider;
            result.Roles = funcMain22(p33.Roles, result.Roles);
            result.Id = p33.Id;
            result.CreatedOn = p33.CreatedOn;
            result.UpdatedOn = p33.UpdatedOn;
            result.DeletedAt = p33.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain29(Account p57, AccountList p58)
        {
            if (p57 == null)
            {
                return null;
            }
            AccountList result = p58 ?? new AccountList();
            
            result.Email = p57.Email;
            result.Username = p57.Username;
            result.DisplayName = p57.DisplayName;
            result.ProfileIntroduction = p57.ProfileIntroduction;
            result.ProfilePicure = p57.ProfilePicure;
            result.UserObjectIdAzureAd = p57.UserObjectIdAzureAd;
            result.UserIdentityProvider = p57.UserIdentityProvider;
            result.Id = p57.Id;
            result.CreatedOn = p57.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain11(ICollection<AccountRoles> p12)
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
        
        private static ICollection<AccountRolesDto> funcMain22(ICollection<AccountRoles> p35, ICollection<AccountRolesDto> p36)
        {
            if (p35 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p35.Count);
            
            IEnumerator<AccountRoles> enumerator = p35.GetEnumerator();
            
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
    }
}