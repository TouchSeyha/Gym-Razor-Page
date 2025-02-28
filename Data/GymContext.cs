using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gym.Models;
using Microsoft.AspNetCore.Identity;

public class GymContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public GymContext(DbContextOptions<GymContext> options)
        : base(options)
    {
    }

    public DbSet<Coach> Coaches { get; set; }
        public DbSet<GymHall> GymHalls { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers
    {
        get; set;
    }
}
