using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Api.Models;
using Api.DTOs;
using System.Text;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(ApiDbContext dbcontext) : ControllerBase
{
    private readonly ApiDbContext dbcontext = dbcontext;

    [HttpPost]
    public async Task<IActionResult> CreateNewUser(CreateUserRequest req)
    {
        User? existingUser = await dbcontext.Users.FirstOrDefaultAsync(user => user.Email == req.Email);
        if (existingUser is not null)
        {
            return BadRequest(new { message = $"User with email {existingUser.Email} already exists" });
        }

        PasswordHasher<User> passwordHasher = new();
        User newUser = new()
        {
            Email = req.Email,
            EnrolmentForm = new(),
        };
        newUser.HashedPassword = passwordHasher.HashPassword(newUser, req.Password);

        await dbcontext.Users.AddAsync(newUser);

        try
        {
            await dbcontext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(new
        {
            user = newUser,
            message = "User created successfully"
        });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserByID(int userId)
    {
        User? user = await dbcontext.Users
          .Include(u => u.EnrolmentForm)
          .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return BadRequest(new { message = $"User with ID {userId} not found" });
        }

        return Ok(new
        {
            user = user,
            message = $"Successfully found user with ID {user.Id}",
        });
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUserByID(int userId)
    {
        User? user = await dbcontext.Users
          .Include(u => u.EnrolmentForm)
          .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return BadRequest(new { message = $"User with ID {userId} not found" });
        }

        dbcontext.Users.Remove(user);

        try
        {
            await dbcontext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(new
        {
            message = $"Successfully deleted user with ID {user.Id}",
        });
    }
}
