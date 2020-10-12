using dotnetcore31_071020.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore31_071020.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {
            
        }
        public DbSet<Character> Character {get; set;}
        public DbSet<User> Users {get; set;}
        
    }
}