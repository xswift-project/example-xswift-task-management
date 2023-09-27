﻿using XSwift.Domain;
using MediatR;

namespace Domain.TaskAggregation
{
    public class RestoreTheTask :
        RestorationRequestById<RestoreTheTask, Task, Guid>, IRequest
    {
        public RestoreTheTask(Guid id) : base(id)
        {
            ValidationState.Validate();
        }
        public override async Task<Task> ResolveAndGetEntityAsync(
            IMediator mediator)
        {
            var entity = await mediator.Send(
                new GetTheTask(Id, evenArchivedData: true));
            await base.ResolveAsync(mediator, entity!);
            return entity!;
        }
    }
}