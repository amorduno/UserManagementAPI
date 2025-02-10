using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la tabla Users
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            // Configuración para la tabla LoginAttempts
            modelBuilder.Entity<LoginAttempt>().HasKey(la => la.Id);
            modelBuilder.Entity<LoginAttempt>().Property(la => la.Email).IsRequired();
            modelBuilder.Entity<LoginAttempt>().Property(la => la.AttemptedAt).IsRequired();
            modelBuilder.Entity<LoginAttempt>().Property(la => la.IsSuccessful).IsRequired();

            // Configuración para la tabla PasswordResetTokens
            modelBuilder.Entity<PasswordResetToken>().HasKey(prt => prt.Id);
            modelBuilder.Entity<PasswordResetToken>().Property(prt => prt.Token).IsRequired();
            modelBuilder.Entity<PasswordResetToken>().Property(prt => prt.ExpiresAt).IsRequired();
            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(prt => prt.User) // Define la relación uno a muchos
                .WithMany() // No hay una colección inversa en User
                .HasForeignKey(prt => prt.UserId); // Define la clave foránea

            // Configuración para la tabla AuditLogs
            modelBuilder.Entity<AuditLog>().HasKey(al => al.Id);
            modelBuilder.Entity<AuditLog>().Property(al => al.EventType).IsRequired();
            modelBuilder.Entity<AuditLog>().Property(al => al.CreatedAt).IsRequired();
        }
    }
}