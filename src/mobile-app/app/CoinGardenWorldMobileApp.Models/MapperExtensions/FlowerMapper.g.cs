using System;
using System.Collections.Generic;
using System.Linq;
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
                Images = funcMain1(p1.Images),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                AccountId = p1.AccountId,
                Account = funcMain2(p1.Account),
                GardenId = p1.GardenId,
                Garden = funcMain6(p1.Garden),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static FlowerDto AdaptTo(this Flower p12, FlowerDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            FlowerDto result = p13 ?? new FlowerDto();
            
            result.Name = p12.Name;
            result.Images = funcMain11(p12.Images, result.Images);
            result.Visibility = Enum<Visibility>.ToString(p12.Visibility);
            result.AccountId = p12.AccountId;
            result.Account = funcMain12(p12.Account, result.Account);
            result.GardenId = p12.GardenId;
            result.Garden = funcMain17(p12.Garden, result.Garden);
            result.Id = p12.Id;
            result.CreatedOn = p12.CreatedOn;
            result.UpdatedOn = p12.UpdatedOn;
            result.DeletedAt = p12.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerDto>> ProjectToDto => p38 => new FlowerDto()
        {
            Name = p38.Name,
            Images = p38.Images.Select<BlobImage, BlobImageDto>(p39 => new BlobImageDto()
            {
                ImageId = p39.ImageId,
                ImageUrl = p39.ImageUrl
            }).ToList<BlobImageDto>(),
            Visibility = Enum<Visibility>.ToString(p38.Visibility),
            AccountId = p38.AccountId,
            Account = p38.Account == null ? null : new AccountDto()
            {
                Email = p38.Account.Email,
                Username = p38.Account.Username,
                DisplayName = p38.Account.DisplayName,
                ProfileIntroduction = p38.Account.ProfileIntroduction,
                ProfilePicture = p38.Account.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p38.Account.ProfilePicture.ImageId,
                    ImageUrl = p38.Account.ProfilePicture.ImageUrl
                },
                Badges = p38.Account.Badges.Select<AccountBadge, AccountBadgeDto>(p40 => new AccountBadgeDto()
                {
                    BadgeId = p40.BadgeId,
                    BadgeName = p40.BadgeName,
                    BadgeIcon = p40.BadgeIcon,
                    BadgeColor = p40.BadgeColor,
                    EarnedOn = p40.EarnedOn
                }).ToList<AccountBadgeDto>(),
                Roles = p38.Account.Roles.Select<AccountRole, AccountRoleDto>(p41 => new AccountRoleDto()
                {
                    RoleId = p41.RoleId,
                    RoleName = p41.RoleName,
                    AssignedOn = p41.AssignedOn
                }).ToList<AccountRoleDto>(),
                ExternalLogins = p38.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p42 => new AccountExternalLoginsDto()
                {
                    ObjectIdAzureAd = p42.ObjectIdAzureAd,
                    AccountId = p42.AccountId,
                    DisplayName = p42.DisplayName,
                    IdentityProvider = p42.IdentityProvider,
                    ProfilePictureUrl = p42.ProfilePictureUrl,
                    Id = p42.Id,
                    CreatedOn = p42.CreatedOn,
                    UpdatedOn = p42.UpdatedOn,
                    DeletedAt = p42.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p38.Account.Id,
                CreatedOn = p38.Account.CreatedOn,
                UpdatedOn = p38.Account.UpdatedOn,
                DeletedAt = p38.Account.DeletedAt
            },
            GardenId = p38.GardenId,
            Garden = p38.Garden == null ? null : new GardenDto()
            {
                Name = p38.Garden.Name,
                AccountId = p38.Garden.AccountId,
                Account = p38.Garden.Account == null ? null : new AccountDto()
                {
                    Email = p38.Garden.Account.Email,
                    Username = p38.Garden.Account.Username,
                    DisplayName = p38.Garden.Account.DisplayName,
                    ProfileIntroduction = p38.Garden.Account.ProfileIntroduction,
                    ProfilePicture = p38.Garden.Account.ProfilePicture == null ? null : new BlobImageDto()
                    {
                        ImageId = p38.Garden.Account.ProfilePicture.ImageId,
                        ImageUrl = p38.Garden.Account.ProfilePicture.ImageUrl
                    },
                    Badges = p38.Garden.Account.Badges.Select<AccountBadge, AccountBadgeDto>(p43 => new AccountBadgeDto()
                    {
                        BadgeId = p43.BadgeId,
                        BadgeName = p43.BadgeName,
                        BadgeIcon = p43.BadgeIcon,
                        BadgeColor = p43.BadgeColor,
                        EarnedOn = p43.EarnedOn
                    }).ToList<AccountBadgeDto>(),
                    Roles = p38.Garden.Account.Roles.Select<AccountRole, AccountRoleDto>(p44 => new AccountRoleDto()
                    {
                        RoleId = p44.RoleId,
                        RoleName = p44.RoleName,
                        AssignedOn = p44.AssignedOn
                    }).ToList<AccountRoleDto>(),
                    ExternalLogins = p38.Garden.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p45 => new AccountExternalLoginsDto()
                    {
                        ObjectIdAzureAd = p45.ObjectIdAzureAd,
                        AccountId = p45.AccountId,
                        DisplayName = p45.DisplayName,
                        IdentityProvider = p45.IdentityProvider,
                        ProfilePictureUrl = p45.ProfilePictureUrl,
                        Id = p45.Id,
                        CreatedOn = p45.CreatedOn,
                        UpdatedOn = p45.UpdatedOn,
                        DeletedAt = p45.DeletedAt
                    }).ToList<AccountExternalLoginsDto>(),
                    Id = p38.Garden.Account.Id,
                    CreatedOn = p38.Garden.Account.CreatedOn,
                    UpdatedOn = p38.Garden.Account.UpdatedOn,
                    DeletedAt = p38.Garden.Account.DeletedAt
                },
                Visibility = Enum<Visibility>.ToString(p38.Garden.Visibility),
                Id = p38.Garden.Id,
                CreatedOn = p38.Garden.CreatedOn,
                UpdatedOn = p38.Garden.UpdatedOn,
                DeletedAt = p38.Garden.DeletedAt
            },
            Id = p38.Id,
            CreatedOn = p38.CreatedOn,
            UpdatedOn = p38.UpdatedOn,
            DeletedAt = p38.DeletedAt
        };
        public static FlowerList AdaptToList(this Flower p46)
        {
            return p46 == null ? null : new FlowerList()
            {
                Name = p46.Name,
                Images = funcMain23(p46.Images),
                Visibility = Enum<Visibility>.ToString(p46.Visibility),
                AccountId = p46.AccountId,
                Account = funcMain24(p46.Account),
                GardenId = p46.GardenId,
                Garden = funcMain27(p46.Garden),
                Id = p46.Id,
                CreatedOn = p46.CreatedOn
            };
        }
        public static FlowerList AdaptTo(this Flower p55, FlowerList p56)
        {
            if (p55 == null)
            {
                return null;
            }
            FlowerList result = p56 ?? new FlowerList();
            
            result.Name = p55.Name;
            result.Images = funcMain31(p55.Images, result.Images);
            result.Visibility = Enum<Visibility>.ToString(p55.Visibility);
            result.AccountId = p55.AccountId;
            result.Account = funcMain32(p55.Account, result.Account);
            result.GardenId = p55.GardenId;
            result.Garden = funcMain36(p55.Garden, result.Garden);
            result.Id = p55.Id;
            result.CreatedOn = p55.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Flower, FlowerList>> ProjectToList => p77 => new FlowerList()
        {
            Name = p77.Name,
            Images = p77.Images.Select<BlobImage, BlobImageList>(p78 => new BlobImageList()
            {
                ImageId = p78.ImageId,
                ImageUrl = p78.ImageUrl
            }).ToList<BlobImageList>(),
            Visibility = Enum<Visibility>.ToString(p77.Visibility),
            AccountId = p77.AccountId,
            Account = p77.Account == null ? null : new AccountList()
            {
                Email = p77.Account.Email,
                Username = p77.Account.Username,
                DisplayName = p77.Account.DisplayName,
                ProfileIntroduction = p77.Account.ProfileIntroduction,
                ProfilePicture = p77.Account.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p77.Account.ProfilePicture.ImageId,
                    ImageUrl = p77.Account.ProfilePicture.ImageUrl
                },
                Badges = p77.Account.Badges.Select<AccountBadge, AccountBadgeList>(p79 => new AccountBadgeList()
                {
                    BadgeId = p79.BadgeId,
                    BadgeName = p79.BadgeName,
                    BadgeIcon = p79.BadgeIcon,
                    BadgeColor = p79.BadgeColor,
                    EarnedOn = p79.EarnedOn
                }).ToList<AccountBadgeList>(),
                Roles = p77.Account.Roles.Select<AccountRole, AccountRoleList>(p80 => new AccountRoleList()
                {
                    RoleId = p80.RoleId,
                    RoleName = p80.RoleName,
                    AssignedOn = p80.AssignedOn
                }).ToList<AccountRoleList>(),
                Id = p77.Account.Id,
                CreatedOn = p77.Account.CreatedOn
            },
            GardenId = p77.GardenId,
            Garden = p77.Garden == null ? null : new GardenList()
            {
                Name = p77.Garden.Name,
                AccountId = p77.Garden.AccountId,
                Account = p77.Garden.Account == null ? null : new AccountList()
                {
                    Email = p77.Garden.Account.Email,
                    Username = p77.Garden.Account.Username,
                    DisplayName = p77.Garden.Account.DisplayName,
                    ProfileIntroduction = p77.Garden.Account.ProfileIntroduction,
                    ProfilePicture = p77.Garden.Account.ProfilePicture == null ? null : new BlobImageList()
                    {
                        ImageId = p77.Garden.Account.ProfilePicture.ImageId,
                        ImageUrl = p77.Garden.Account.ProfilePicture.ImageUrl
                    },
                    Badges = p77.Garden.Account.Badges.Select<AccountBadge, AccountBadgeList>(p81 => new AccountBadgeList()
                    {
                        BadgeId = p81.BadgeId,
                        BadgeName = p81.BadgeName,
                        BadgeIcon = p81.BadgeIcon,
                        BadgeColor = p81.BadgeColor,
                        EarnedOn = p81.EarnedOn
                    }).ToList<AccountBadgeList>(),
                    Roles = p77.Garden.Account.Roles.Select<AccountRole, AccountRoleList>(p82 => new AccountRoleList()
                    {
                        RoleId = p82.RoleId,
                        RoleName = p82.RoleName,
                        AssignedOn = p82.AssignedOn
                    }).ToList<AccountRoleList>(),
                    Id = p77.Garden.Account.Id,
                    CreatedOn = p77.Garden.Account.CreatedOn
                },
                Visibility = Enum<Visibility>.ToString(p77.Garden.Visibility),
                Id = p77.Garden.Id,
                CreatedOn = p77.Garden.CreatedOn
            },
            Id = p77.Id,
            CreatedOn = p77.CreatedOn
        };
        public static Flower AdaptToFlower(this FlowerAdd p83)
        {
            return p83 == null ? null : new Flower()
            {
                Name = p83.Name,
                Images = funcMain41(p83.Images),
                Visibility = p83.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p83.Visibility),
                AccountId = p83.AccountId
            };
        }
        public static Flower AdaptTo(this FlowerMerge p85, Flower p86)
        {
            if (p85 == null)
            {
                return null;
            }
            Flower result = p86 ?? new Flower();
            
            if (p85.Name != null)
            {
                result.Name = p85.Name;
            }
            
            if (p85.Images != null)
            {
                result.Images = funcMain42(p85.Images, result.Images);
            }
            
            if (p85.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p85.Visibility);
            }
            
            if (p85.AccountId != null)
            {
                result.AccountId = (Guid)p85.AccountId;
            }
            return result;
            
        }
        
        private static List<BlobImageDto> funcMain1(List<BlobImage> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<BlobImageDto> result = new List<BlobImageDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                BlobImage item = p2[i];
                result.Add(item == null ? null : new BlobImageDto()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
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
                ProfilePicture = p3.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p3.ProfilePicture.ImageId,
                    ImageUrl = p3.ProfilePicture.ImageUrl
                },
                Badges = funcMain3(p3.Badges),
                Roles = funcMain4(p3.Roles),
                ExternalLogins = funcMain5(p3.ExternalLogins),
                Id = p3.Id,
                CreatedOn = p3.CreatedOn,
                UpdatedOn = p3.UpdatedOn,
                DeletedAt = p3.DeletedAt
            };
        }
        
        private static GardenDto funcMain6(Garden p7)
        {
            return p7 == null ? null : new GardenDto()
            {
                Name = p7.Name,
                AccountId = p7.AccountId,
                Account = funcMain7(p7.Account),
                Visibility = Enum<Visibility>.ToString(p7.Visibility),
                Id = p7.Id,
                CreatedOn = p7.CreatedOn,
                UpdatedOn = p7.UpdatedOn,
                DeletedAt = p7.DeletedAt
            };
        }
        
        private static List<BlobImageDto> funcMain11(List<BlobImage> p14, List<BlobImageDto> p15)
        {
            if (p14 == null)
            {
                return null;
            }
            List<BlobImageDto> result = new List<BlobImageDto>(p14.Count);
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                BlobImage item = p14[i];
                result.Add(item == null ? null : new BlobImageDto()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountDto funcMain12(Account p16, AccountDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            AccountDto result = p17 ?? new AccountDto();
            
            result.Email = p16.Email;
            result.Username = p16.Username;
            result.DisplayName = p16.DisplayName;
            result.ProfileIntroduction = p16.ProfileIntroduction;
            result.ProfilePicture = funcMain13(p16.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain14(p16.Badges, result.Badges);
            result.Roles = funcMain15(p16.Roles, result.Roles);
            result.ExternalLogins = funcMain16(p16.ExternalLogins, result.ExternalLogins);
            result.Id = p16.Id;
            result.CreatedOn = p16.CreatedOn;
            result.UpdatedOn = p16.UpdatedOn;
            result.DeletedAt = p16.DeletedAt;
            return result;
            
        }
        
        private static GardenDto funcMain17(Garden p26, GardenDto p27)
        {
            if (p26 == null)
            {
                return null;
            }
            GardenDto result = p27 ?? new GardenDto();
            
            result.Name = p26.Name;
            result.AccountId = p26.AccountId;
            result.Account = funcMain18(p26.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p26.Visibility);
            result.Id = p26.Id;
            result.CreatedOn = p26.CreatedOn;
            result.UpdatedOn = p26.UpdatedOn;
            result.DeletedAt = p26.DeletedAt;
            return result;
            
        }
        
        private static List<BlobImageList> funcMain23(List<BlobImage> p47)
        {
            if (p47 == null)
            {
                return null;
            }
            List<BlobImageList> result = new List<BlobImageList>(p47.Count);
            
            int i = 0;
            int len = p47.Count;
            
            while (i < len)
            {
                BlobImage item = p47[i];
                result.Add(item == null ? null : new BlobImageList()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountList funcMain24(Account p48)
        {
            return p48 == null ? null : new AccountList()
            {
                Email = p48.Email,
                Username = p48.Username,
                DisplayName = p48.DisplayName,
                ProfileIntroduction = p48.ProfileIntroduction,
                ProfilePicture = p48.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p48.ProfilePicture.ImageId,
                    ImageUrl = p48.ProfilePicture.ImageUrl
                },
                Badges = funcMain25(p48.Badges),
                Roles = funcMain26(p48.Roles),
                Id = p48.Id,
                CreatedOn = p48.CreatedOn
            };
        }
        
        private static GardenList funcMain27(Garden p51)
        {
            return p51 == null ? null : new GardenList()
            {
                Name = p51.Name,
                AccountId = p51.AccountId,
                Account = funcMain28(p51.Account),
                Visibility = Enum<Visibility>.ToString(p51.Visibility),
                Id = p51.Id,
                CreatedOn = p51.CreatedOn
            };
        }
        
        private static List<BlobImageList> funcMain31(List<BlobImage> p57, List<BlobImageList> p58)
        {
            if (p57 == null)
            {
                return null;
            }
            List<BlobImageList> result = new List<BlobImageList>(p57.Count);
            
            int i = 0;
            int len = p57.Count;
            
            while (i < len)
            {
                BlobImage item = p57[i];
                result.Add(item == null ? null : new BlobImageList()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static AccountList funcMain32(Account p59, AccountList p60)
        {
            if (p59 == null)
            {
                return null;
            }
            AccountList result = p60 ?? new AccountList();
            
            result.Email = p59.Email;
            result.Username = p59.Username;
            result.DisplayName = p59.DisplayName;
            result.ProfileIntroduction = p59.ProfileIntroduction;
            result.ProfilePicture = funcMain33(p59.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain34(p59.Badges, result.Badges);
            result.Roles = funcMain35(p59.Roles, result.Roles);
            result.Id = p59.Id;
            result.CreatedOn = p59.CreatedOn;
            return result;
            
        }
        
        private static GardenList funcMain36(Garden p67, GardenList p68)
        {
            if (p67 == null)
            {
                return null;
            }
            GardenList result = p68 ?? new GardenList();
            
            result.Name = p67.Name;
            result.AccountId = p67.AccountId;
            result.Account = funcMain37(p67.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p67.Visibility);
            result.Id = p67.Id;
            result.CreatedOn = p67.CreatedOn;
            return result;
            
        }
        
        private static List<BlobImage> funcMain41(List<BlobImageAdd> p84)
        {
            if (p84 == null)
            {
                return null;
            }
            List<BlobImage> result = new List<BlobImage>(p84.Count);
            
            int i = 0;
            int len = p84.Count;
            
            while (i < len)
            {
                BlobImageAdd item = p84[i];
                result.Add(item == null ? null : new BlobImage()
                {
                    ImageId = item.ImageId,
                    ImageUrl = item.ImageUrl
                });
                i++;
            }
            return result;
            
        }
        
        private static List<BlobImage> funcMain42(List<BlobImageMerge> p87, List<BlobImage> p88)
        {
            if (p87 == null)
            {
                return null;
            }
            List<BlobImage> result = new List<BlobImage>(p87.Count);
            
            int i = 0;
            int len = p87.Count;
            
            while (i < len)
            {
                BlobImageMerge item = p87[i];
                result.Add(funcMain43(item));
                i++;
            }
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain3(List<AccountBadge> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p4.Count);
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                AccountBadge item = p4[i];
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
        
        private static List<AccountRoleDto> funcMain4(List<AccountRole> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                AccountRole item = p5[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain5(List<AccountExternalLogins> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p6.Count);
            
            int i = 0;
            int len = p6.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p6[i];
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
        
        private static AccountDto funcMain7(Account p8)
        {
            return p8 == null ? null : new AccountDto()
            {
                Email = p8.Email,
                Username = p8.Username,
                DisplayName = p8.DisplayName,
                ProfileIntroduction = p8.ProfileIntroduction,
                ProfilePicture = p8.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p8.ProfilePicture.ImageId,
                    ImageUrl = p8.ProfilePicture.ImageUrl
                },
                Badges = funcMain8(p8.Badges),
                Roles = funcMain9(p8.Roles),
                ExternalLogins = funcMain10(p8.ExternalLogins),
                Id = p8.Id,
                CreatedOn = p8.CreatedOn,
                UpdatedOn = p8.UpdatedOn,
                DeletedAt = p8.DeletedAt
            };
        }
        
        private static BlobImageDto funcMain13(BlobImage p18, BlobImageDto p19)
        {
            if (p18 == null)
            {
                return null;
            }
            BlobImageDto result = p19 ?? new BlobImageDto();
            
            result.ImageId = p18.ImageId;
            result.ImageUrl = p18.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain14(List<AccountBadge> p20, List<AccountBadgeDto> p21)
        {
            if (p20 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p20.Count);
            
            int i = 0;
            int len = p20.Count;
            
            while (i < len)
            {
                AccountBadge item = p20[i];
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
        
        private static List<AccountRoleDto> funcMain15(List<AccountRole> p22, List<AccountRoleDto> p23)
        {
            if (p22 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p22.Count);
            
            int i = 0;
            int len = p22.Count;
            
            while (i < len)
            {
                AccountRole item = p22[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain16(List<AccountExternalLogins> p24, List<AccountExternalLoginsDto> p25)
        {
            if (p24 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p24.Count);
            
            int i = 0;
            int len = p24.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p24[i];
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
        
        private static AccountDto funcMain18(Account p28, AccountDto p29)
        {
            if (p28 == null)
            {
                return null;
            }
            AccountDto result = p29 ?? new AccountDto();
            
            result.Email = p28.Email;
            result.Username = p28.Username;
            result.DisplayName = p28.DisplayName;
            result.ProfileIntroduction = p28.ProfileIntroduction;
            result.ProfilePicture = funcMain19(p28.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain20(p28.Badges, result.Badges);
            result.Roles = funcMain21(p28.Roles, result.Roles);
            result.ExternalLogins = funcMain22(p28.ExternalLogins, result.ExternalLogins);
            result.Id = p28.Id;
            result.CreatedOn = p28.CreatedOn;
            result.UpdatedOn = p28.UpdatedOn;
            result.DeletedAt = p28.DeletedAt;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain25(List<AccountBadge> p49)
        {
            if (p49 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p49.Count);
            
            int i = 0;
            int len = p49.Count;
            
            while (i < len)
            {
                AccountBadge item = p49[i];
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
        
        private static List<AccountRoleList> funcMain26(List<AccountRole> p50)
        {
            if (p50 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p50.Count);
            
            int i = 0;
            int len = p50.Count;
            
            while (i < len)
            {
                AccountRole item = p50[i];
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
        
        private static AccountList funcMain28(Account p52)
        {
            return p52 == null ? null : new AccountList()
            {
                Email = p52.Email,
                Username = p52.Username,
                DisplayName = p52.DisplayName,
                ProfileIntroduction = p52.ProfileIntroduction,
                ProfilePicture = p52.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p52.ProfilePicture.ImageId,
                    ImageUrl = p52.ProfilePicture.ImageUrl
                },
                Badges = funcMain29(p52.Badges),
                Roles = funcMain30(p52.Roles),
                Id = p52.Id,
                CreatedOn = p52.CreatedOn
            };
        }
        
        private static BlobImageList funcMain33(BlobImage p61, BlobImageList p62)
        {
            if (p61 == null)
            {
                return null;
            }
            BlobImageList result = p62 ?? new BlobImageList();
            
            result.ImageId = p61.ImageId;
            result.ImageUrl = p61.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain34(List<AccountBadge> p63, List<AccountBadgeList> p64)
        {
            if (p63 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p63.Count);
            
            int i = 0;
            int len = p63.Count;
            
            while (i < len)
            {
                AccountBadge item = p63[i];
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
        
        private static List<AccountRoleList> funcMain35(List<AccountRole> p65, List<AccountRoleList> p66)
        {
            if (p65 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p65.Count);
            
            int i = 0;
            int len = p65.Count;
            
            while (i < len)
            {
                AccountRole item = p65[i];
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
        
        private static AccountList funcMain37(Account p69, AccountList p70)
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
            result.ProfilePicture = funcMain38(p69.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain39(p69.Badges, result.Badges);
            result.Roles = funcMain40(p69.Roles, result.Roles);
            result.Id = p69.Id;
            result.CreatedOn = p69.CreatedOn;
            return result;
            
        }
        
        private static BlobImage funcMain43(BlobImageMerge p89)
        {
            if (p89 == null)
            {
                return null;
            }
            BlobImage result = new BlobImage();
            
            if (p89.ImageId != null)
            {
                result.ImageId = (Guid)p89.ImageId;
            }
            
            if (p89.ImageUrl != null)
            {
                result.ImageUrl = p89.ImageUrl;
            }
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain8(List<AccountBadge> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p9.Count);
            
            int i = 0;
            int len = p9.Count;
            
            while (i < len)
            {
                AccountBadge item = p9[i];
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
        
        private static List<AccountRoleDto> funcMain9(List<AccountRole> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p10.Count);
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                AccountRole item = p10[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain10(List<AccountExternalLogins> p11)
        {
            if (p11 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p11.Count);
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p11[i];
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
        
        private static BlobImageDto funcMain19(BlobImage p30, BlobImageDto p31)
        {
            if (p30 == null)
            {
                return null;
            }
            BlobImageDto result = p31 ?? new BlobImageDto();
            
            result.ImageId = p30.ImageId;
            result.ImageUrl = p30.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain20(List<AccountBadge> p32, List<AccountBadgeDto> p33)
        {
            if (p32 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p32.Count);
            
            int i = 0;
            int len = p32.Count;
            
            while (i < len)
            {
                AccountBadge item = p32[i];
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
        
        private static List<AccountRoleDto> funcMain21(List<AccountRole> p34, List<AccountRoleDto> p35)
        {
            if (p34 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p34.Count);
            
            int i = 0;
            int len = p34.Count;
            
            while (i < len)
            {
                AccountRole item = p34[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain22(List<AccountExternalLogins> p36, List<AccountExternalLoginsDto> p37)
        {
            if (p36 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p36.Count);
            
            int i = 0;
            int len = p36.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p36[i];
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
        
        private static List<AccountBadgeList> funcMain29(List<AccountBadge> p53)
        {
            if (p53 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p53.Count);
            
            int i = 0;
            int len = p53.Count;
            
            while (i < len)
            {
                AccountBadge item = p53[i];
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
        
        private static List<AccountRoleList> funcMain30(List<AccountRole> p54)
        {
            if (p54 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p54.Count);
            
            int i = 0;
            int len = p54.Count;
            
            while (i < len)
            {
                AccountRole item = p54[i];
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
        
        private static BlobImageList funcMain38(BlobImage p71, BlobImageList p72)
        {
            if (p71 == null)
            {
                return null;
            }
            BlobImageList result = p72 ?? new BlobImageList();
            
            result.ImageId = p71.ImageId;
            result.ImageUrl = p71.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain39(List<AccountBadge> p73, List<AccountBadgeList> p74)
        {
            if (p73 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p73.Count);
            
            int i = 0;
            int len = p73.Count;
            
            while (i < len)
            {
                AccountBadge item = p73[i];
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
        
        private static List<AccountRoleList> funcMain40(List<AccountRole> p75, List<AccountRoleList> p76)
        {
            if (p75 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p75.Count);
            
            int i = 0;
            int len = p75.Count;
            
            while (i < len)
            {
                AccountRole item = p75[i];
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
    }
}