﻿using MediatR;
using Module.Domain.TaskAggregation;
using XSwift.Datastore;
using XSwift.EntityFrameworkCore;

namespace Module.Persistence.TaskRepository
{
    public class ArchiveTheTaskHandler :
        IRequestHandler<ArchiveTheTask>
    {
        private readonly IMediator _mediator;
        private readonly Database _database;
        public ArchiveTheTaskHandler(
           IMediator mediator, IDatabase database)
        {
            _mediator = mediator;
            _database = (Database)database;

            _database.ResolveSoftDeleteConfiguration(
                new ModuleDeletabilityConfigurationFactory()
                .CreateInstance(database));
        }

        public async Task<Unit> Handle(
            ArchiveTheTask request,
            CancellationToken cancellationToken)
        {
            var entity = await request.ResolveAndGetEntityAsync(_mediator);
            await _database.ArchiveAsync(request, entity);
            return new Unit();
        }
    }
}
