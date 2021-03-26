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
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository ICommentRepository;
        private readonly IMediator mediator;

        public CommentService(IMediator mediator , ICommentsRepository ICommentRepository)
        {
            this.ICommentRepository = ICommentRepository;
            this.mediator = mediator;
        }
        public async Task<CommentsModel> createComments(CommentsModel param_obj)
        {
            var result = await mediator.Send(new CommentsCommand() { param_obj = param_obj });
            return result;
        }

        public async Task<List<CommentsModel>> getComments(Guid KNOWLEDGE_BASE_ID)
        {
            return await Task.FromResult(await ICommentRepository.getComments(KNOWLEDGE_BASE_ID));
        }
    }
}
