using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Command.DeleteCartItem
{
    public class DeleteCartItemCommand : IRequest<bool>
    {
        public int CartItemId { get; set; }
    }
}
