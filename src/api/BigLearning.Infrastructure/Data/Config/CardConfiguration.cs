using Elang.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elang.Infrastructure.Data.Config;
internal class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.Property(p => p.Translation)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.English)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(p => p.ContextDescription)
               .HasMaxLength(250);

        builder.Property(p => p.Type)
               .HasConversion<int>(p => (int)p, p => (CardType)p)
               .IsRequired();

        builder.Property(p => p.Id)
               .HasIdentityOptions()
               .IsRequired();

        builder.Navigation(x => x.Topics);

        builder.HasKey(x => x.Id);
    }
}
