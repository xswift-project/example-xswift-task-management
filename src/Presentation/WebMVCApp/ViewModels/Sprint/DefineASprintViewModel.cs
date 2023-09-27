﻿using Domain.ProjectAggregation;
using Domain.SprintAggregation;

namespace Presentation.WebMVCApp.ViewModels
{
    public class DefineASprintViewModel
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public ProjectInfo? ProjectInfo { get; set; }

        public DefineASprint ToRequest()
        {
            return new DefineASprint(ProjectId, Name);
        }
    }
}