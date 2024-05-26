using hotel_management_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotel_management_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<RoomTypeModel> RoomTypes { get; set; }
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}