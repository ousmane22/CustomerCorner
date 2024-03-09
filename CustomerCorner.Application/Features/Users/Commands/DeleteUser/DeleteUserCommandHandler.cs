using AutoMapper;
using CustomerCorner.Application.Contracts.Persistence;
using CustomerCorner.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deletedUser = await _userRepository.GetByIdAsync(request.Id);

            await _userRepository.DeleteAsync(deletedUser);
        }
    }
}
