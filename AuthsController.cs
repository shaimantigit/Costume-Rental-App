using AutoMapper;
//using FinalMockProject.BLL;
using FinalMockProject.DAL.Interface;
using FinalMockProject.Data;
using FinalMockProject.Helper;
using FinalMockProject.Models;
using FinalMockProject.Models.Authentication;
using FinalMockProject.Models.DTO;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalMockProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userrepository;
        private readonly ILoginRepository _loginRepository;

        public AuthsController(ApplicationDbContext context, IConfiguration configuration, IMapper mapper, IUsersRepository userrepository, ILoginRepository loginRepository)
        {
            _context = context;
            _mapper = mapper;
            _userrepository = userrepository;

            _configuration = configuration;
            _loginRepository=loginRepository;





        }

     
        [Route("login")]
        [HttpPost]
        public IActionResult Login(AuthUserLogin loginModel)
        {

            User user = _context.Users.Include(x => x.Roles).SingleOrDefault(x => x.User_Email == loginModel.User_email);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            string hashedPassword = HashPassword(loginModel.User_Password);
            if (BCrypt.Net.BCrypt.Verify(loginModel.User_Password, hashedPassword))
            {

                var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.Roles.RoleName  },
                { "RoleId", user.Roles.RoleId.ToString() },
                {JwtClaimTypes.PreferredUserName, user.User_Name },
                { JwtClaimTypes.Id, user.User_Id.ToString() },
                { JwtClaimTypes.Email, user.User_Email}
            }, _configuration["JWT:Key"]);



                return Ok(new AuthResponse { token = token, User_Name = user.User_Name });
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }
        [Route("Registration")]
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AddUserDTO addUserDTO)
        {

            // Check if a user with the same email already exists
            var existingUser = await _loginRepository.GetByEmailAsync(addUserDTO.User_Email);
            if (existingUser != null)
            {
                // Return an error response indicating that the email is already registered
                return BadRequest("Email is already registered.");
            }
            //Map DTO to Domain Model           
            var userEntity = _mapper.Map<User>(addUserDTO);
            userEntity.User_Password = HashPassword(addUserDTO.User_Password);



            await _userrepository.AddAsync(userEntity);
            //var users = mapper.Map<UserDTO>(userEntity);

            return Ok("Registration Successful");
        }
        private string HashPassword(string password)
        {
            
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
    }
}

