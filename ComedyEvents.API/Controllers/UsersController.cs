using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ComedyEvents.Services;
using ComedyEvents.Domain.Dtos;
using ComedyEvents.Domain.Models;

namespace ComedyEvents.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// User authentification 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.ConnectUser(model.UserName, model.Pwd);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<BaseResponseDto<IEnumerable<UserDto>>>> GetAllUsers()
        {
            BaseResponseDto<IEnumerable<UserDto>> users = await _userService.GetUsers();

            if (!users.HasError || users.Data != null)
            {
                return Ok(users.Data);
            }
            else if (!users.HasError || users.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(users.Errors);
            }
        }

    }
}