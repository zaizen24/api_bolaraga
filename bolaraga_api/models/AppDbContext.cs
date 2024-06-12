using Microsoft.EntityFrameworkCore;

namespace bolaraga_api.models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Jenis> Jenis { get; set; }

        public DbSet<Lapangan> Lapangan { get; set; }
        public DbSet<Booking> Booking {  get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.Id_User);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Jenis>().HasKey(u => u.id_jenis);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Lapangan>().HasKey(u => u.id_lap);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>().HasKey(u => u.id_booking);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().HasKey(u => u.id);

        }
    }
}
