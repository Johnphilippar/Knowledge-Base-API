using CLEAN_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain.Commands
{
    public class UpdateCommand : IRequest<bool>
    {
        public ArticleModel param_obj { get; set; }
    }
}
