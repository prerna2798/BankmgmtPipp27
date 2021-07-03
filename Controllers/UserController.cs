using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AuthServiceProject.Models;
using AuthServiceProject.TokenService;
using AuthServiceProject.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using log4net;

namespace AuthServiceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ILog _log4net = LogManager.GetLogger(typeof(UserController));

        public UserController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(User userDTO)
        {
            _log4net.Info($"HttpPost request : {nameof(Login)}");
            try
            {
                var isValid = await _tokenService.ValidateUser(userDTO);
                if (!isValid)
                {
                    return Unauthorized("Invalid Credentials");
                }

                var tokenUser = new TokenDTO
                {
                    UId = userDTO.UId,
                    Token = await _tokenService.CreateToken(userDTO)
                };
                return tokenUser;
            }
            catch(Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(Login)}");
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            _log4net.Info($"HttpGet request  : {nameof(GetUser)}");
            try
            {
                var user = await _userService.GetUser(id);
                if (user != null)
                {
                    return user;
                }
                else
                    return NotFound();
            }
            catch(Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(GetUser)}");
                return BadRequest("Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {
            _log4net.Info($"HttpPost request  : {nameof(Register)}");
            try
            {
                await _userService.AddUser(user);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(Register)}");
                return BadRequest("Already Registered");
            }
            catch (Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(Register)}");
                return BadRequest("Internal Server Error");
            }

        }

        [Authorize]
        [HttpPost("applyloan")]
        public async Task<ActionResult> ApplyLoan(UserLoan userLoan)
        {
            _log4net.Info($"HttpPost request  : {nameof(ApplyLoan)}");
            try
            {
                await _userService.ApplyLoan(userLoan);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(ApplyLoan)}");
                return BadRequest("Loan already applied");
            }
            catch(Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(ApplyLoan)}");
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpGet("getUserLoan/{id}")]
        public async Task<ActionResult<UserLoan>> GetUserLoan(string id)
        {
            _log4net.Info($"HttpGet request  : {nameof(GetUserLoan)}");
            try
            {
                var user = await _userService.GetUserLoan(id);
                if (user != null)
                {
                    return user;
                }
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(GetUserLoan)}");
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpPost("updateUser")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            _log4net.Info($"HttpPost request  : {nameof(UpdateUser)}");
            try
            {
                await _userService.UpdateUser(user);
                return Ok();
            }
            catch(DbUpdateConcurrencyException e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(UpdateUser)}");
                return BadRequest("User Id does not exist");
            }
            catch (Exception e)
            {
                _log4net.Error($"Exception Occured : {e.Message} from {nameof(UpdateUser)}");
                return BadRequest("Internal Server Error");
            }
        }

    }
}
