using FinalMockProject.Data;
using FinalMockProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalMockProject.DAL.Interface
{
   
    public interface ILoginRepository
    {

       
            Task<User> GetByEmailAsync(string email);
    }
}
