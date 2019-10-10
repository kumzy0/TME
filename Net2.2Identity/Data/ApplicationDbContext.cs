using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Net2._2Identity.Models;
using TME.Models;

namespace Net2._2Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}
