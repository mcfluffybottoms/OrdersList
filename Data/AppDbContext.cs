using Microsoft.EntityFrameworkCore;
using OrdersList.Models;

namespace OrdersList.Data;

public class AppDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().HasKey(a => a.Id);

        modelBuilder.Entity<Order>().HasKey(o => o.Id);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.SenderAddress)
            .WithMany()
            .HasForeignKey(o => o.SenderAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.ReceiverAddress)
            .WithMany()
            .HasForeignKey(o => o.ReceiverAddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}