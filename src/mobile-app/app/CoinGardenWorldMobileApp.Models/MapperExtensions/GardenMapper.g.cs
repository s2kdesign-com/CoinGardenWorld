using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;
using Mapster.Utils;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class GardenMapper
    {
        public static GardenDto AdaptToDto(this Garden p1)
        {
            return p1 == null ? null : new GardenDto()
            {
                Name = p1.Name,
                AccountId = p1.AccountId,
                Account = funcMain1(p1.Account),
                Visibility = Enum<Visibility>.ToString(p1.Visibility),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static GardenDto AdaptTo(this Garden p6, GardenDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            GardenDto result = p7 ?? new GardenDto();
            
            result.Name = p6.Name;
            result.AccountId = p6.AccountId;
            result.Account = funcMain5(p6.Account, result.Account);
            result.Visibility = Enum<Visibility>.ToString(p6.Visibility);
            result.Id = p6.Id;
            result.CreatedOn = p6.CreatedOn;
            result.UpdatedOn = p6.UpdatedOn;
            result.DeletedAt = p6.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Garden, GardenDto>> ProjectToDto => p18 => new GardenDto()
        {
            Name = p18.Name,
            AccountId = p18.AccountId,
            Account = p18.Account == null ? null : new AccountDto()
            {
                Email = p18.Account.Email,
                Username = p18.Account.Username,
                DisplayName = p18.Account.DisplayName,
                ProfileIntroduction = p18.Account.ProfileIntroduction,
                ProfilePicture = p18.Account.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p18.Account.ProfilePicture.ImageId,
                    ImageUrl = p18.Account.ProfilePicture.ImageUrl
                },
                Badges = p18.Account.Badges.Select<AccountBadge, AccountBadgeDto>(p19 => new AccountBadgeDto()
                {
                    BadgeId = p19.BadgeId,
                    BadgeName = p19.BadgeName,
                    BadgeIcon = p19.BadgeIcon,
                    BadgeColor = p19.BadgeColor,
                    EarnedOn = p19.EarnedOn
                }).ToList<AccountBadgeDto>(),
                Roles = p18.Account.Roles.Select<AccountRole, AccountRoleDto>(p20 => new AccountRoleDto()
                {
                    RoleId = p20.RoleId,
                    RoleName = p20.RoleName,
                    AssignedOn = p20.AssignedOn
                }).ToList<AccountRoleDto>(),
                ExternalLogins = p18.Account.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p21 => new AccountExternalLoginsDto()
                {
                    ObjectIdAzureAd = p21.ObjectIdAzureAd,
                    AccountId = p21.AccountId,
                    DisplayName = p21.DisplayName,
                    IdentityProvider = p21.IdentityProvider,
                    ProfilePictureUrl = p21.ProfilePictureUrl,
                    Id = p21.Id,
                    CreatedOn = p21.CreatedOn,
                    UpdatedOn = p21.UpdatedOn,
                    DeletedAt = p21.DeletedAt
                }).ToList<AccountExternalLoginsDto>(),
                Id = p18.Account.Id,
                CreatedOn = p18.Account.CreatedOn,
                UpdatedOn = p18.Account.UpdatedOn,
                DeletedAt = p18.Account.DeletedAt
            },
            Visibility = Enum<Visibility>.ToString(p18.Visibility),
            Id = p18.Id,
            CreatedOn = p18.CreatedOn,
            UpdatedOn = p18.UpdatedOn,
            DeletedAt = p18.DeletedAt
        };
        public static GardenList AdaptToList(this Garden p22)
        {
            return p22 == null ? null : new GardenList()
            {
                Name = p22.Name,
                AccountId = p22.AccountId,
                Account = funcMain10(p22.Account),
                Visibility = Enum<Visibility>.ToString(p22.Visibility),
                Id = p22.Id,
                CreatedOn = p22.CreatedOn
            };
        }
        public static GardenList AdaptTo(this Garden p26, GardenList p27)
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
            result.Id = p26.Id;
            result.CreatedOn = p26.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Garden, GardenList>> ProjectToList => p36 => new GardenList()
        {
            Name = p36.Name,
            AccountId = p36.AccountId,
            Account = p36.Account == null ? null : new AccountList()
            {
                Email = p36.Account.Email,
                Username = p36.Account.Username,
                DisplayName = p36.Account.DisplayName,
                ProfileIntroduction = p36.Account.ProfileIntroduction,
                ProfilePicture = p36.Account.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p36.Account.ProfilePicture.ImageId,
                    ImageUrl = p36.Account.ProfilePicture.ImageUrl
                },
                Badges = p36.Account.Badges.Select<AccountBadge, AccountBadgeList>(p37 => new AccountBadgeList()
                {
                    BadgeId = p37.BadgeId,
                    BadgeName = p37.BadgeName,
                    BadgeIcon = p37.BadgeIcon,
                    BadgeColor = p37.BadgeColor,
                    EarnedOn = p37.EarnedOn
                }).ToList<AccountBadgeList>(),
                Roles = p36.Account.Roles.Select<AccountRole, AccountRoleList>(p38 => new AccountRoleList()
                {
                    RoleId = p38.RoleId,
                    RoleName = p38.RoleName,
                    AssignedOn = p38.AssignedOn
                }).ToList<AccountRoleList>(),
                Id = p36.Account.Id,
                CreatedOn = p36.Account.CreatedOn
            },
            Visibility = Enum<Visibility>.ToString(p36.Visibility),
            Id = p36.Id,
            CreatedOn = p36.CreatedOn
        };
        public static Garden AdaptToGarden(this GardenAdd p39)
        {
            return p39 == null ? null : new Garden()
            {
                Name = p39.Name,
                AccountId = p39.AccountId,
                Visibility = p39.Visibility == null ? Visibility.Public : Enum<Visibility>.Parse(p39.Visibility)
            };
        }
        public static Garden AdaptTo(this GardenMerge p40, Garden p41)
        {
            if (p40 == null)
            {
                return null;
            }
            Garden result = p41 ?? new Garden();
            
            if (p40.Name != null)
            {
                result.Name = p40.Name;
            }
            
            if (p40.AccountId != null)
            {
                result.AccountId = (Guid)p40.AccountId;
            }
            
            if (p40.Visibility != null)
            {
                result.Visibility = Enum<Visibility>.Parse(p40.Visibility);
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
        
        private static AccountDto funcMain5(Account p8, AccountDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            AccountDto result = p9 ?? new AccountDto();
            
            result.Email = p8.Email;
            result.Username = p8.Username;
            result.DisplayName = p8.DisplayName;
            result.ProfileIntroduction = p8.ProfileIntroduction;
            result.ProfilePicture = funcMain6(p8.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain7(p8.Badges, result.Badges);
            result.Roles = funcMain8(p8.Roles, result.Roles);
            result.ExternalLogins = funcMain9(p8.ExternalLogins, result.ExternalLogins);
            result.Id = p8.Id;
            result.CreatedOn = p8.CreatedOn;
            result.UpdatedOn = p8.UpdatedOn;
            result.DeletedAt = p8.DeletedAt;
            return result;
            
        }
        
        private static AccountList funcMain10(Account p23)
        {
            return p23 == null ? null : new AccountList()
            {
                Email = p23.Email,
                Username = p23.Username,
                DisplayName = p23.DisplayName,
                ProfileIntroduction = p23.ProfileIntroduction,
                ProfilePicture = p23.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p23.ProfilePicture.ImageId,
                    ImageUrl = p23.ProfilePicture.ImageUrl
                },
                Badges = funcMain11(p23.Badges),
                Roles = funcMain12(p23.Roles),
                Id = p23.Id,
                CreatedOn = p23.CreatedOn
            };
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
            result.ProfilePicture = funcMain14(p28.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain15(p28.Badges, result.Badges);
            result.Roles = funcMain16(p28.Roles, result.Roles);
            result.Id = p28.Id;
            result.CreatedOn = p28.CreatedOn;
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
        
        private static BlobImageDto funcMain6(BlobImage p10, BlobImageDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            BlobImageDto result = p11 ?? new BlobImageDto();
            
            result.ImageId = p10.ImageId;
            result.ImageUrl = p10.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain7(List<AccountBadge> p12, List<AccountBadgeDto> p13)
        {
            if (p12 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p12.Count);
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                AccountBadge item = p12[i];
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
        
        private static List<AccountRoleDto> funcMain8(List<AccountRole> p14, List<AccountRoleDto> p15)
        {
            if (p14 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p14.Count);
            
            int i = 0;
            int len = p14.Count;
            
            while (i < len)
            {
                AccountRole item = p14[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain9(List<AccountExternalLogins> p16, List<AccountExternalLoginsDto> p17)
        {
            if (p16 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p16.Count);
            
            int i = 0;
            int len = p16.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p16[i];
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
        
        private static List<AccountBadgeList> funcMain11(List<AccountBadge> p24)
        {
            if (p24 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p24.Count);
            
            int i = 0;
            int len = p24.Count;
            
            while (i < len)
            {
                AccountBadge item = p24[i];
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
        
        private static List<AccountRoleList> funcMain12(List<AccountRole> p25)
        {
            if (p25 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p25.Count);
            
            int i = 0;
            int len = p25.Count;
            
            while (i < len)
            {
                AccountRole item = p25[i];
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
        
        private static BlobImageList funcMain14(BlobImage p30, BlobImageList p31)
        {
            if (p30 == null)
            {
                return null;
            }
            BlobImageList result = p31 ?? new BlobImageList();
            
            result.ImageId = p30.ImageId;
            result.ImageUrl = p30.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain15(List<AccountBadge> p32, List<AccountBadgeList> p33)
        {
            if (p32 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p32.Count);
            
            int i = 0;
            int len = p32.Count;
            
            while (i < len)
            {
                AccountBadge item = p32[i];
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
        
        private static List<AccountRoleList> funcMain16(List<AccountRole> p34, List<AccountRoleList> p35)
        {
            if (p34 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p34.Count);
            
            int i = 0;
            int len = p34.Count;
            
            while (i < len)
            {
                AccountRole item = p34[i];
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