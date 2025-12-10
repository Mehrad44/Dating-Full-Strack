using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; } 

        public DbSet<Member> Members{get;set;}

        public DbSet<Photo> Photos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dateTimeConverter = new ValueConverter<DateTime , DateTime>
            ( v=> v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            foreach(var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach(var propery in entityType.GetProperties())
                {
                    if(propery.ClrType == typeof(DateTime))
                    {
                        propery.SetValueConverter(dateTimeConverter);
                    }
                }
            }
           
        }
    }
}
            
