using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Api.Services;
using Api.Models;
using Api.DTOs;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController(ApiDbContext dbcontext, TokenService tokenService) : ControllerBase
{
    private readonly ApiDbContext dbcontext = dbcontext;
    private readonly TokenService tokenService = tokenService;

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

        PasswordHasher<User> passwordHasher = new();
        PasswordVerificationResult verificationResult = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, req.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        if (verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            user.HashedPassword = passwordHasher.HashPassword(user, req.Password);
            try
            {
                await dbcontext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        return Ok(new
        {
            user = UserResponse.FromEntity(user),
            token = tokenService.GenerateToken(user),
            message = $"Successfully logged in user with email {user.Email}",
        });
    }
}
