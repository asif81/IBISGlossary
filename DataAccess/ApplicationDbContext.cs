using Microsoft.EntityFrameworkCore;
using System;
using IBISGlossary.Model;

namespace IBISGlossary.DataAccess
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Glossary> glossaries { get; set; }
    }
}
