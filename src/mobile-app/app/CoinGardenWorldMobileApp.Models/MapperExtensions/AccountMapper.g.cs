using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoinGardenWorldMobileApp.Models.Entities;
using CoinGardenWorldMobileApp.Models.ViewModels;

namespace CoinGardenWorldMobileApp.Models.MapperExtensions
{
    public static partial class AccountMapper
    {
        public static AccountDto AdaptToDto(this Account p1)
        {
            return p1 == null ? null : new AccountDto()
            {
                Email = p1.Email,
                Username = p1.Username,
                DisplayName = p1.DisplayName,
                ProfileIntroduction = p1.ProfileIntroduction,
                ProfilePicture = p1.ProfilePicture == null ? null : new BlobImageDto()
                {
                    ImageId = p1.ProfilePicture.ImageId,
                    ImageUrl = p1.ProfilePicture.ImageUrl
                },
                Badges = funcMain1(p1.Badges),
                Roles = funcMain2(p1.Roles),
                ExternalLogins = funcMain3(p1.ExternalLogins),
                Id = p1.Id,
                CreatedOn = p1.CreatedOn,
                UpdatedOn = p1.UpdatedOn,
                DeletedAt = p1.DeletedAt
            };
        }
        public static AccountDto AdaptTo(this Account p5, AccountDto p6)
        {
            if (p5 == null)
            {
                return null;
            }
            AccountDto result = p6 ?? new AccountDto();
            
            result.Email = p5.Email;
            result.Username = p5.Username;
            result.DisplayName = p5.DisplayName;
            result.ProfileIntroduction = p5.ProfileIntroduction;
            result.ProfilePicture = funcMain4(p5.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain5(p5.Badges, result.Badges);
            result.Roles = funcMain6(p5.Roles, result.Roles);
            result.ExternalLogins = funcMain7(p5.ExternalLogins, result.ExternalLogins);
            result.Id = p5.Id;
            result.CreatedOn = p5.CreatedOn;
            result.UpdatedOn = p5.UpdatedOn;
            result.DeletedAt = p5.DeletedAt;
            return result;
            
        }
        public static Expression<Func<Account, AccountDto>> ProjectToDto => p15 => new AccountDto()
        {
            Email = p15.Email,
            Username = p15.Username,
            DisplayName = p15.DisplayName,
            ProfileIntroduction = p15.ProfileIntroduction,
            ProfilePicture = p15.ProfilePicture == null ? null : new BlobImageDto()
            {
                ImageId = p15.ProfilePicture.ImageId,
                ImageUrl = p15.ProfilePicture.ImageUrl
            },
            Badges = p15.Badges.Select<AccountBadge, AccountBadgeDto>(p16 => new AccountBadgeDto()
            {
                BadgeId = p16.BadgeId,
                BadgeName = p16.BadgeName,
                BadgeIcon = p16.BadgeIcon,
                BadgeColor = p16.BadgeColor,
                EarnedOn = p16.EarnedOn
            }).ToList<AccountBadgeDto>(),
            Roles = p15.Roles.Select<AccountRole, AccountRoleDto>(p17 => new AccountRoleDto()
            {
                RoleId = p17.RoleId,
                RoleName = p17.RoleName,
                AssignedOn = p17.AssignedOn
            }).ToList<AccountRoleDto>(),
            ExternalLogins = p15.ExternalLogins.Select<AccountExternalLogins, AccountExternalLoginsDto>(p18 => new AccountExternalLoginsDto()
            {
                ObjectIdAzureAd = p18.ObjectIdAzureAd,
                AccountId = p18.AccountId,
                DisplayName = p18.DisplayName,
                IdentityProvider = p18.IdentityProvider,
                ProfilePictureUrl = p18.ProfilePictureUrl,
                Id = p18.Id,
                CreatedOn = p18.CreatedOn,
                UpdatedOn = p18.UpdatedOn,
                DeletedAt = p18.DeletedAt
            }).ToList<AccountExternalLoginsDto>(),
            Id = p15.Id,
            CreatedOn = p15.CreatedOn,
            UpdatedOn = p15.UpdatedOn,
            DeletedAt = p15.DeletedAt
        };
        public static AccountList AdaptToList(this Account p19)
        {
            return p19 == null ? null : new AccountList()
            {
                Email = p19.Email,
                Username = p19.Username,
                DisplayName = p19.DisplayName,
                ProfileIntroduction = p19.ProfileIntroduction,
                ProfilePicture = p19.ProfilePicture == null ? null : new BlobImageList()
                {
                    ImageId = p19.ProfilePicture.ImageId,
                    ImageUrl = p19.ProfilePicture.ImageUrl
                },
                Badges = funcMain8(p19.Badges),
                Roles = funcMain9(p19.Roles),
                Id = p19.Id,
                CreatedOn = p19.CreatedOn
            };
        }
        public static AccountList AdaptTo(this Account p22, AccountList p23)
        {
            if (p22 == null)
            {
                return null;
            }
            AccountList result = p23 ?? new AccountList();
            
            result.Email = p22.Email;
            result.Username = p22.Username;
            result.DisplayName = p22.DisplayName;
            result.ProfileIntroduction = p22.ProfileIntroduction;
            result.ProfilePicture = funcMain10(p22.ProfilePicture, result.ProfilePicture);
            result.Badges = funcMain11(p22.Badges, result.Badges);
            result.Roles = funcMain12(p22.Roles, result.Roles);
            result.Id = p22.Id;
            result.CreatedOn = p22.CreatedOn;
            return result;
            
        }
        public static Expression<Func<Account, AccountList>> ProjectToList => p30 => new AccountList()
        {
            Email = p30.Email,
            Username = p30.Username,
            DisplayName = p30.DisplayName,
            ProfileIntroduction = p30.ProfileIntroduction,
            ProfilePicture = p30.ProfilePicture == null ? null : new BlobImageList()
            {
                ImageId = p30.ProfilePicture.ImageId,
                ImageUrl = p30.ProfilePicture.ImageUrl
            },
            Badges = p30.Badges.Select<AccountBadge, AccountBadgeList>(p31 => new AccountBadgeList()
            {
                BadgeId = p31.BadgeId,
                BadgeName = p31.BadgeName,
                BadgeIcon = p31.BadgeIcon,
                BadgeColor = p31.BadgeColor,
                EarnedOn = p31.EarnedOn
            }).ToList<AccountBadgeList>(),
            Roles = p30.Roles.Select<AccountRole, AccountRoleList>(p32 => new AccountRoleList()
            {
                RoleId = p32.RoleId,
                RoleName = p32.RoleName,
                AssignedOn = p32.AssignedOn
            }).ToList<AccountRoleList>(),
            Id = p30.Id,
            CreatedOn = p30.CreatedOn
        };
        public static Account AdaptToAccount(this AccountAdd p33)
        {
            return p33 == null ? null : new Account()
            {
                Email = p33.Email,
                Username = p33.Username,
                DisplayName = p33.DisplayName,
                ProfileIntroduction = p33.ProfileIntroduction,
                ProfilePicture = p33.ProfilePicture == null ? null : new BlobImage()
                {
                    ImageId = p33.ProfilePicture.ImageId,
                    ImageUrl = p33.ProfilePicture.ImageUrl
                },
                Badges = funcMain13(p33.Badges),
                Roles = funcMain14(p33.Roles)
            };
        }
        public static Account AdaptTo(this AccountMerge p36, Account p37)
        {
            if (p36 == null)
            {
                return null;
            }
            Account result = p37 ?? new Account();
            
            if (p36.Email != null)
            {
                result.Email = p36.Email;
            }
            
            if (p36.Username != null)
            {
                result.Username = p36.Username;
            }
            
            if (p36.DisplayName != null)
            {
                result.DisplayName = p36.DisplayName;
            }
            
            if (p36.ProfileIntroduction != null)
            {
                result.ProfileIntroduction = p36.ProfileIntroduction;
            }
            
            if (p36.ProfilePicture != null)
            {
                result.ProfilePicture = funcMain15(p36.ProfilePicture, result.ProfilePicture);
            }
            
            if (p36.Badges != null)
            {
                result.Badges = funcMain16(p36.Badges, result.Badges);
            }
            
            if (p36.Roles != null)
            {
                result.Roles = funcMain18(p36.Roles, result.Roles);
            }
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain1(List<AccountBadge> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<AccountBadgeDto> result = new List<AccountBadgeDto>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                AccountBadge item = p2[i];
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
        
        private static List<AccountRoleDto> funcMain2(List<AccountRole> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p3.Count);
            
            int i = 0;
            int len = p3.Count;
            
            while (i < len)
            {
                AccountRole item = p3[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain3(List<AccountExternalLogins> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p4.Count);
            
            int i = 0;
            int len = p4.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p4[i];
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
        
        private static BlobImageDto funcMain4(BlobImage p7, BlobImageDto p8)
        {
            if (p7 == null)
            {
                return null;
            }
            BlobImageDto result = p8 ?? new BlobImageDto();
            
            result.ImageId = p7.ImageId;
            result.ImageUrl = p7.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeDto> funcMain5(List<AccountBadge> p9, List<AccountBadgeDto> p10)
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
        
        private static List<AccountRoleDto> funcMain6(List<AccountRole> p11, List<AccountRoleDto> p12)
        {
            if (p11 == null)
            {
                return null;
            }
            List<AccountRoleDto> result = new List<AccountRoleDto>(p11.Count);
            
            int i = 0;
            int len = p11.Count;
            
            while (i < len)
            {
                AccountRole item = p11[i];
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
        
        private static List<AccountExternalLoginsDto> funcMain7(List<AccountExternalLogins> p13, List<AccountExternalLoginsDto> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            List<AccountExternalLoginsDto> result = new List<AccountExternalLoginsDto>(p13.Count);
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                AccountExternalLogins item = p13[i];
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
        
        private static List<AccountBadgeList> funcMain8(List<AccountBadge> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p20.Count);
            
            int i = 0;
            int len = p20.Count;
            
            while (i < len)
            {
                AccountBadge item = p20[i];
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
        
        private static List<AccountRoleList> funcMain9(List<AccountRole> p21)
        {
            if (p21 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p21.Count);
            
            int i = 0;
            int len = p21.Count;
            
            while (i < len)
            {
                AccountRole item = p21[i];
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
        
        private static BlobImageList funcMain10(BlobImage p24, BlobImageList p25)
        {
            if (p24 == null)
            {
                return null;
            }
            BlobImageList result = p25 ?? new BlobImageList();
            
            result.ImageId = p24.ImageId;
            result.ImageUrl = p24.ImageUrl;
            return result;
            
        }
        
        private static List<AccountBadgeList> funcMain11(List<AccountBadge> p26, List<AccountBadgeList> p27)
        {
            if (p26 == null)
            {
                return null;
            }
            List<AccountBadgeList> result = new List<AccountBadgeList>(p26.Count);
            
            int i = 0;
            int len = p26.Count;
            
            while (i < len)
            {
                AccountBadge item = p26[i];
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
        
        private static List<AccountRoleList> funcMain12(List<AccountRole> p28, List<AccountRoleList> p29)
        {
            if (p28 == null)
            {
                return null;
            }
            List<AccountRoleList> result = new List<AccountRoleList>(p28.Count);
            
            int i = 0;
            int len = p28.Count;
            
            while (i < len)
            {
                AccountRole item = p28[i];
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
        
        private static List<AccountBadge> funcMain13(List<AccountBadgeAdd> p34)
        {
            if (p34 == null)
            {
                return null;
            }
            List<AccountBadge> result = new List<AccountBadge>(p34.Count);
            
            int i = 0;
            int len = p34.Count;
            
            while (i < len)
            {
                AccountBadgeAdd item = p34[i];
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
        
        private static List<AccountRole> funcMain14(List<AccountRoleAdd> p35)
        {
            if (p35 == null)
            {
                return null;
            }
            List<AccountRole> result = new List<AccountRole>(p35.Count);
            
            int i = 0;
            int len = p35.Count;
            
            while (i < len)
            {
                AccountRoleAdd item = p35[i];
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
        
        private static BlobImage funcMain15(BlobImageMerge p38, BlobImage p39)
        {
            if (p38 == null)
            {
                return null;
            }
            BlobImage result = p39 ?? new BlobImage();
            
            if (p38.ImageId != null)
            {
                result.ImageId = (Guid)p38.ImageId;
            }
            
            if (p38.ImageUrl != null)
            {
                result.ImageUrl = p38.ImageUrl;
            }
            return result;
            
        }
        
        private static List<AccountBadge> funcMain16(List<AccountBadgeMerge> p40, List<AccountBadge> p41)
        {
            if (p40 == null)
            {
                return null;
            }
            List<AccountBadge> result = new List<AccountBadge>(p40.Count);
            
            int i = 0;
            int len = p40.Count;
            
            while (i < len)
            {
                AccountBadgeMerge item = p40[i];
                result.Add(funcMain17(item));
                i++;
            }
            return result;
            
        }
        
        private static List<AccountRole> funcMain18(List<AccountRoleMerge> p43, List<AccountRole> p44)
        {
            if (p43 == null)
            {
                return null;
            }
            List<AccountRole> result = new List<AccountRole>(p43.Count);
            
            int i = 0;
            int len = p43.Count;
            
            while (i < len)
            {
                AccountRoleMerge item = p43[i];
                result.Add(funcMain19(item));
                i++;
            }
            return result;
            
        }
        
        private static AccountBadge funcMain17(AccountBadgeMerge p42)
        {
            if (p42 == null)
            {
                return null;
            }
            AccountBadge result = new AccountBadge();
            
            if (p42.BadgeId != null)
            {
                result.BadgeId = (Guid)p42.BadgeId;
            }
            
            if (p42.BadgeName != null)
            {
                result.BadgeName = p42.BadgeName;
            }
            
            if (p42.BadgeIcon != null)
            {
                result.BadgeIcon = p42.BadgeIcon;
            }
            
            if (p42.BadgeColor != null)
            {
                result.BadgeColor = p42.BadgeColor;
            }
            
            if (p42.EarnedOn != null)
            {
                result.EarnedOn = (DateTimeOffset)p42.EarnedOn;
            }
            return result;
            
        }
        
        private static AccountRole funcMain19(AccountRoleMerge p45)
        {
            if (p45 == null)
            {
                return null;
            }
            AccountRole result = new AccountRole();
            
            if (p45.RoleId != null)
            {
                result.RoleId = (Guid)p45.RoleId;
            }
            
            if (p45.RoleName != null)
            {
                result.RoleName = p45.RoleName;
            }
            
            if (p45.AssignedOn != null)
            {
                result.AssignedOn = (DateTimeOffset)p45.AssignedOn;
            }
            return result;
            
        }
    }
}