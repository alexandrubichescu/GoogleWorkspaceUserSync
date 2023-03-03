using Microsoft.AspNetCore.Mvc;
using GWUserSync.Models;
using GWUserSync.Service;
using GWUserSync.Authorization;

namespace GWUserSync.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiKeyAuthorization]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var userList = await _userService.GetAllUsersAsync();
        return Ok(userList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user != null)
        {
            return Ok(user);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
    {
        var userId = await _userService.AddUserAsync(userModel);
        if (ModelState.IsValid)
        {
            return Ok(userId);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] UserModel userModel)
    {
        var succes = await _userService.UpdateUserAsync(userModel);
        if (succes)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var succes = await _userService.DeleteUserAsync(id);
        if (succes)
        {
            return Ok(succes);
        }
        else
        {
            return NotFound();
        }
    }
}

