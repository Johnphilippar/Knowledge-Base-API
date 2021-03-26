using CLEAN_Domain.Commands;
using CLEAN_Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLEAN_Domain.CommandHandlers
{
    public class DeleteHandlers : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IKnowledgeBaseRepository repo;
        public DeleteHandlers(IKnowledgeBaseRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.delete(request.param_obj);
            return result;
        }
    }
}
