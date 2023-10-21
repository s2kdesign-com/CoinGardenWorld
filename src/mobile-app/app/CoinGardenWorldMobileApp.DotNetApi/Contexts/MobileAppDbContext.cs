using System;
using System.Collections.Generic;
using CoinGardenWorldMobileApp.DotNetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinGardenWorldMobileApp.DotNetApi.Contexts;

public partial class MobileAppDbContext : DbContext
{

    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<GardenEntity> Gardens { get; set; }
    public DbSet<FlowerEntity> Flowers { get; set; }

    public MobileAppDbContext(DbContextOptions<MobileAppDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
