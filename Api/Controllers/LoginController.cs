using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using System.Text;
using Api.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ApiDbContext dbcontext) : ControllerBase
{
    private readonly ApiDbContext dbcontext = dbcontext;

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        User? user = await dbcontext.Users
          .Include(u => u.EnrolmentForm)
          .FirstOrDefaultAsync(u => u.Email == req.Email);

        if (user is null)
        {
            return BadRequest(new { message = $"User with email {req.Email} does not exist" });
        }

        if (user.HashedPassword != Encoding.UTF8.GetBytes(req.Password))
        {
            return BadRequest(new { message = $"Incorrect password" });
        }

        return Ok(new
        {
            user = user,
            token = "FIX THIS STUPID ASS TOKEN",
        });
    }
}
