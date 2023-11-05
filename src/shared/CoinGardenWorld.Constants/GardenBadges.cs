using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorld.Constants
{
    public static class GardenBadges
    {
        public static BadgesBasedOnTimeRegistered BadgesBasedOnTimeRegistered = new BadgesBasedOnTimeRegistered();

        public static BadgesBasedOnUploadsCount BadgesBasedOnUploadsCount = new BadgesBasedOnUploadsCount();
    }

    public class BadgesBasedOnUploadsCount
    {
        public readonly string BadgeTypeName = "Badges Given When User Uploads Flowers";

        public readonly BadgeTypes BadgeType = BadgeTypes.BasedOnUploadsCount;

        public readonly Dictionary<string, string> BadgeNames = new Dictionary<string, string> {
        { "Private Petal (1 flower)", "This initial badge is for those who have shared their first flower, taking the first step in contributing to the community's beauty and diversity." },

        { "Corporal Clusters (5 flowers)", "Awarded after uploading five flowers, this badge recognizes the user's growing contributions and their budding presence in the community." },

        { "Sergeant Sprout (10 flowers)", "For users who have uploaded ten flowers, this badge symbolizes their commitment to nurturing the community's growth and the sprouting of new ideas and connections." },

        { "Lieutenant Lavender (20 flowers)", "This badge is given to those who have contributed 20 flowers, representing their calming influence and the trust they've cultivated within the community." },

        { "Captain Carnation (50 flowers)", "Recognizing a significant milestone of 50 flowers, this badge honors the user's bold and impactful contributions that stand out in the community." },

        { "Major Magnolia (100 flowers)", "For users who reach the 100-flower mark, this badge celebrates their significant and dignified contributions that add a touch of southern elegance to the community." },

        { "Colonel Cactus (200 flowers)", "This badge is awarded to those who have uploaded 200 flowers, symbolizing their resilience and the enduring nature of their contributions, even in challenging environments." },

        { "Brigadier Bamboo (400 flowers)", "With 400 flowers contributed, this badge acknowledges the user's flexibility and strength, reflecting the bamboo's qualities of rapid growth and versatility." },

        { "General Gardenia (1000 flowers)", "This prestigious badge is for users who have uploaded 1000 flowers, recognizing their abundant contributions that have enriched the community with fragrance and beauty." },

        { "Field Marshal Flora (2000+ flowers)", "The highest honor, this badge is bestowed upon users who have uploaded over 2000 flowers, symbolizing their unparalleled commitment to cultivating a diverse and thriving community ecosystem." },
        };
    }

    public class BadgesBasedOnTimeRegistered
    {
        public readonly BadgeTypes BadgeType = BadgeTypes.BasedOnTimeRegistered;

        public readonly Dictionary<string, string> BadgeNames = new Dictionary<string, string> {
            { "Recruit Rosebud (Upon Registration)", "This badge is given to all new members as a welcome gesture, symbolizing the potential and growth that awaits them in the community." },

            { "Month Willow Private (One month of Membership)", "After a month, members receive this badge, symbolizing the steady and robust growth akin to a maple tree, laying the foundation for future contributions." },

            { "Quarterly Maple Corporal (Three months of Membership)", "This badge is given after three months to recognize members who have started to stand tall in the community, much like a spruce tree, showing resilience and consistency." },

            { "Seasonal Spruce Sergeant (Six months of Membership)", "At the six-month mark, members are recognized with this badge, symbolizing their adaptability and bright presence in the community, reminiscent of the birch tree's ability to thrive in various conditions." },

            { "Annual Birch Lieutenant (1 Year of Membership)", "Celebrating one year of membership, this badge is awarded to those who have shown leadership and have become a stable force within the community, much like the ash tree." },

            { "Biannual Ash Captain (2 Years of Membership)", "After two years, members receive this badge, representing their evergreen contributions that keep the community vibrant throughout the seasons." },

            { "Triennial Pine Major (3 Years of Membership)", "At three years, this badge represents the member's towering achievements and their evergreen contributions, which remain constant throughout the seasons." },

            { "Perennial Teak Colonel (4 Years of Membership)", "This badge, given at four years, signifies the member's high quality and valuable contributions, akin to the highly prized teak wood." },

            { "Oak Brigadier (5 Years of Membership)", "After five years, members are honored with this badge, representing their robust and steadfast support of the community, much like the mighty oak tree." },

            { "Cedar General (6 Years of Membership)", "At six years, this prestigious badge is awarded to members who have shown leadership and a strong foundation of support, embodying the cedar's stature and longevity." },
        };
    }
}
