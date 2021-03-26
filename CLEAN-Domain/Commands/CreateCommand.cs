using CLEAN_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain.Commands
{
    public class CreateCommand : IRequest<ArticleModel>
    {
        public ArticleModel param_obj { get; set; }
    }
}
