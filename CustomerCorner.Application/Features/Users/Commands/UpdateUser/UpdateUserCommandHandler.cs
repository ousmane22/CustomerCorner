﻿using AutoMapper;
using CustomerCorner.Application.Contracts.Persistence;
using CustomerCorner.Application.Exceptions;
using CustomerCorner.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {

        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
           var userToUpdate = await _userRepository.GetByIdAsync(request.Id);

            if(userToUpdate == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            var validator = new UpdateUserCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new ValidationException(validatorResult);

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

            await _userRepository.UpdateAsync(userToUpdate);
        }
    }
}
