using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Api.Models.Forms.Enrolment;

namespace Api.Controllers;

[ApiController]
[Route("api/users/{userId}/forms/enrolment")]
public class EnrolmentFormController(ApiDbContext dbcontext) : ControllerBase
{
    private readonly ApiDbContext dbcontext = dbcontext;

    [HttpPatch]
    public async Task<IActionResult> UpdateEnrolmentForm(int userId, [FromBody] JsonPatchDocument<EnrolmentForm> req)
    {
        User? user = await dbcontext.Users
          .Include(u => u.EnrolmentForm)
          .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return BadRequest(new { message = $"User with ID {userId} not found" });
        }

        EnrolmentForm? formToUpdate = user.EnrolmentForm;
        req.ApplyTo(formToUpdate, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await dbcontext.SaveChangesAsync();
        return Ok(new
        {
            form = formToUpdate,
            message = $"Successfully updated enrolment form for user with {userId}",
        });
    }
}
