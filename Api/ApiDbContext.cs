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

        modelBuilder.Entity<EnrolmentForm>(enrolmentForm =>
        {
          enrolmentForm.HasKey(ef => ef.Id);
          enrolmentForm.OwnsOne(ef => ef.StudentDetails);
          enrolmentForm.OwnsOne(ef => ef.StudentSchoolingExperience);
          enrolmentForm.OwnsOne(ef => ef.FamilyDetails);
          enrolmentForm.OwnsOne(ef => ef.DocumentChecklist);
          enrolmentForm.OwnsOne(ef => ef.MedicalInformation);
          enrolmentForm.OwnsMany(ef => ef.EmergencyContactDetails);
          enrolmentForm.OwnsOne(ef => ef.BillingAddress);
          enrolmentForm.OwnsOne(ef => ef.DeclarationOfCommitment);
          enrolmentForm.OwnsOne(ef => ef.Feedback);
        });
    }
}
