using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Context;
using Backend.Core.Enums;
using Backend.Dtos;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("seed-roles")]
        public async Task<ActionResult> SeedRoles()
        {
            var seedRoles = await _authService.SeedRolesAsync();

            return Ok(seedRoles);
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<ActionResult> RegisterUser ([FromBody] RegisterDto dto)
        {
            var registerResult = await _authService.RegisterAsync(dto);

            if(registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var loginResult = await _authService.LoginAsync(dto);

            if (loginResult.IsSucceed)
                return Ok(loginResult);

            return Unauthorized(loginResult);
        }

        [HttpPost]
        [Route("makeAdmin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto dto)
        {
            var makeAdminResult = await _authService.MakeAdminAsync(dto);

            if (makeAdminResult.IsSucceed)
                return Ok(makeAdminResult);

            return BadRequest(makeAdminResult);
        }

        //[HttpPost]
        //[Route("makeOwner")]
        //public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto dto)
        //{
        //    var user = await _userManager.FindByNameAsync(dto.UserName);

        //    if (user is null)
        //        return BadRequest("Invalid User Name");

        //    await _userManager.AddToRoleAsync(user, StaticUserRoles.OWNER);


        //    return Ok("User is now OWNER");
        //}

        [HttpGet]
        [Route("GetUserRole")]
        [Authorize(Roles = StaticUserRoles.USER)]
        public IActionResult GetUserRole ()
        {
            return Ok("User role is get");
        }

        [HttpGet]
        [Route("GetAdminRole")]
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        public IActionResult GetAdminRole()
        {
            return Ok("Admin role is get");
        }

    }
}

