using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Modules.AuthModule.Models;
using WebApplication1.Modules.UserModule.Models;

namespace WebApplication1.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public new DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("user");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasColumnName("user_id");
                entity.Property(u => u.UserName).HasColumnName("username");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.PasswordHash).HasColumnName("password");
                entity.Property(u => u.SecurityStamp).HasColumnName("salt");

                entity.Property(u => u.ProfilePicture).HasColumnName("profile_picture");
                entity.Property(u => u.CohortId).HasColumnName("cohort_id");
                entity.Property(u => u.Coins).HasColumnName("coins");
                entity.Property(u => u.Experience).HasColumnName("experience");
                entity.Property(u => u.AmountSolved).HasColumnName("amount_solved");

                entity.HasOne(u => u.UserRole)
                      .WithMany()
                      .HasForeignKey(u => u.UserRoleId)
                      .HasConstraintName("fk_user_user_role");
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");
                entity.HasKey(r => r.UserRoleId);
                entity.Property(r => r.UserRoleId).HasColumnName("user_role_id");
                entity.Property(r => r.Name).HasColumnName("name");
            });

            builder.Entity<Session>(entity =>
            {
                entity.ToTable("session");
                entity.HasKey(s => s.SessionId);
                entity.Property(s => s.SessionId).HasColumnName("session_id");
                entity.Property(s => s.RefreshToken).HasColumnName("refresh_token");
                entity.Property(s => s.RefreshTokenExpiresAt).HasColumnName("refresh_token_expires_at");
                entity.Property(s => s.Revoked).HasColumnName("revoked");
                entity.Property(s => s.UserId).HasColumnName("user_id");

                entity.HasOne<WebApplication1.Modules.UserModule.Models.ApplicationUser>(s => s.User)
                      .WithMany(u => u.Sessions)
                      .HasForeignKey(s => s.UserId)
                      .HasConstraintName("fk_session_user");
            });
        }
    }
}

