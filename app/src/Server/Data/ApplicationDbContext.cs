using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerChurn.Server.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var tristateConverter = new ValueConverter<Tristate, string>(
                x => x.ToString(),
                x => (Tristate)Enum.Parse<Tristate>(x));

            var contractTypeConverter = new ValueConverter<ContractType, string>(
                x => x.ToString(),
                x => (ContractType)Enum.Parse<ContractType>(x));

            var paymentMethodConverter = new ValueConverter<PaymentMethodType, string>(
                x => x.ToString(),
                x => (PaymentMethodType)Enum.Parse<PaymentMethodType>(x));

            var connectionTypeConverter = new ValueConverter<ConnectionType, string>(
                x => x.ToString(),
                x => (ConnectionType)Enum.Parse<ConnectionType>(x));

            modelBuilder.Entity<Customer>().Property(x => x.Contract).HasConversion(contractTypeConverter);
            modelBuilder.Entity<Customer>().Property(x => x.PaymentMethod).HasConversion(paymentMethodConverter);
            modelBuilder.Entity<Customer>().Property(x => x.PhoneService).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.MultipleLines).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.InternetService).HasConversion(connectionTypeConverter);
            modelBuilder.Entity<Customer>().Property(x => x.OnlineSecurity).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.OnlineBackup).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.DeviceProtection).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.TechSupport).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.StreamingTV).HasConversion(tristateConverter);
            modelBuilder.Entity<Customer>().Property(x => x.StreamingMovies).HasConversion(tristateConverter);
        }
    }
}