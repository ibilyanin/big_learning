using Elang.Domain.Entities;

namespace Elang.ApplicationCore.Mappings;
internal static class MappingExtensions
{
    public static CardType? ParseCardType(this string? cardType)
    {
        return cardType is null ? default(CardType?) : Enum.Parse<CardType>(cardType);
    }
}
