using ELC.Lite.Domain.Leads;
using Microsoft.EntityFrameworkCore;

namespace ELC.Lite.CoreApp.Infrastucture
{
    public class CoreDbContext : DbContext
    {
        #region LeadAggregate

        public DbSet<Lead> Leads { get; set; }

        #endregion

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurationForSqliteTesting(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyConfigurationForSqliteTesting(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>().HasKey(x => x.Id);
            modelBuilder.Entity<Lead>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Lead>().Property(x => x.Budget).HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Lead>().OwnsOne(x => x.Customer, a =>
            {
                a.Property(x => x.Forenames).HasColumnName("Forenames");
                a.Property(x => x.Surname).HasColumnName("Surname");
                a.Property(x => x.TelNo).HasColumnName("TelNo");
                a.Property(x => x.Postcode).HasColumnName("Postcode");
                a.Property(x => x.Address).HasColumnName("Address");
                a.Property(x => x.Email).HasColumnName("Email");
            });

            modelBuilder.Entity<Lead>().OwnsOne(x => x.CurrentVehicle, a =>
            {
                a.Property(x => x.Make).HasColumnName("CurrentVehicleMake");
                a.Property(x => x.Model).HasColumnName("CurrentVehicleModel");
                a.Property(x => x.Year).HasColumnName("CurrentVehicleYear");
            });

            modelBuilder.Entity<Lead>().OwnsOne(x => x.InterestedInVehicle, a =>
            {
                a.Property(x => x.Make).HasColumnName("InterestedInVehicleMake");
                a.Property(x => x.Model).HasColumnName("InterestedInVehicleModel");
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
