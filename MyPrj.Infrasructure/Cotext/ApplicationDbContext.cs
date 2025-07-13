using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using MyPrj.Domain.Models;

namespace MyPrj.Infrasructure.Cotext;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<product> Products { get; set; }
}