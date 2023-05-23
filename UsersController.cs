using AutoMapper;
using FinalMockProject.DAL;
using FinalMockProject.DAL.Interface;
using FinalMockProject.Models;
using FinalMockProject.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FinalMockProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
      
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;

        public UsersController(IUsersRepository userRepository, IMapper mapper)
        {
           
            _mapper = mapper;
            _userRepository= userRepository;  
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = _mapper.Map<IEnumerable<AddUserDTO>>(users);
            return Ok(userDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id); 
            if (user == null) 
                return NotFound();
            var userDto = _mapper.Map<AddUserDTO>(user);
            return Ok(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserDTO userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<User>(userDto);

            await _userRepository.AddAsync(user);
            var createdUserDto = _mapper.Map<AddUserDTO>(user);
            return  Ok(createdUserDto);
        }
       [ HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, AddUserDTO userDto)
        {

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            _mapper.Map(userDto, existingUser);

            await _userRepository.UpdateAsync(existingUser);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            await _userRepository.DeleteAsync(existingUser);
            return Ok("User deleted sauccessfully");
        }
    

}
}
