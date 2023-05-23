using FinalMockProject.DAL.Interface;
using FinalMockProject.Data;
using FinalMockProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalMockProject.DAL
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }
            public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Include("Roles").FirstOrDefaultAsync(x => x.User_Email == email);
        }
    }
}
