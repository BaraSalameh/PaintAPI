﻿using Application.Common.Entities;
using MediatR;

namespace Application.Admin.Commands.UserCommands
{
    public class ActivateUserCommand : IRequest<AbstractViewModel>
    {
        public int ID { get; set; }
    }
}
