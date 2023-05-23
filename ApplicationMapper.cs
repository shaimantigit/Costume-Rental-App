using AutoMapper;
using FinalMockProject.Models;
using FinalMockProject.Models.Authentication;
using FinalMockProject.Models.DTO;

namespace FinalMockProject.Mapper

{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
        CreateMap<Product,ProductDTO>().ReverseMap();
        CreateMap<Order,OrderDTO>().ReverseMap();
        CreateMap<User,AddUserDTO>().ReverseMap();
            CreateMap<User, AuthUserLogin>().ReverseMap();

        }
    }
}
