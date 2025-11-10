namespace Api;

using Api.Models.Forms.Enrolment;
using Microsoft.EntityFrameworkCore;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext {
  public DbSet<EnrolmentForm> Users { get; set; } = null!;
  public DbSet<EnrolmentForm> EnrolmentForms { get; set; } = null!;
}
