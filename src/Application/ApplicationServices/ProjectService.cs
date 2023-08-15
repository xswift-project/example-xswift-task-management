﻿using MediatR;
using CoreX.Datastore;
using Contract;
using Domain.ProjectAggregation;

namespace Application
{
    public class ProjectService : IProjectService
    {
        private readonly IMediator _mediator;
        private readonly IDbTransaction _transaction;

        public ProjectService(
            IMediator mediator,
            IDbTransaction transaction)
        {
            _mediator = mediator;
            _transaction = transaction;
        }
        public async Task<Guid> Process(DefineANewProject request)
        {
            var id = await _mediator.Send(request);
            await _transaction.SaveChangesAsync();
            return id;
        }
        public async Task Process(ChangeTheProjectName request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }
        public async Task Process(ArchiveTheProject request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }

        public async Task Process(RestoreTheProject request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }
        public async Task Process(DeleteTheProject request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync();
        }
        public async Task<ProjectDetailsViewModel> Process(GetTheProjectDetails request)
        {
            return await _mediator.Send(request);
        }

        public async Task<List<ProjectDetailsViewModel>> Process(GetSomeProjectDetails request)
        {
            return await _mediator.Send(request);
        }
    }
}
