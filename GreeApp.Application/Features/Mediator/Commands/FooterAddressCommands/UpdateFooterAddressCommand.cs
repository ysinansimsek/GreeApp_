﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreeApp.Application.FooterAddresss.Mediator.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int FooterAddressId { get; set; }
        public string Address { get; set; } 
        public string Description { get; set; } 
    }
}
