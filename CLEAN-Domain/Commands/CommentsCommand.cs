using CLEAN_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain.Commands
{
    public class CommentsCommand : IRequest<CommentsModel>
    {
        public CommentsModel param_obj { get; set; }
    }
}
