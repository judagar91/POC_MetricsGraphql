using GraphQLAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;

namespace GraphQLAPI.Services
{
    public class SendsContext : DbContext
    {
        public SendsContext(DbContextOptions<SendsContext> options) : base(options) { }
        
        public DbSet<SendsDTO> Sends{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=JUANGARCIA-NEWS\\SQLEXPRESS;Database=wl_message_dev;Trusted_Connection=True;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SendsDTO>(entity =>
            {
                entity.ToTable("Sends");

                entity.HasNoKey();
            });
        }
    }
}
