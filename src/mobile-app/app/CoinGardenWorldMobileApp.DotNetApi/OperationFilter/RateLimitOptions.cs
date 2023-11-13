using System.Threading.RateLimiting;

namespace CoinGardenWorldMobileApp.DotNetApi.OperationFilter
{
    public class RateLimitOptions
    {
        public const string RateLimit = "RateLimit";
        public int PermitLimit { get; set; } = 100;
        /// <summary>
        /// The AddFixedWindowLimiter method uses a fixed time window to limit requests. When the time window expires, a new time window starts and the request limit is reset.
        /// </summary>
        public int Window { get; set; } = 60;
        /// <summary>
        /// Specifies the minimum period between replenishments.
        /// Must be set to a value greater than <see cref="TimeSpan.Zero" /> by the time these options are passed to the constructor of <see cref="TokenBucketRateLimiter"/>.
        /// </summary>
        public int ReplenishmentPeriod { get; set; } = 10;

        /// <summary>
        /// Maximum cumulative token count of queued acquisition requests.
        /// Must be set to a value >= 0 by the time these options are passed to the constructor of <see cref="TokenBucketRateLimiter"/>.
        /// </summary>
        public int QueueLimit { get; set; } = 2;

        /// <summary>
        /// Is similar to the fixed window limiter but adds segments per window. The window slides one segment each segment interval. The segment interval is (window time)/(segments per window).
        /// </summary>
        public int SegmentsPerWindow { get; set; } = 8;

        /// <summary>
        /// For not authorized. Maximum number of tokens that can be in the bucket at any time.
        /// Must be set to a value > 0 by the time these options are passed to the constructor of <see cref="TokenBucketRateLimiter"/>.
        /// </summary>

        public int TokenLimit { get; set; } = 4;

        /// <summary>
        /// For Authorized. Maximum number of tokens that can be in the bucket at any time.
        /// Must be set to a value > 0 by the time these options are passed to the constructor of <see cref="TokenBucketRateLimiter"/>.
        /// </summary>
        public int TokenLimit2 { get; set; } = 20;

        /// <summary>
        /// Specifies the maximum number of tokens to restore each replenishment.
        /// Must be set to a value > 0 by the time these options are passed to the constructor of <see cref="TokenBucketRateLimiter"/>.
        /// </summary>
        public int TokensPerPeriod { get; set; } = 2;

        /// <summary>
        /// Specified whether the <see cref="TokenBucketRateLimiter"/> is automatically replenishing tokens or if someone else
        /// will be calling <see cref="TokenBucketRateLimiter.TryReplenish"/> to replenish tokens.
        /// </summary>
        /// <value>
        /// <see langword="true" /> by default.
        /// </value>
        public bool AutoReplenishment { get; set; } = false;
    }
}
