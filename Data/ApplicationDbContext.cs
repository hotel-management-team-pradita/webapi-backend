using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure ReservationModel
            modelBuilder.Entity<ReservationModel>(entity =>
            {
                entity.HasKey(e => e.ReservationId);

                entity.HasOne(e => e.Payment)
                      .WithOne(p => p.Reservation)
                      .HasForeignKey<PaymentModel>(p => p.ReservationId)
                      .OnDelete(DeleteBehavior.Cascade);

                // other configurations for ReservationModel if necessary
            });

            // Configure PaymentModel
            modelBuilder.Entity<PaymentModel>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

            });

            // Configure RoomModel
            modelBuilder.Entity<RoomModel>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.HasOne(r => r.RoomType)
                      .WithMany(rt => rt.Rooms)
                      .HasForeignKey(r => r.RoomTypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure RoomTypeModel
            modelBuilder.Entity<RoomTypeModel>(entity =>
            {
                entity.HasKey(e => e.TypeId);
                entity.HasMany(r => r.Rooms);
            });

            // Configure UserModel
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });
        }
    }
}