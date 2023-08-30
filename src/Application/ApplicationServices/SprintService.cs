﻿using MediatR;
using CoreX.Datastore;
using Contract;
using Domain.SprintAggregation;

namespace Application
{
    public class SprintService : ISprintService
    {
        private readonly IMediator _mediator;
        private readonly IDbTransaction _transaction;

        public SprintService(
            IMediator mediator,
            IDbTransaction transaction)
        {
            _mediator = mediator;
            _transaction = transaction;
        }
        public async Task<Guid> Process(DefineANewSprint request)
        {
            var id = await _mediator.Send(request);
            await _transaction.SaveChangesAsync();
            return id;
        }
        public async Task Process(ChangeTheSprintName request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }
        public async Task Process(ChangeTheSprintTimeSpan request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }
        public async Task Process(ArchiveTheSprint request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }

        public async Task Process(RestoreTheSprint request)
        {
            await _mediator.Send(request);
            await _transaction.SaveChangesAsync(concurrencyCheck: true);
        }
        public async Task<SprintInfo?> Process(GetTheSprintInfo request)
        {
            return await _mediator.Send(request);
        }

        public async Task<List<SprintInfo>> Process(GetSomeSprintInfo request)
        {
            return await _mediator.Send(request);
        }
    }
}