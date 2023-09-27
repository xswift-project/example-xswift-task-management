﻿using MediatR;
using CoreX.Datastore;
using Domain.ProjectAggregation;
using EntityFrameworkCore.CoreX.Datastore;

namespace Persistence.EFCore.ProjectRepository
{
    internal class GetTheProjectHandler :
        IRequestHandler<GetTheProject, Project?>
    {
        private readonly Database _database;
        public GetTheProjectHandler(IDatabase database)
        {
            _database = (Database)database;
        }

        public async Task<Project?> Handle(
            GetTheProject request,
            CancellationToken cancellationToken)
        {
            return await _database.GetItemAsync<GetTheProject, Project>(request: request);
        }
    }
}
