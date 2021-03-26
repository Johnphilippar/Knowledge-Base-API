using CLEAN_Domain.Commands;
using CLEAN_Domain.Interface;
using CLEAN_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLEAN_Domain.CommandHandlers
{
    public class CommentsHandlers : IRequestHandler<CommentsCommand, CommentsModel>
    {
        private readonly ICommentsRepository repo;

        public CommentsHandlers(ICommentsRepository repo)
        {
            this.repo = repo;
        }

        public async Task<CommentsModel> Handle(CommentsCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.createComments(request.param_obj);
            return result;
        }
    }
}
