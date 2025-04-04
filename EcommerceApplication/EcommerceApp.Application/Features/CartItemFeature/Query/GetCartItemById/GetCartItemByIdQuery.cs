﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Query.GetCartItemById
{
    public class GetCartItemByIdQuery : IRequest<CartItem>
    {
        public int CartItemId { get; set; }
    }
}
