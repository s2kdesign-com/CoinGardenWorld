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
                ExternalUrl = p1.ExternalUrl,
                Images = funcMain5(p1.Images),
                PostType = Enum<PostType>.ToString(p1.PostType),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static PostDto AdaptTo(this Post p7, PostDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            PostDto result = p8 ?? new PostDto();
            
            result.AccountId = p7.AccountId;
            result.Account = funcMain6(p7.Account, result.Account);
            result.Title = p7.Title;
            result.Content = p7.Content;
            result.ExternalUrl = p7.ExternalUrl;
            result.Images = funcMain11(p7.Images, result.Images);
            result.PostType = Enum<PostType>.ToString(p7.PostType);
            result.Visibility = Enum<Visibility>.ToString(p7.Visibility);
            result.Id = p7.Id;
            result.CreatedOn = p7.CreatedOn;
            result.UpdatedOn = p7.UpdatedOn;
            result.DeletedAt = p7.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Post, PostDto>> ProjectToDto => p21 => new PostDto()
        {
            AccountId = p21.AccountId,
            Account = new AccountDto()
            {
                Email = p21.Account.Email,
                Username = p21.Account.Username,
                DisplayName = p21.Account.DisplayName,
                ProfileIntroduction = p21.Account.ProfileIntroduction,
                ProfilePicture = p21.Account.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p21.Account.ProfilePicture.ImageId,
                    ImageUrl = p21.Account.ProfilePicture.ImageUrl
                },
                Badges = p21.Account.Badges.Select<AccountBadge, AccountBadgeDto>(p22 => new AccountBadgeDto()
                {
                    BadgeId = p22.BadgeId,
                    BadgeName = p22.BadgeName,
                    BadgeIcon = p22.BadgeIcon,
                    BadgeColor = p22.BadgeColor,
                    EarnedOn = p22.EarnedOn
                }).ToList<AccountBadgeDto>(),
                Roles = p21.Account.Roles.Select<AccountRole, AccountRoleDto>(p23 => new AccountRoleDto()
                {
                    RoleId = p23.RoleId,
                    RoleName = p23.RoleName,
                    AssignedOn = p23.AssignedOn
                }).ToList<AccountRoleDto>(),
                ExternalLogins = p21.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p24 => new AccountExternalLoginsDto()
                {
                    ObjectIdAzureAd = p24.ObjectIdAzureAd,
                    AccountId = p24.AccountId,
                    DisplayName = p24.DisplayName,
                    IdentityProvider = p24.IdentityProvider,
                    ProfilePictureUrl = p24.ProfilePictureUrl,
                    Id = p24.Id,
                    CreatedOn = p24.CreatedOn,
                    UpdatedOn = p24.UpdatedOn,
                    DeletedAt = p24.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p21.Account.Id,
                CreatedOn = p21.Account.CreatedOn,
                UpdatedOn = p21.Account.UpdatedOn,
                DeletedAt = p21.Account.DeletedAt
            },
            Title = p21.Title,
            Content = p21.Content,
            ExternalUrl = p21.ExternalUrl,
            Images = p21.Images.Select<BlobImage, BlobImageDto>(p25 => new BlobImageDto()
            {
                ImageId = p25.ImageId,
                ImageUrl = p25.ImageUrl
            }).ToList<BlobImageDto>(),
            PostType = Enum<PostType>.ToString(p21.PostType),
            Visibility = Enum<Visibility>.ToString(p21.Visibility),
            Id = p21.Id,
            CreatedOn = p21.CreatedOn,
            UpdatedOn = p21.UpdatedOn,
            DeletedAt = p21.DeletedAt
        };
        public static PostList AdaptToList(this Post p26)
        {
            return p26 == null ? null : new PostList()
            {
                AccountId = p26.AccountId,
                Account = funcMain12(p26.Account),
                Title = p26.Title,
                Content = p26.Content,
                ExternalUrl = p26.ExternalUrl,
                Images = funcMain15(p26.Images),
                PostType = Enum<PostType>.ToString(p26.PostType),
                Visibility = Enum<Visibility>.ToString(p26.Visibility),
                Id = p26.Id,
                CreatedOn = p26.CreatedOn
            };
        }
        public static PostList AdaptTo(this Post p31, PostList p32)
        {
            if (p31 == null)
            {
                return null;
            }
            PostList result = p32 ?? new PostList();
            
            result.AccountId = p31.AccountId;
            result.Account = funcMain16(p31.Account, result.Account);
            result.Title = p31.Title;
            result.Content = p31.Content;
            result.ExternalUrl = p31.ExternalUrl;
            result.Images = funcMain20(p31.Images, result.Images);
            result.PostType = Enum<PostType>.ToString(p31.PostType);
            result.Visibility = Enum<Visibility>.ToString(p31.Visibility);
            result.Id = p31.Id;
            result.CreatedOn = p31.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Post, PostList>> ProjectToList => p43 => new PostList()
        {
            AccountId = p43.AccountId,
            Account = new AccountList()
            {
                Email = p43.Account.Email,
                Username = p43.Account.Username,
                DisplayName = p43.Account.DisplayName,
                ProfileIntroduction = p43.Account.ProfileIntroduction,
                ProfilePicture = p43.Account.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p43.Account.ProfilePicture.ImageId,
                    ImageUrl = p43.Account.ProfilePicture.ImageUrl
                },
                Badges = p43.Account.Badges.Select<AccountBadge, AccountBadgeList>(p44 => new AccountBadgeList()
                {
                    BadgeId = p44.BadgeId,
                    BadgeName = p44.BadgeName,
                    BadgeIcon = p44.BadgeIcon,
                    BadgeColor = p44.BadgeColor,
                    EarnedOn = p44.EarnedOn
                }).ToList<AccountBadgeList>(),
                Roles = p43.Account.Roles.Select<AccountRole, AccountRoleList>(p45 => new AccountRoleList()
                {
                    RoleId = p45.RoleId,
                    RoleName = p45.RoleName,
                    AssignedOn = p45.AssignedOn
                }).ToList<AccountRoleList>(),
                Id = p43.Account.Id,
                CreatedOn = p43.Account.CreatedOn
            },
            Title = p43.Title,
            Content = p43.Content,
            ExternalUrl = p43.ExternalUrl,
            Images = p43.Images.Select<BlobImage, BlobImageList>(p46 => new BlobImageList()
            {
                ImageId = p46.ImageId,
                ImageUrl = p46.ImageUrl
            }).ToList<BlobImageList>(),
            PostType = Enum<PostType>.ToString(p43.PostType),
            Visibility = Enum<Visibility>.ToString(p43.Visibility),
            Id = p43.Id,
            CreatedOn = p43.CreatedOn
        };
        public static Post AdaptToPost(this PostAdd p47)
        {
            return p47 == null ? null : new Post()
            {
                AccountId = p47.AccountId,
                Account = funcMain21(p47.Account),
                Title = p47.Title,
                Content = p47.Content,
                ExternalUrl = p47.ExternalUrl,
                Images = funcMain24(p47.Images),
                PostType = p47.PostType == null ? PostType.Text : Enum<PostType>.Parse(p47.PostType),
                Visibility = p47.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p47.Visibility)
            };
        }
        public static Post AdaptTo(this PostMerge p52, Post p53)
        {
            if (p52 == null)
            {
                return null;
            }
            Post result = p53 ?? new Post();
            
            if (p52.AccountId != null)
            {
                result.AccountId = (Guid)p52.AccountId;
            }
            
            if (p52.Account != null)
            {
                result.Account = funcMain25(p52.Account, result.Account);
            }
            
            if (p52.Title != null)
            {
                result.Title = p52.Title;
            }
            
            if (p52.Content != null)
            {
                result.Content = p52.Content;
            }
            
            if (p52.ExternalUrl != null)
            {
                result.ExternalUrl = p52.ExternalUrl;
            }
            
            if (p52.Images != null)
            {
                result.Images = funcMain31(p52.Images, result.Images);
            }
            
            if (p52.PostType != null)
            {
                result.PostType = Enum<PostType>.Parse(p52.PostType);
            }
            
            if (p52.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p52.Visibility);
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
                ProfilePicture = p2.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p2.ProfilePicture.ImageId,
                    ImageUrl = p2.ProfilePicture.ImageUrl
                },
                Badges = funcMain2(p2.Badges),
                Roles = funcMain3(p2.Roles),
                ExternalLogins = funcMain4(p2.ExternalLogins),
                Id = p2.Id,
                CreatedOn = p2.CreatedOn,
                UpdatedOn = p2.UpdatedOn,
                DeletedAt = p2.DeletedAt
            };
        }
        
        private static List<BlobImageDto> funcMain5(List<BlobImage> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            List<BlobImageDto> result = new List<BlobImageDto>(p6.Count);
            
            int i = 0;
            int len = p6.Count;
            
            while (i < len)
            {
                BlobImage item = p6[i];
                result.Add(item == null ? null : new BlobImageDto()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountDto funcMain6(Account p9, AccountDto p10)
        {
            if (p9 == null)
            {
                return null;
            }
            AccountDto result = p10 ?? new AccountDto();
            
            result.Email = p9.Email;
            result.Username = p9.Username;
            result.DisplayName = p9.DisplayName;
            result.ProfileIntroduction = p9.ProfileIntroduction;
            result.ProfilePicture = funcMain7(p9.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain8(p9.Badges, result.Badges);
            result.Roles = funcMain9(p9.Roles, result.Roles);
            result.ExternalLogins = funcMain10(p9.ExternalLogins, result.ExternalLogins);
            result.Id = p9.Id;
            result.CreatedOn = p9.CreatedOn;
            result.UpdatedOn = p9.UpdatedOn;
            result.DeletedAt = p9.DeletedAt;
            return result;
            
        }
        
        private static List<BlobImageDto> funcMain11(List<BlobImage> p19, List<BlobImageDto> p20)
        {
            if (p19 == null)
            {
                return null;
            }
            List<BlobImageDto> result = new List<BlobImageDto>(p19.Count);
            
            int i = 0;
            int len = p19.Count;
            
            while (i < len)
            {
                BlobImage item = p19[i];
                result.Add(item == null ? null : new BlobImageDto()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountList funcMain12(Account p27)
        {
            return p27 == null ? null : new AccountList()
            {
                Email = p27.Email,
                Username = p27.Username,
                DisplayName = p27.DisplayName,
                ProfileIntroduction = p27.ProfileIntroduction,
                ProfilePicture = p27.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p27.ProfilePicture.ImageId,
                    ImageUrl = p27.ProfilePicture.ImageUrl
                },
                Badges = funcMain13(p27.Badges),
                Roles = funcMain14(p27.Roles),
                Id = p27.Id,
                CreatedOn = p27.CreatedOn
            };
        }
        
        private static List<BlobImageList> funcMain15(List<BlobImage> p30)
        {
            if (p30 == null)
            {
                return null;
            }
            List<BlobImageList> result = new List<BlobImageList>(p30.Count);
            
            int i = 0;
            int len = p30.Count;
            
            while (i < len)
            {
                BlobImage item = p30[i];
                result.Add(item == null ? null : new BlobImageList()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountList funcMain16(Account p33, AccountList p34)
        {
            if (p33 == null)
            {
                return null;
            }
            AccountList result = p34 ?? new AccountList();
            
            result.Email = p33.Email;
            result.Username = p33.Username;
            result.DisplayName = p33.DisplayName;
            result.ProfileIntroduction = p33.ProfileIntroduction;
            result.ProfilePicture = funcMain17(p33.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain18(p33.Badges, result.Badges);
            result.Roles = funcMain19(p33.Roles, result.Roles);
            result.Id = p33.Id;
            result.CreatedOn = p33.CreatedOn;
            return result;
            
        }
        
        private static List<BlobImageList> funcMain20(List<BlobImage> p41, List<BlobImageList> p42)
        {
            if (p41 == null)
            {
                return null;
            }
            List<BlobImageList> result = new List<BlobImageList>(p41.Count);
            
            int i = 0;
            int len = p41.Count;
            
            while (i < len)
            {
                BlobImage item = p41[i];
                result.Add(item == null ? null : new BlobImageList()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static Account funcMain21(AccountAdd p48)
        {
            return p48 == null ? null : new Account()
            {
                Email = p48.Email,
                Username = p48.Username,
                DisplayName = p48.DisplayName,
                ProfileIntroduction = p48.ProfileIntroduction,
                ProfilePicture = p48.ProfilePicture == null ? null : new BlobImage()
                {
                    ImageId = p48.ProfilePicture.ImageId,
                    ImageUrl = p48.ProfilePicture.ImageUrl
                },
                Badges = funcMain22(p48.Badges),
                Roles = funcMain23(p48.Roles)
            };
        }
        
        private static List<BlobImage> funcMain24(List<BlobImageAdd> p51)
        {
            if (p51 == null)
            {
                return null;
            }
            List<BlobImage> result = new List<BlobImage>(p51.Count);
            
            int i = 0;
            int len = p51.Count;
            
            while (i < len)
            {
                BlobImageAdd item = p51[i];
                result.Add(item == null ? null : new BlobImage()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static Account funcMain25(AccountMerge p54, Account p55)
        {
            if (p54 == null)
            {
                return null;
            }
            Account result = p55 ?? new Account();
            
            if (p54.Email != null)
            {
                result.Email = p54.Email;
            }
            
            if (p54.Username != null)
            {
                result.Username = p54.Username;
            }
            
            if (p54.DisplayName != null)
            {
                result.DisplayName = p54.DisplayName;
            }
            
            if (p54.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p54.ProfileIntroduction;
            }
            
            if (p54.ProfilePicture != null)
            {
                result.ProfilePicture = funcMain26(p54.ProfilePicture, result.ProfilePicture);
            }
            
            if (p54.Badges != null)
            {
                result.Badges = funcMain27(p54.Badges, result.Badges);
            }
            
            if (p54.Roles != null)
            {
                result.Roles = funcMain29(p54.Roles, result.Roles);
            }
            return result;
            
        }
        
        private static List<BlobImage> funcMain31(List<BlobImageMerge> p64, List<BlobImage> p65)
        {
            if (p64 == null)
            {
                return null;
            }
            List<BlobImage> result = new List<BlobImage>(p64.Count);
            
            int i = 0;
            int len = p64.Count;
            
            while (i < len)
            {
                BlobImageMerge item = p64[i];
                result.Add(funcMain32(item));
                i++;
            }
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain2(List<AccountBadge> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p3.Count);
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                AccountBadge item = p3[i];
                result.Add(item == null ? null : new AccountBadgeDto()
                {
                    BadgeId = item.BadgeId,
                    BadgeName = item.BadgeName,
                    BadgeIcon = item.BadgeIcon,
                    BadgeColor = item.BadgeColor,
                    EarnedOn = item.EarnedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRoleDto> funcMain3(List<AccountRole> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p4.Count);
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                AccountRole item = p4[i];
                result.Add(item == null ? null : new AccountRoleDto()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName,
                    AssignedOn = item.AssignedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountExternalLoginsDto> funcMain4(List<AccountExternalLogins> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p5[i];
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static BlobImageDto funcMain7(BlobImage p11, BlobImageDto p12)
        {
            if (p11 == null)
            {
                return null;
            }
            BlobImageDto result = p12 ?? new BlobImageDto();
            
            result.ImageId = p11.ImageId;
            result.ImageUrl = p11.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain8(List<AccountBadge> p13, List<AccountBadgeDto> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p13.Count);
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                AccountBadge item = p13[i];
                result.Add(item == null ? null : new AccountBadgeDto()
                {
                    BadgeId = item.BadgeId,
                    BadgeName = item.BadgeName,
                    BadgeIcon = item.BadgeIcon,
                    BadgeColor = item.BadgeColor,
                    EarnedOn = item.EarnedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRoleDto> funcMain9(List<AccountRole> p15, List<AccountRoleDto> p16)
        {
            if (p15 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p15.Count);
            
            int i = 0;
            int len = p15.Count;
            
            while (i < len)
            {
                AccountRole item = p15[i];
                result.Add(item == null ? null : new AccountRoleDto()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName,
                    AssignedOn = item.AssignedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountExternalLoginsDto> funcMain10(List<AccountExternalLogins> p17, List<AccountExternalLoginsDto> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p17.Count);
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p17[i];
                result.Add(item == null ? null : new AccountExternalLoginsDto()
                {
                    ObjectIdAzureAd = item.ObjectIdAzureAd,
                    AccountId = item.AccountId,
                    DisplayName = item.DisplayName,
                    IdentityProvider = item.IdentityProvider,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Id = item.Id,
                    CreatedOn = item.CreatedOn,
                    UpdatedOn = item.UpdatedOn,
                    DeletedAt = item.DeletedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain13(List<AccountBadge> p28)
        {
            if (p28 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p28.Count);
            
            int i = 0;
            int len = p28.Count;
            
            while (i < len)
            {
                AccountBadge item = p28[i];
                result.Add(item == null ? null : new AccountBadgeList()
                {
                    BadgeId = item.BadgeId,
                    BadgeName = item.BadgeName,
                    BadgeIcon = item.BadgeIcon,
                    BadgeColor = item.BadgeColor,
                    EarnedOn = item.EarnedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRoleList> funcMain14(List<AccountRole> p29)
        {
            if (p29 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p29.Count);
            
            int i = 0;
            int len = p29.Count;
            
            while (i < len)
            {
                AccountRole item = p29[i];
                result.Add(item == null ? null : new AccountRoleList()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName,
                    AssignedOn = item.AssignedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static BlobImageList funcMain17(BlobImage p35, BlobImageList p36)
        {
            if (p35 == null)
            {
                return null;
            }
            BlobImageList result = p36 ?? new BlobImageList();
            
            result.ImageId = p35.ImageId;
            result.ImageUrl = p35.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain18(List<AccountBadge> p37, List<AccountBadgeList> p38)
        {
            if (p37 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p37.Count);
            
            int i = 0;
            int len = p37.Count;
            
            while (i < len)
            {
                AccountBadge item = p37[i];
                result.Add(item == null ? null : new AccountBadgeList()
                {
                    BadgeId = item.BadgeId,
                    BadgeName = item.BadgeName,
                    BadgeIcon = item.BadgeIcon,
                    BadgeColor = item.BadgeColor,
                    EarnedOn = item.EarnedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRoleList> funcMain19(List<AccountRole> p39, List<AccountRoleList> p40)
        {
            if (p39 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p39.Count);
            
            int i = 0;
            int len = p39.Count;
            
            while (i < len)
            {
                AccountRole item = p39[i];
                result.Add(item == null ? null : new AccountRoleList()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName,
                    AssignedOn = item.AssignedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountBadge> funcMain22(List<AccountBadgeAdd> p49)
        {
            if (p49 == null)
            {
                return null;
            }
            List<AccountBadge> result = new List<AccountBadge>(p49.Count);
            
            int i = 0;
            int len = p49.Count;
            
            while (i < len)
            {
                AccountBadgeAdd item = p49[i];
                result.Add(item == null ? null : new AccountBadge()
                {
                    BadgeId = item.BadgeId,
                    BadgeName = item.BadgeName,
                    BadgeIcon = item.BadgeIcon,
                    BadgeColor = item.BadgeColor,
                    EarnedOn = item.EarnedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRole> funcMain23(List<AccountRoleAdd> p50)
        {
            if (p50 == null)
            {
                return null;
            }
            List<AccountRole> result = new List<AccountRole>(p50.Count);
            
            int i = 0;
            int len = p50.Count;
            
            while (i < len)
            {
                AccountRoleAdd item = p50[i];
                result.Add(item == null ? null : new AccountRole()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName,
                    AssignedOn = item.AssignedOn
                });
                i++;
            }
            return result;
            
        }
        
        private static BlobImage funcMain26(BlobImageMerge p56, BlobImage p57)
        {
            if (p56 == null)
            {
                return null;
            }
            BlobImage result = p57 ?? new BlobImage();
            
            if (p56.ImageId != null)
            {
                result.ImageId = (Guid)p56.ImageId;
            }
            
            if (p56.ImageUrl != null)
            {
                result.ImageUrl = p56.ImageUrl;
            }
            return result;
            
        }
        
        private static List<AccountBadge> funcMain27(List<AccountBadgeMerge> p58, List<AccountBadge> p59)
        {
            if (p58 == null)
            {
                return null;
            }
            List<AccountBadge> result = new List<AccountBadge>(p58.Count);
            
            int i = 0;
            int len = p58.Count;
            
            while (i < len)
            {
                AccountBadgeMerge item = p58[i];
                result.Add(funcMain28(item));
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRole> funcMain29(List<AccountRoleMerge> p61, List<AccountRole> p62)
        {
            if (p61 == null)
            {
                return null;
            }
            List<AccountRole> result = new List<AccountRole>(p61.Count);
            
            int i = 0;
            int len = p61.Count;
            
            while (i < len)
            {
                AccountRoleMerge item = p61[i];
                result.Add(funcMain30(item));
                i++;
            }
            return result;
            
        }
        
        private static BlobImage funcMain32(BlobImageMerge p66)
        {
            if (p66 == null)
            {
                return null;
            }
            BlobImage result = new BlobImage();
            
            if (p66.ImageId != null)
            {
                result.ImageId = (Guid)p66.ImageId;
            }
            
            if (p66.ImageUrl != null)
            {
                result.ImageUrl = p66.ImageUrl;
            }
            return result;
            
        }
        
        private static AccountBadge funcMain28(AccountBadgeMerge p60)
        {
            if (p60 == null)
            {
                return null;
            }
            AccountBadge result = new AccountBadge();
            
            if (p60.BadgeId != null)
            {
                result.BadgeId = (Guid)p60.BadgeId;
            }
            
            if (p60.BadgeName != null)
            {
                result.BadgeName = p60.BadgeName;
            }
            
            if (p60.BadgeIcon != null)
            {
                result.BadgeIcon = p60.BadgeIcon;
            }
            
            if (p60.BadgeColor != null)
            {
                result.BadgeColor = p60.BadgeColor;
            }
            
            if (p60.EarnedOn != null)
            {
                result.EarnedOn = (DateTimeOffset)p60.EarnedOn;
            }
            return result;
            
        }
        
        private static AccountRole funcMain30(AccountRoleMerge p63)
        {
            if (p63 == null)
            {
                return null;
            }
            AccountRole result = new AccountRole();
            
            if (p63.RoleId != null)
            {
                result.RoleId = (Guid)p63.RoleId;
            }
            
            if (p63.RoleName != null)
            {
                result.RoleName = p63.RoleName;
            }
            
            if (p63.AssignedOn != null)
            {
                result.AssignedOn = (DateTimeOffset)p63.AssignedOn;
            }
            return result;
            
        }
    }
}