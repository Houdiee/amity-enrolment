using Microsoft.AspNetCore.Mvc;
using Api.Models.Forms.Enrolment;

namespace Api.Controllers;

[ApiController]
[Route("api/forms/enrolment")]
public class EnrolmentFormController(ApiDbContext dbcontext) : ControllerBase {
  private readonly ApiDbContext dbcontext = dbcontext;

  [HttpPatch]
  public async Task<IActionResult> UpdateEnrolmentForm(EnrolmentForm req) {
    // TODO
    return Ok();
  }
}
