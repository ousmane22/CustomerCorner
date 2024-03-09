﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Application.Features.Users.Queries.GetListUsers
{
    public class GetUserListQuery : IRequest<List<UserListDTO>>
    {
    }
}
