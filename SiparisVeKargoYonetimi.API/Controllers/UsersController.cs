using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisVeKargoYonetimi.Core.Dtos;
using SiparisVeKargoYonetimi.DATA.Services.IService;

namespace SiparisVeKargoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Authenticate(UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
            {
                return BadRequest(new {message = "Kullanıcı adı veya parola hatalı!"});
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            bool userBool = _userService.IsUniqUser(userDto.Username);
            if (!userBool)
            {
                return BadRequest(new { message = "Kullanıcı adı zaten kayıtlı!" });
            }
            var user = _userService.Register(userDto.Username, userDto.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Kayıt esnasında hata oluştu!" });
            }
            return Ok();
        }


    }
}
