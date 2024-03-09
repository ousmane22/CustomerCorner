using AutoMapper;
using CustomerCorner.Application.Contracts.Persistence;
using CustomerCorner.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Application.Features.Users.Queries.GetListUsers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListDTO>>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserListDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(x => x.Name).ToList();

            return _mapper.Map<List<UserListDTO>>(allUsers);
        }
    }
}
