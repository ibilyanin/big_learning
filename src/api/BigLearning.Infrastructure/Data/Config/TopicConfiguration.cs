using System;
using Elang.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elang.Infrastructure.Data.Config;
internal class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.Property(p => p.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.Id)
               .HasIdentityOptions()
               .IsRequired();

        builder.HasKey(x => x.Id);
    }
}
