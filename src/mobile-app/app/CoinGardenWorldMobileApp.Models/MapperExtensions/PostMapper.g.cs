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
                Garden = funcMain4(p1.Garden),
                FlowerId = p1.FlowerId,
                Flower = funcMain8(p1.Flower),
                PostType = Enum<PostType>.ToString(p1.PostType),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static PostDto AdaptTo(this Post p17, PostDto p18)
        {
            if (p17 == null)
            {
                return null;
            }
            PostDto result = p18 ?? new PostDto();
            
            result.AccountId = p17.AccountId;
            result.Account = funcMain16(p17.Account, result.Account);
            result.Title = p17.Title;
            result.Content = p17.Content;
            result.LinkOrImageUrl = p17.LinkOrImageUrl;
            result.GardenId = p17.GardenId;
            result.Garden = funcMain19(p17.Garden, result.Garden);
            result.FlowerId = p17.FlowerId;
            result.Flower = funcMain23(p17.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p17.PostType);
            result.Visibility = Enum<Visibility>.ToString(p17.Visibility);
            result.Id = p17.Id;
            result.CreatedOn = p17.CreatedOn;
            result.UpdatedOn = p17.UpdatedOn;
            result.DeletedAt = p17.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p49 => new PostDto()
        {
            AccountId = p49.AccountId,
            Account = p49.Account == null ? null : new AccountDto()
            {
                Email = p49.Account.Email,
                Username = p49.Account.Username,
                DisplayName = p49.Account.DisplayName,
                ProfileIntroduction = p49.Account.ProfileIntroduction,
                ProfilePicure = p49.Account.ProfilePicure,
                Roles = p49.Account.Roles.Select<AccountRoles, AccountRolesDto>(p50 => new AccountRolesDto()
                {
                    AccountId = p50.AccountId,
                    RoleId = p50.RoleId,
                    Role = p50.Role == null ? null : new RoleDto()
                    {
                        Name = p50.Role.Name,
                        Description = p50.Role.Description,
                        Visibility = Enum<Visibility>.ToString(p50.Role.Visibility),
                        Id = p50.Role.Id,
                        CreatedOn = p50.Role.CreatedOn,
                        UpdatedOn = p50.Role.UpdatedOn,
                        DeletedAt = p50.Role.DeletedAt
                    },
                    Id = p50.Id,
                    CreatedOn = p50.CreatedOn,
                    UpdatedOn = p50.UpdatedOn,
                    DeletedAt = p50.DeletedAt
                }).ToList<AccountRolesDto>(),
                ExternalLogins = p49.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p51 => new AccountExternalLoginsDto()
                {
                    AccountId = p51.AccountId,
                    DisplayName = p51.DisplayName,
                    ObjectIdAzureAd = p51.ObjectIdAzureAd,
                    IdentityProvider = p51.IdentityProvider,
                    ProfilePictureUrl = p51.ProfilePictureUrl,
                    Id = p51.Id,
                    CreatedOn = p51.CreatedOn,
                    UpdatedOn = p51.UpdatedOn,
                    DeletedAt = p51.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p49.Account.Id,
                CreatedOn = p49.Account.CreatedOn,
                UpdatedOn = p49.Account.UpdatedOn,
                DeletedAt = p49.Account.DeletedAt
            },
            Title = p49.Title,
            Content = p49.Content,
            LinkOrImageUrl = p49.LinkOrImageUrl,
            GardenId = p49.GardenId,
            Garden = p49.Garden == null ? null : new GardenDto()
            {
                Name = p49.Garden.Name,
                AccountId = p49.Garden.AccountId,
                Account = p49.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p49.Garden.Account.Email,
                    Username = p49.Garden.Account.Username,
                    DisplayName = p49.Garden.Account.DisplayName,
                    ProfileIntroduction = p49.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p49.Garden.Account.ProfilePicure,
                    Roles = p49.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p52 => new AccountRolesDto()
                    {
                        AccountId = p52.AccountId,
                        RoleId = p52.RoleId,
                        Role = p52.Role == null ? null : new RoleDto()
                        {
                            Name = p52.Role.Name,
                            Description = p52.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p52.Role.Visibility),
                            Id = p52.Role.Id,
                            CreatedOn = p52.Role.CreatedOn,
                            UpdatedOn = p52.Role.UpdatedOn,
                            DeletedAt = p52.Role.DeletedAt
                        },
                        Id = p52.Id,
                        CreatedOn = p52.CreatedOn,
                        UpdatedOn = p52.UpdatedOn,
                        DeletedAt = p52.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    ExternalLogins = p49.Garden.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p53 => new AccountExternalLoginsDto()
                    {
                        AccountId = p53.AccountId,
                        DisplayName = p53.DisplayName,
                        ObjectIdAzureAd = p53.ObjectIdAzureAd,
                        IdentityProvider = p53.IdentityProvider,
                        ProfilePictureUrl = p53.ProfilePictureUrl,
                        Id = p53.Id,
                        CreatedOn = p53.CreatedOn,
                        UpdatedOn = p53.UpdatedOn,
                        DeletedAt = p53.DeletedAt
                    }).ToList<AccountExternalLoginsDto>(),
                    Id = p49.Garden.Account.Id,
                    CreatedOn = p49.Garden.Account.CreatedOn,
                    UpdatedOn = p49.Garden.Account.UpdatedOn,
                    DeletedAt = p49.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p49.Garden.Visibility),
                Id = p49.Garden.Id,
                CreatedOn = p49.Garden.CreatedOn,
                UpdatedOn = p49.Garden.UpdatedOn,
                DeletedAt = p49.Garden.DeletedAt
            },
            FlowerId = p49.FlowerId,
            Flower = p49.Flower == null ? null : new FlowerDto()
            {
                Name = p49.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p49.Flower.Visibility),
                AccountId = p49.Flower.AccountId,
                Account = p49.Flower.Account == null ? null : new AccountDto()
                {
                    Email = p49.Flower.Account.Email,
                    Username = p49.Flower.Account.Username,
                    DisplayName = p49.Flower.Account.DisplayName,
                    ProfileIntroduction = p49.Flower.Account.ProfileIntroduction,
                    ProfilePicure = p49.Flower.Account.ProfilePicure,
                    Roles = p49.Flower.Account.Roles.Select<AccountRoles, AccountRolesDto>(p54 => new AccountRolesDto()
                    {
                        AccountId = p54.AccountId,
                        RoleId = p54.RoleId,
                        Role = p54.Role == null ? null : new RoleDto()
                        {
                            Name = p54.Role.Name,
                            Description = p54.Role.Description,
                            Visibility = Enum<Visibility>.ToString(p54.Role.Visibility),
                            Id = p54.Role.Id,
                            CreatedOn = p54.Role.CreatedOn,
                            UpdatedOn = p54.Role.UpdatedOn,
                            DeletedAt = p54.Role.DeletedAt
                        },
                        Id = p54.Id,
                        CreatedOn = p54.CreatedOn,
                        UpdatedOn = p54.UpdatedOn,
                        DeletedAt = p54.DeletedAt
                    }).ToList<AccountRolesDto>(),
                    ExternalLogins = p49.Flower.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p55 => new AccountExternalLoginsDto()
                    {
                        AccountId = p55.AccountId,
                        DisplayName = p55.DisplayName,
                        ObjectIdAzureAd = p55.ObjectIdAzureAd,
                        IdentityProvider = p55.IdentityProvider,
                        ProfilePictureUrl = p55.ProfilePictureUrl,
                        Id = p55.Id,
                        CreatedOn = p55.CreatedOn,
                        UpdatedOn = p55.UpdatedOn,
                        DeletedAt = p55.DeletedAt
                    }).ToList<AccountExternalLoginsDto>(),
                    Id = p49.Flower.Account.Id,
                    CreatedOn = p49.Flower.Account.CreatedOn,
                    UpdatedOn = p49.Flower.Account.UpdatedOn,
                    DeletedAt = p49.Flower.Account.DeletedAt
                },
                GardenId = p49.Flower.GardenId,
                Garden = p49.Flower.Garden == null ? null : new GardenDto()
                {
                    Name = p49.Flower.Garden.Name,
                    AccountId = p49.Flower.Garden.AccountId,
                    Account = p49.Flower.Garden.Account == null ? null : new AccountDto()
                    {
                        Email = p49.Flower.Garden.Account.Email,
                        Username = p49.Flower.Garden.Account.Username,
                        DisplayName = p49.Flower.Garden.Account.DisplayName,
                        ProfileIntroduction = p49.Flower.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p49.Flower.Garden.Account.ProfilePicure,
                        Roles = p49.Flower.Garden.Account.Roles.Select<AccountRoles, AccountRolesDto>(p56 => new AccountRolesDto()
                        {
                            AccountId = p56.AccountId,
                            RoleId = p56.RoleId,
                            Role = p56.Role == null ? null : new RoleDto()
                            {
                                Name = p56.Role.Name,
                                Description = p56.Role.Description,
                                Visibility = Enum<Visibility>.ToString(p56.Role.Visibility),
                                Id = p56.Role.Id,
                                CreatedOn = p56.Role.CreatedOn,
                                UpdatedOn = p56.Role.UpdatedOn,
                                DeletedAt = p56.Role.DeletedAt
                            },
                            Id = p56.Id,
                            CreatedOn = p56.CreatedOn,
                            UpdatedOn = p56.UpdatedOn,
                            DeletedAt = p56.DeletedAt
                        }).ToList<AccountRolesDto>(),
                        ExternalLogins = p49.Flower.Garden.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p57 => new AccountExternalLoginsDto()
                        {
                            AccountId = p57.AccountId,
                            DisplayName = p57.DisplayName,
                            ObjectIdAzureAd = p57.ObjectIdAzureAd,
                            IdentityProvider = p57.IdentityProvider,
                            ProfilePictureUrl = p57.ProfilePictureUrl,
                            Id = p57.Id,
                            CreatedOn = p57.CreatedOn,
                            UpdatedOn = p57.UpdatedOn,
                            DeletedAt = p57.DeletedAt
                        }).ToList<AccountExternalLoginsDto>(),
                        Id = p49.Flower.Garden.Account.Id,
                        CreatedOn = p49.Flower.Garden.Account.CreatedOn,
                        UpdatedOn = p49.Flower.Garden.Account.UpdatedOn,
                        DeletedAt = p49.Flower.Garden.Account.DeletedAt
                    },
                    Visibility = Enum<Visibility>.ToString(p49.Flower.Garden.Visibility),
                    Id = p49.Flower.Garden.Id,
                    CreatedOn = p49.Flower.Garden.CreatedOn,
                    UpdatedOn = p49.Flower.Garden.UpdatedOn,
                    DeletedAt = p49.Flower.Garden.DeletedAt
                },
                Id = p49.Flower.Id,
                CreatedOn = p49.Flower.CreatedOn,
                UpdatedOn = p49.Flower.UpdatedOn,
                DeletedAt = p49.Flower.DeletedAt
            },
            PostType = Enum<PostType>.ToString(p49.PostType),
            Visibility = Enum<Visibility>.ToString(p49.Visibility),
            Id = p49.Id,
            CreatedOn = p49.CreatedOn,
            UpdatedOn = p49.UpdatedOn,
            DeletedAt = p49.DeletedAt
        };
        public static PostList AdaptToList(this Post p58)
        {
            return p58 == null ? null : new PostList()
            {
                AccountId = p58.AccountId,
                Account = p58.Account == null ? null : new AccountList()
                {
                    Email = p58.Account.Email,
                    Username = p58.Account.Username,
                    DisplayName = p58.Account.DisplayName,
                    ProfileIntroduction = p58.Account.ProfileIntroduction,
                    ProfilePicure = p58.Account.ProfilePicure,
                    Id = p58.Account.Id,
                    CreatedOn = p58.Account.CreatedOn
                },
                Title = p58.Title,
                Content = p58.Content,
                LinkOrImageUrl = p58.LinkOrImageUrl,
                GardenId = p58.GardenId,
                Garden = p58.Garden == null ? null : new GardenList()
                {
                    Name = p58.Garden.Name,
                    AccountId = p58.Garden.AccountId,
                    Account = p58.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p58.Garden.Account.Email,
                        Username = p58.Garden.Account.Username,
                        DisplayName = p58.Garden.Account.DisplayName,
                        ProfileIntroduction = p58.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p58.Garden.Account.ProfilePicure,
                        Id = p58.Garden.Account.Id,
                        CreatedOn = p58.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p58.Garden.Visibility),
                    Id = p58.Garden.Id,
                    CreatedOn = p58.Garden.CreatedOn
                },
                FlowerId = p58.FlowerId,
                Flower = p58.Flower == null ? null : new FlowerList()
                {
                    Name = p58.Flower.Name,
                    Visibility = Enum<Visibility>.ToString(p58.Flower.Visibility),
                    AccountId = p58.Flower.AccountId,
                    Account = p58.Flower.Account == null ? null : new AccountList()
                    {
                        Email = p58.Flower.Account.Email,
                        Username = p58.Flower.Account.Username,
                        DisplayName = p58.Flower.Account.DisplayName,
                        ProfileIntroduction = p58.Flower.Account.ProfileIntroduction,
                        ProfilePicure = p58.Flower.Account.ProfilePicure,
                        Id = p58.Flower.Account.Id,
                        CreatedOn = p58.Flower.Account.CreatedOn
                    },
                    GardenId = p58.Flower.GardenId,
                    Garden = p58.Flower.Garden == null ? null : new GardenList()
                    {
                        Name = p58.Flower.Garden.Name,
                        AccountId = p58.Flower.Garden.AccountId,
                        Account = p58.Flower.Garden.Account == null ? null : new AccountList()
                        {
                            Email = p58.Flower.Garden.Account.Email,
                            Username = p58.Flower.Garden.Account.Username,
                            DisplayName = p58.Flower.Garden.Account.DisplayName,
                            ProfileIntroduction = p58.Flower.Garden.Account.ProfileIntroduction,
                            ProfilePicure = p58.Flower.Garden.Account.ProfilePicure,
                            Id = p58.Flower.Garden.Account.Id,
                            CreatedOn = p58.Flower.Garden.Account.CreatedOn
                        },
                        Visibility = Enum<Visibility>.ToString(p58.Flower.Garden.Visibility),
                        Id = p58.Flower.Garden.Id,
                        CreatedOn = p58.Flower.Garden.CreatedOn
                    },
                    Id = p58.Flower.Id,
                    CreatedOn = p58.Flower.CreatedOn
                },
                PostType = Enum<PostType>.ToString(p58.PostType),
                Visibility = Enum<Visibility>.ToString(p58.Visibility),
                Id = p58.Id,
                CreatedOn = p58.CreatedOn
            };
        }
        public static PostList AdaptTo(this Post p59, PostList p60)
        {
            if (p59 == null)
            {
                return null;
            }
            PostList result = p60 ?? new PostList();
            
            result.AccountId = p59.AccountId;
            result.Account = funcMain31(p59.Account, result.Account);
            result.Title = p59.Title;
            result.Content = p59.Content;
            result.LinkOrImageUrl = p59.LinkOrImageUrl;
            result.GardenId = p59.GardenId;
            result.Garden = funcMain32(p59.Garden, result.Garden);
            result.FlowerId = p59.FlowerId;
            result.Flower = funcMain34(p59.Flower, result.Flower);
            result.PostType = Enum<PostType>.ToString(p59.PostType);
            result.Visibility = Enum<Visibility>.ToString(p59.Visibility);
            result.Id = p59.Id;
            result.CreatedOn = p59.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Post, PostList>> ProjectToList => p75 => new PostList()
        {
            AccountId = p75.AccountId,
            Account = p75.Account == null ? null : new AccountList()
            {
                Email = p75.Account.Email,
                Username = p75.Account.Username,
                DisplayName = p75.Account.DisplayName,
                ProfileIntroduction = p75.Account.ProfileIntroduction,
                ProfilePicure = p75.Account.ProfilePicure,
                Id = p75.Account.Id,
                CreatedOn = p75.Account.CreatedOn
            },
            Title = p75.Title,
            Content = p75.Content,
            LinkOrImageUrl = p75.LinkOrImageUrl,
            GardenId = p75.GardenId,
            Garden = p75.Garden == null ? null : new GardenList()
            {
                Name = p75.Garden.Name,
                AccountId = p75.Garden.AccountId,
                Account = p75.Garden.Account == null ? null : new AccountList()
                {
                    Email = p75.Garden.Account.Email,
                    Username = p75.Garden.Account.Username,
                    DisplayName = p75.Garden.Account.DisplayName,
                    ProfileIntroduction = p75.Garden.Account.ProfileIntroduction,
                    ProfilePicure = p75.Garden.Account.ProfilePicure,
                    Id = p75.Garden.Account.Id,
                    CreatedOn = p75.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p75.Garden.Visibility),
                Id = p75.Garden.Id,
                CreatedOn = p75.Garden.CreatedOn
            },
            FlowerId = p75.FlowerId,
            Flower = p75.Flower == null ? null : new FlowerList()
            {
                Name = p75.Flower.Name,
                Visibility = Enum<Visibility>.ToString(p75.Flower.Visibility),
                AccountId = p75.Flower.AccountId,
                Account = p75.Flower.Account == null ? null : new AccountList()
                {
                    Email = p75.Flower.Account.Email,
                    Username = p75.Flower.Account.Username,
                    DisplayName = p75.Flower.Account.DisplayName,
                    ProfileIntroduction = p75.Flower.Account.ProfileIntroduction,
                    ProfilePicure = p75.Flower.Account.ProfilePicure,
                    Id = p75.Flower.Account.Id,
                    CreatedOn = p75.Flower.Account.CreatedOn
                },
                GardenId = p75.Flower.GardenId,
                Garden = p75.Flower.Garden == null ? null : new GardenList()
                {
                    Name = p75.Flower.Garden.Name,
                    AccountId = p75.Flower.Garden.AccountId,
                    Account = p75.Flower.Garden.Account == null ? null : new AccountList()
                    {
                        Email = p75.Flower.Garden.Account.Email,
                        Username = p75.Flower.Garden.Account.Username,
                        DisplayName = p75.Flower.Garden.Account.DisplayName,
                        ProfileIntroduction = p75.Flower.Garden.Account.ProfileIntroduction,
                        ProfilePicure = p75.Flower.Garden.Account.ProfilePicure,
                        Id = p75.Flower.Garden.Account.Id,
                        CreatedOn = p75.Flower.Garden.Account.CreatedOn
                    },
                    Visibility = Enum<Visibility>.ToString(p75.Flower.Garden.Visibility),
                    Id = p75.Flower.Garden.Id,
                    CreatedOn = p75.Flower.Garden.CreatedOn
                },
                Id = p75.Flower.Id,
                CreatedOn = p75.Flower.CreatedOn
            },
            PostType = Enum<PostType>.ToString(p75.PostType),
            Visibility = Enum<Visibility>.ToString(p75.Visibility),
            Id = p75.Id,
            CreatedOn = p75.CreatedOn
        };
        public static Post AdaptToPost(this PostAdd p76)
        {
            return p76 == null ? null : new Post()
            {
                AccountId = p76.AccountId,
                Account = p76.Account == null ? null : new Account()
                {
                    Email = p76.Account.Email,
                    Username = p76.Account.Username,
                    DisplayName = p76.Account.DisplayName,
                    ProfileIntroduction = p76.Account.ProfileIntroduction,
                    ProfilePicure = p76.Account.ProfilePicure
                },
                Title = p76.Title,
                Content = p76.Content,
                LinkOrImageUrl = p76.LinkOrImageUrl,
                GardenId = p76.GardenId,
                FlowerId = p76.FlowerId,
                PostType = p76.PostType == null ? PostType.Text : Enum<PostType>.Parse(p76.PostType),
                Visibility = p76.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p76.Visibility)
            };
        }
        public static Post AdaptTo(this PostMerge p77, Post p78)
        {
            if (p77 == null)
            {
                return null;
            }
            Post result = p78 ?? new Post();
            
            if (p77.AccountId != null)
            {
                result.AccountId = (Guid)p77.AccountId;
            }
            
            if (p77.Account != null)
            {
                result.Account = funcMain38(p77.Account, result.Account);
            }
            
            if (p77.Title != null)
            {
                result.Title = p77.Title;
            }
            
            if (p77.Content != null)
            {
                result.Content = p77.Content;
            }
            
            if (p77.LinkOrImageUrl != null)
            {
                result.LinkOrImageUrl = p77.LinkOrImageUrl;
            }
            
            if (p77.GardenId != null)
            {
                result.GardenId = p77.GardenId;
            }
            
            if (p77.FlowerId != null)
            {
                result.FlowerId = p77.FlowerId;
            }
            
            if (p77.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p77.PostType);
            }
            
            if (p77.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p77.Visibility);
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
                Roles = funcMain2(p2.Roles),
                ExternalLogins = funcMain3(p2.ExternalLogins),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static GardenDto funcMain4(Garden p5)
        {
            return p5 == null ? null : new GardenDto()
            {
                Name = p5.Name,
                AccountId = p5.AccountId,
                Account = funcMain5(p5.Account),
                Visibility = Enum<Visibility>.ToString(p5.Visibility),
                Id = p5.Id,
                CreatedOn = p5.CreatedOn,
                UpdatedOn = p5.UpdatedOn,
                DeletedAt = p5.DeletedAt
            };
        }
        
        private static FlowerDto funcMain8(Flower p9)
        {
            return p9 == null ? null : new FlowerDto()
            {
                Name = p9.Name,
                Visibility = Enum<Visibility>.ToString(p9.Visibility),
                AccountId = p9.AccountId,
                Account = funcMain9(p9.Account),
                GardenId = p9.GardenId,
                Garden = funcMain12(p9.Garden),
                Id = p9.Id,
                CreatedOn = p9.CreatedOn,
                UpdatedOn = p9.UpdatedOn,
                DeletedAt = p9.DeletedAt
            };
        }
        
        private static AccountDto funcMain16(Account p19, AccountDto p20)
        {
            if (p19 == null)
            {
                return null;
            }
            AccountDto result = p20 ?? new AccountDto();
            
            result.Email = p19.Email;
            result.Username = p19.Username;
            result.DisplayName = p19.DisplayName;
            result.ProfileIntroduction = p19.ProfileIntroduction;
            result.ProfilePicure = p19.ProfilePicure;
            result.Roles = funcMain17(p19.Roles, result.Roles);
            result.ExternalLogins = funcMain18(p19.ExternalLogins, result.ExternalLogins);
            result.Id = p19.Id;
            result.CreatedOn = p19.CreatedOn;
            result.UpdatedOn = p19.UpdatedOn;
            result.DeletedAt = p19.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain19(Garden p25, GardenDto p26)
        {
            if (p25 == null)
            {
                return null;
            }
            GardenDto result = p26 ?? new GardenDto();
            
            result.Name = p25.Name;
            result.AccountId = p25.AccountId;
            result.Account = funcMain20(p25.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p25.Visibility);
            result.Id = p25.Id;
            result.CreatedOn = p25.CreatedOn;
            result.UpdatedOn = p25.UpdatedOn;
            result.DeletedAt = p25.DeletedAt;
            return result;
            
        }
        
        private static FlowerDto funcMain23(Flower p33, FlowerDto p34)
        {
            if (p33 == null)
            {
                return null;
            }
            FlowerDto result = p34 ?? new FlowerDto();
            
            result.Name = p33.Name;
            result.Visibility = Enum<Visibility>.ToString(p33.Visibility);
            result.AccountId = p33.AccountId;
            result.Account = funcMain24(p33.Account, result.Account);
            result.GardenId = p33.GardenId;
            result.Garden = funcMain27(p33.Garden, result.Garden);
            result.Id = p33.Id;
            result.CreatedOn = p33.CreatedOn;
            result.UpdatedOn = p33.UpdatedOn;
            result.DeletedAt = p33.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain31(Account p61, AccountList p62)
        {
            if (p61 == null)
            {
                return null;
            }
            AccountList result = p62 ?? new AccountList();
            
            result.Email = p61.Email;
            result.Username = p61.Username;
            result.DisplayName = p61.DisplayName;
            result.ProfileIntroduction = p61.ProfileIntroduction;
            result.ProfilePicure = p61.ProfilePicure;
            result.Id = p61.Id;
            result.CreatedOn = p61.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain32(Garden p63, GardenList p64)
        {
            if (p63 == null)
            {
                return null;
            }
            GardenList result = p64 ?? new GardenList();
            
            result.Name = p63.Name;
            result.AccountId = p63.AccountId;
            result.Account = funcMain33(p63.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p63.Visibility);
            result.Id = p63.Id;
            result.CreatedOn = p63.CreatedOn;
            return result;
            
        }
        
        private static FlowerList funcMain34(Flower p67, FlowerList p68)
        {
            if (p67 == null)
            {
                return null;
            }
            FlowerList result = p68 ?? new FlowerList();
            
            result.Name = p67.Name;
            result.Visibility = Enum<Visibility>.ToString(p67.Visibility);
            result.AccountId = p67.AccountId;
            result.Account = funcMain35(p67.Account, result.Account);
            result.GardenId = p67.GardenId;
            result.Garden = funcMain36(p67.Garden, result.Garden);
            result.Id = p67.Id;
            result.CreatedOn = p67.CreatedOn;
            return result;
            
        }
        
        private static Account funcMain38(AccountMerge p79, Account p80)
        {
            if (p79 == null)
            {
                return null;
            }
            Account result = p80 ?? new Account();
            
            if (p79.Email != null)
            {
                result.Email = p79.Email;
            }
            
            if (p79.Username != null)
            {
                result.Username = p79.Username;
            }
            
            if (p79.DisplayName != null)
            {
                result.DisplayName = p79.DisplayName;
            }
            
            if (p79.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p79.ProfileIntroduction;
            }
            
            if (p79.ProfilePicure != null)
            {
                result.ProfilePicure = p79.ProfilePicure;
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain3(ICollection<AccountExternalLogins> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p4.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static AccountDto funcMain5(Account p6)
        {
            return p6 == null ? null : new AccountDto()
            {
                Email = p6.Email,
                Username = p6.Username,
                DisplayName = p6.DisplayName,
                ProfileIntroduction = p6.ProfileIntroduction,
                ProfilePicure = p6.ProfilePicure,
                Roles = funcMain6(p6.Roles),
                ExternalLogins = funcMain7(p6.ExternalLogins),
                Id = p6.Id,
                CreatedOn = p6.CreatedOn,
                UpdatedOn = p6.UpdatedOn,
                DeletedAt = p6.DeletedAt
            };
        }
        
        private static AccountDto funcMain9(Account p10)
        {
            return p10 == null ? null : new AccountDto()
            {
                Email = p10.Email,
                Username = p10.Username,
                DisplayName = p10.DisplayName,
                ProfileIntroduction = p10.ProfileIntroduction,
                ProfilePicure = p10.ProfilePicure,
                Roles = funcMain10(p10.Roles),
                ExternalLogins = funcMain11(p10.ExternalLogins),
                Id = p10.Id,
                CreatedOn = p10.CreatedOn,
                UpdatedOn = p10.UpdatedOn,
                DeletedAt = p10.DeletedAt
            };
        }
        
        private static GardenDto funcMain12(Garden p13)
        {
            return p13 == null ? null : new GardenDto()
            {
                Name = p13.Name,
                AccountId = p13.AccountId,
                Account = funcMain13(p13.Account),
                Visibility = Enum<Visibility>.ToString(p13.Visibility),
                Id = p13.Id,
                CreatedOn = p13.CreatedOn,
                UpdatedOn = p13.UpdatedOn,
                DeletedAt = p13.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain17(ICollection<AccountRoles> p21, ICollection<AccountRolesDto> p22)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p21.Count);
            
            IEnumerator<AccountRoles> enumerator = p21.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain18(ICollection<AccountExternalLogins> p23, ICollection<AccountExternalLoginsDto> p24)
        {
            if (p23 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p23.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p23.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static AccountDto funcMain20(Account p27, AccountDto p28)
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
            result.Roles = funcMain21(p27.Roles, result.Roles);
            result.ExternalLogins = funcMain22(p27.ExternalLogins, result.ExternalLogins);
            result.Id = p27.Id;
            result.CreatedOn = p27.CreatedOn;
            result.UpdatedOn = p27.UpdatedOn;
            result.DeletedAt = p27.DeletedAt;
            return result;
            
        }
        
        private static AccountDto funcMain24(Account p35, AccountDto p36)
        {
            if (p35 == null)
            {
                return null;
            }
            AccountDto result = p36 ?? new AccountDto();
            
            result.Email = p35.Email;
            result.Username = p35.Username;
            result.DisplayName = p35.DisplayName;
            result.ProfileIntroduction = p35.ProfileIntroduction;
            result.ProfilePicure = p35.ProfilePicure;
            result.Roles = funcMain25(p35.Roles, result.Roles);
            result.ExternalLogins = funcMain26(p35.ExternalLogins, result.ExternalLogins);
            result.Id = p35.Id;
            result.CreatedOn = p35.CreatedOn;
            result.UpdatedOn = p35.UpdatedOn;
            result.DeletedAt = p35.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain27(Garden p41, GardenDto p42)
        {
            if (p41 == null)
            {
                return null;
            }
            GardenDto result = p42 ?? new GardenDto();
            
            result.Name = p41.Name;
            result.AccountId = p41.AccountId;
            result.Account = funcMain28(p41.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p41.Visibility);
            result.Id = p41.Id;
            result.CreatedOn = p41.CreatedOn;
            result.UpdatedOn = p41.UpdatedOn;
            result.DeletedAt = p41.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain33(Account p65, AccountList p66)
        {
            if (p65 == null)
            {
                return null;
            }
            AccountList result = p66 ?? new AccountList();
            
            result.Email = p65.Email;
            result.Username = p65.Username;
            result.DisplayName = p65.DisplayName;
            result.ProfileIntroduction = p65.ProfileIntroduction;
            result.ProfilePicure = p65.ProfilePicure;
            result.Id = p65.Id;
            result.CreatedOn = p65.CreatedOn;
            return result;
            
        }
        
        private static AccountList funcMain35(Account p69, AccountList p70)
        {
            if (p69 == null)
            {
                return null;
            }
            AccountList result = p70 ?? new AccountList();
            
            result.Email = p69.Email;
            result.Username = p69.Username;
            result.DisplayName = p69.DisplayName;
            result.ProfileIntroduction = p69.ProfileIntroduction;
            result.ProfilePicure = p69.ProfilePicure;
            result.Id = p69.Id;
            result.CreatedOn = p69.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain36(Garden p71, GardenList p72)
        {
            if (p71 == null)
            {
                return null;
            }
            GardenList result = p72 ?? new GardenList();
            
            result.Name = p71.Name;
            result.AccountId = p71.AccountId;
            result.Account = funcMain37(p71.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p71.Visibility);
            result.Id = p71.Id;
            result.CreatedOn = p71.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain6(ICollection<AccountRoles> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p7.Count);
            
            IEnumerator<AccountRoles> enumerator = p7.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain7(ICollection<AccountExternalLogins> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p8.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain10(ICollection<AccountRoles> p11)
        {
            if (p11 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p11.Count);
            
            IEnumerator<AccountRoles> enumerator = p11.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain11(ICollection<AccountExternalLogins> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p12.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p12.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static AccountDto funcMain13(Account p14)
        {
            return p14 == null ? null : new AccountDto()
            {
                Email = p14.Email,
                Username = p14.Username,
                DisplayName = p14.DisplayName,
                ProfileIntroduction = p14.ProfileIntroduction,
                ProfilePicure = p14.ProfilePicure,
                Roles = funcMain14(p14.Roles),
                ExternalLogins = funcMain15(p14.ExternalLogins),
                Id = p14.Id,
                CreatedOn = p14.CreatedOn,
                UpdatedOn = p14.UpdatedOn,
                DeletedAt = p14.DeletedAt
            };
        }
        
        private static ICollection<AccountRolesDto> funcMain21(ICollection<AccountRoles> p29, ICollection<AccountRolesDto> p30)
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain22(ICollection<AccountExternalLogins> p31, ICollection<AccountExternalLoginsDto> p32)
        {
            if (p31 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p31.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p31.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain25(ICollection<AccountRoles> p37, ICollection<AccountRolesDto> p38)
        {
            if (p37 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p37.Count);
            
            IEnumerator<AccountRoles> enumerator = p37.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain26(ICollection<AccountExternalLogins> p39, ICollection<AccountExternalLoginsDto> p40)
        {
            if (p39 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p39.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p39.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static AccountDto funcMain28(Account p43, AccountDto p44)
        {
            if (p43 == null)
            {
                return null;
            }
            AccountDto result = p44 ?? new AccountDto();
            
            result.Email = p43.Email;
            result.Username = p43.Username;
            result.DisplayName = p43.DisplayName;
            result.ProfileIntroduction = p43.ProfileIntroduction;
            result.ProfilePicure = p43.ProfilePicure;
            result.Roles = funcMain29(p43.Roles, result.Roles);
            result.ExternalLogins = funcMain30(p43.ExternalLogins, result.ExternalLogins);
            result.Id = p43.Id;
            result.CreatedOn = p43.CreatedOn;
            result.UpdatedOn = p43.UpdatedOn;
            result.DeletedAt = p43.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain37(Account p73, AccountList p74)
        {
            if (p73 == null)
            {
                return null;
            }
            AccountList result = p74 ?? new AccountList();
            
            result.Email = p73.Email;
            result.Username = p73.Username;
            result.DisplayName = p73.DisplayName;
            result.ProfileIntroduction = p73.ProfileIntroduction;
            result.ProfilePicure = p73.ProfilePicure;
            result.Id = p73.Id;
            result.CreatedOn = p73.CreatedOn;
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain14(ICollection<AccountRoles> p15)
        {
            if (p15 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p15.Count);
            
            IEnumerator<AccountRoles> enumerator = p15.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain15(ICollection<AccountExternalLogins> p16)
        {
            if (p16 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p16.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p16.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<AccountRolesDto> funcMain29(ICollection<AccountRoles> p45, ICollection<AccountRolesDto> p46)
        {
            if (p45 == null)
            {
                return null;
            }
            ICollection<AccountRolesDto> result = new List<AccountRolesDto>(p45.Count);
            
            IEnumerator<AccountRoles> enumerator = p45.GetEnumerator();
            
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
        
        private static ICollection<AccountExternalLoginsDto> funcMain30(ICollection<AccountExternalLogins> p47, ICollection<AccountExternalLoginsDto> p48)
        {
            if (p47 == null)
            {
                return null;
            }
            ICollection<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p47.Count);
            
            IEnumerator<AccountExternalLogins> enumerator = p47.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                AccountExternalLogins item = enumerator.Current;
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
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