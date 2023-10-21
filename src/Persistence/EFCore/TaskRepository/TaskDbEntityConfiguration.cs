﻿using Domain.TaskAggregation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.TaskRepository
{
    public class TaskDbEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable(nameof(ModuleDbContext.Tasks));
            builder.HasKey(x => x.Id);
        }
    }
}