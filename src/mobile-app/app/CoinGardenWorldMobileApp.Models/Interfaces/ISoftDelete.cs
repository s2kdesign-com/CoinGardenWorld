namespace CoinGardenWorldMobileApp.Models.Interfaces
{
    public interface ISoftDelete
    {

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
