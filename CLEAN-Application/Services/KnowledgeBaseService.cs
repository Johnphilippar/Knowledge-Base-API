using CLEAN_Application.Interface;
using CLEAN_Domain.Commands;
using CLEAN_Domain.Interface;
using CLEAN_Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CLEAN_Application.Services
{
    public class KnowledgeBaseService : IKnowledgeBaseService
    {
        private readonly IKnowledgeBaseRepository IKnowledgeBaseRepository;
        
        private readonly IMediator mediator;

        public KnowledgeBaseService(IMediator mediator , IKnowledgeBaseRepository IKnowledgeBaseRepository)
        {
            this.mediator = mediator;
            this.IKnowledgeBaseRepository = IKnowledgeBaseRepository;
        }
        public async Task<List<ArticleModel>> get()
        {
            return await Task.FromResult(await IKnowledgeBaseRepository.get());
        }
        public async Task<string> getDescription(Guid KnowledgeBaseNumber)
        {
            return await Task.FromResult(await IKnowledgeBaseRepository.getDescription(KnowledgeBaseNumber));
        }

        public async Task<ArticleModel> create(ArticleModel param_obj)
        {
            var result = await mediator.Send(new CreateCommand() { param_obj = param_obj });
            return result;
        }


        public async Task<bool> update(ArticleModel param_obj)
        {
            var result = await mediator.Send(new UpdateCommand() { param_obj = param_obj });
            return result;
        }

        public async Task<bool> delete(Guid param_obj)
        {
            var result = await mediator.Send(new DeleteCommand() { param_obj = param_obj });
            return result;
        }

        
    }
}
