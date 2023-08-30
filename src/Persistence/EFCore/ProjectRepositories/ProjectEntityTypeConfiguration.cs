﻿using Domain.ProjectAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.ProjectRepository
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(nameof(ModuleDbContext.Projects));
            builder.HasKey(x => x.Id);

            builder.HasMany(e => e.Sprints)
                .WithOne(e => e.Project)
                .HasForeignKey(e => e.ProjectId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}