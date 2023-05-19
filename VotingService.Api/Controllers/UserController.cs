using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))]
        public IActionResult GetUser()
        {
            //var user = _mapper.Map<List<UserGetDto>>(_userRepository.GetUser());
            var user = _userService.GetUser();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserLoginDto usercreate)
        {

            if (usercreate == null)
            {
                return BadRequest(ModelState);
            }
            //var passwordHasher = new PasswordHasher<UserLoginDto>();
            //usercreate.Password = passwordHasher.HashPassword(null, usercreate.Password);

            //var user = _userRepository.GetUser().Where(c => c.Username.ToLower() == usercreate.Username.ToLower() &&
            //c.Password == usercreate.Password).FirstOrDefault();

            //if (user != null)
            //{
            //    ModelState.AddModelError("", "User Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //var userMap = _mapper.Map<UserModel>(usercreate);

            if (!_userService.CreateUser(usercreate))
            {
                ModelState.AddModelError("", "User is not Created [USERCONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }
    }


}
