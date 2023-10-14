using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.DotNetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{
    public DbSet<FlowerDTO> Flowers { get; set; }

    public MobileAppDbContext()
    {
    }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
