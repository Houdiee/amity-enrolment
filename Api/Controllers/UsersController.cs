using Microsoft.AspNetCore.Mvc;
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
        User user = new()
        {
            Email = req.Email,
            HashedPassword = Encoding.UTF8.GetBytes(req.Password),
            EnrolmentForm = new(),
        };

        await dbcontext.Users.AddAsync(user);

        return Ok(new { message = "User created successfully" });
    }
}
