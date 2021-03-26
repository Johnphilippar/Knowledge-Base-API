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
    public class CreateHandlers : IRequestHandler<CreateCommand, ArticleModel>
    {
        private readonly IKnowledgeBaseRepository repo;
        public CreateHandlers(IKnowledgeBaseRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ArticleModel> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var result = await repo.create(request.param_obj);
            return result;
        }
    }
}
