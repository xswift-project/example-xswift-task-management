﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using FluentAssertions.XSwift;
using Contract;
using Domain.SprintAggregation;
using XSwift.Domain;

namespace SprintFeature
{
    internal class ToChangeTheNameOfASprintToANewNameAndGivenASprintWithTheSameNewNameHasAlreadyExistedForThisProject
    {
        private readonly ISprintService _service;
        private ChangeTheSprintName? _request = null;
        private Func<Task>? _actual = null;

        internal ToChangeTheNameOfASprintToANewNameAndGivenASprintWithTheSameNewNameHasAlreadyExistedForThisProject(IServiceScope serviceScope)
        {
            _service = serviceScope.ServiceProvider.GetRequiredService<ISprintService>();
        }
        internal void GivenIWantToChangeTheNameOfASprintToANewName(Guid sprintId, string newSprintName)
        {
            _request = new ChangeTheSprintName(sprintId, newSprintName);
        }
        internal async Task AndGivenASprintTheSameNewNameHasAlreadyExistedForThisProject(Guid projectId, string sprintName)
        {
            await _service.Process(new DefineASprint(projectId, sprintName));
        }
        internal void WhenIRequestIt()
        {
            _actual = async () => await _service.Process(_request!);
        }
        internal async Task ThenTheRequestSholudBeDenied()
        {
            await _actual.Should().BeSatisfiedWith<AnEntityWithTheseUniquenessConditionsHasAlreadyBeenExisted>();
        }
    }
}