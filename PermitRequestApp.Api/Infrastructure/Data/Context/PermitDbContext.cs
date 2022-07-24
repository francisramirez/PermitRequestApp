using Microsoft.EntityFrameworkCore;
using PermitRequestApp.Api.Infrastructure.Data.Entities;

namespace PermitRequestApp.Api.Infrastructure.Data.Context
{
    public partial class PermitDbContext : DbContext
    {
        public PermitDbContext()
        {

        }
      
        public PermitDbContext(DbContextOptions<PermitDbContext> options)
           : base(options)
        {
            
        }
        public DbSet<PermitType> PermitType { get; set; }
        public DbSet<Permit> Permits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PermitType>(entity =>
            {

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permit>(entity =>
            {

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Last_Name");


                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.PermitDate)
                    .HasColumnType("date");
                
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
