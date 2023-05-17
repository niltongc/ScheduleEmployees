using AutoMapper;
using EmployeeSchedule.Models.Domain;
using EmployeeSchedule.Models.DTO;
using EmployeeSchedule.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var userDomainModel = mapper.Map<User>(addUserRequestDto);

            await userRepository.CreateAsync(userDomainModel);

            var userDtoModel = mapper.Map<UserDto>(userDomainModel);

            return Ok(userDtoModel);
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            var userDomainModel = await userRepository.GetByEmailAsync(email);

            if (userDomainModel == null) 
            {
                return NotFound();
            }

            var userDtoModel = mapper.Map<UserDto>(userDomainModel);

            return Ok(userDtoModel);
        }

        [HttpGet]
        public async Task<IActionResult>GetAllUsers()
        {
            var usersDomainModel = await userRepository.GetAllAsync();

            var usersDto = mapper.Map<List<UserDto>>(usersDomainModel);
            
            return Ok(usersDto);
        }

        [HttpPut]
        [Route("{email}")]
        public async Task<IActionResult> Update([FromRoute] string email, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomainModel = mapper.Map<User>(updateUserRequestDto);

            userDomainModel = await userRepository.UpdateUserAsync(email, userDomainModel);

            if (userDomainModel == null) 
            {
                return NotFound();
            }

            var userDto = mapper.Map<UserDto>(userDomainModel);

            return Ok(userDto);
        }
        
    }
}
