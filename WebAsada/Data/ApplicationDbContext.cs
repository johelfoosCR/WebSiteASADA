using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Interfaces;
using WebAsada.Models;

namespace WebAsada.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly ILoggedUserReader currentUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedUserReader currentUser)
            : base(options)
        { 
            this.currentUser = currentUser;
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            builder.ManyToManyRelations();
            base.OnModelCreating(builder); 
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSaveChanges() {

            var dateTimeNow = DateTime.Now;
            foreach (var item in ChangeTracker.Entries()
                                              .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified)
                                                           && x.Entity is BaseEntity))
            {
                var entityToUpdate = item.Entity as BaseEntity;
                entityToUpdate.UpdateDateTime = dateTimeNow;
                entityToUpdate.UpdateUserId = currentUser.GetLoggedUser();

                if (item.State == EntityState.Added)
                {
                    entityToUpdate.RegisterDatime = dateTimeNow;
                    entityToUpdate.RegisterUserId = currentUser.GetLoggedUser();
                }
                else
                {
                    item.Property(nameof(entityToUpdate.RegisterUserId)).IsModified = false;
                    item.Property(nameof(entityToUpdate.RegisterDatime)).IsModified = false;
                }

            }
        }

        public DbSet<Charge> Charge { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<PersonType> CustomerType { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Measurement> Measurement { get; set; } 
        public DbSet<Receipt> Receipt { get; set; } 
        public DbSet<Estate> Estate { get; set; } 
        public DbSet<IdentificationType> IdentificationType { get; set; } 
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonsByEstate> PersonsByEstate { get; set; } 
        public DbSet<ContractType> ContractType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<WaterMeter> WaterMeter { get; set; }
        public DbSet<Contract> Contract { get; set; } 
    }
}
