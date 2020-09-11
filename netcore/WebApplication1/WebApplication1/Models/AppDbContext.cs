using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                 new Employee()
                 {
                     Id = 1,
                     Fullname = "Huy Nguyen",
                     Department = Dept.Manage,
                     Email = "huynguyenn@gmail.com",
                     AvatarPath = "/images/av1.png"
                 },
                 new Employee()
                 {
                     Id = 2,
                     Fullname = "Trung Nguyen",
                     Department = Dept.Receptionist,
                     Email = "huynguyen33n@gmail.com",
                     AvatarPath = "/images/av2.png"
                 }
                );
        }
    }
}
