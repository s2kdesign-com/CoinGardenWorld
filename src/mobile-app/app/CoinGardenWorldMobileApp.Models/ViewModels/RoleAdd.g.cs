namespace CoinGardenWorldMobileApp.Models.ViewModels
{
    public partial record RoleAdd
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Visibility { get; set; }
    }
}