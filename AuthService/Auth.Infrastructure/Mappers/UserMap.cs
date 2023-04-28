using Auth.Core.Entities;
using Auth.Infrastructure.Commands;
using Auth.Infrastructure.Queries;
using Auth.Infrastructure.Responses;
using AutoMapper;

namespace Auth.API.Mappers
{
    public class UserMap:Profile
    {
        public UserMap()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<GetEmployeeQuery, User>().ReverseMap();
            CreateMap<GetEmployeesQuery, User>().ReverseMap();
            CreateMap<GetEmployeeResponse, User>().ReverseMap();
            CreateMap<User,CreateUserResponse>().ReverseMap();
            CreateMap<LoginQuery,User>().ReverseMap();
            CreateMap<LoginResponse,User>().ReverseMap();
        }
    }
}
