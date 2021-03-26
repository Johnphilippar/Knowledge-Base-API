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
    public class UpdateHandlers : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IKnowledgeBaseRepository repo;
        public UpdateHandlers(IKnowledgeBaseRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.update(request.param_obj);
            return result;
        }
    }
}
