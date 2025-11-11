namespace Api;

using Api.Models;
using Api.Models.Forms.Enrolment;
using Microsoft.EntityFrameworkCore;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<EnrolmentForm> EnrolmentForms { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(u => u.Id);

            user.HasIndex(u => u.Email).IsUnique();

            user.HasOne(u => u.EnrolmentForm)
              .WithOne(ef => ef.User)
              .HasForeignKey<EnrolmentForm>(ef => ef.UserId)
              .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
