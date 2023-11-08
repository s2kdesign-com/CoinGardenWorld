namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record BadgeAdd
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string? Description { get; set; }
        public string BadgeType { get; set; }
    }
}