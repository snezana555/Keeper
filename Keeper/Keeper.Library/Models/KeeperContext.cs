using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Keeper.Library.Models
{
    public partial class KeeperContext : DbContext
    {
        public KeeperContext()
            : base("name=bdKeeperConnectionString")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Setcion)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.TargetVisit)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.AdditionalFiles)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.StatusDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .HasMany(e => e.Visitors)
                .WithMany(e => e.Requests)
                .Map(m => m.ToTable("RequestVisitor").MapLeftKey("RequestId").MapRightKey("VisitorId"));

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Visitor>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
