using AutoMapper;
using CustomerCorner.Application.Features.Users.Commands.CreateUser;
using CustomerCorner.Application.Features.Users.Queries.GetListUsers;
using CustomerCorner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Application.Profiles
{
    public  class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
        }
    }
}
