using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain.Commands
{
    public class DeleteCommand : IRequest<bool>
    {
        public Guid param_obj { get; set; }
    }
}
