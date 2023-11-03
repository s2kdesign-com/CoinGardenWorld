namespace CoinGardenWorldMobileApp.Models.Interfaces
{
    public interface ISoftDelete
    {
        public Guid? DeletedFrom { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
