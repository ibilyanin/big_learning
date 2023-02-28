namespace SharedKernel.Exceptions;

public class EntityNotFoundException : DomainException
{
    public EntityNotFoundException(string nameOfEntity)
        : base($"Entity {nameOfEntity} not found.")
    {
    }

    public EntityNotFoundException(string nameOfEntity, object? idValue)
        : base($"Entity {nameOfEntity} with id = {idValue} not found.")
    {

    }

    public EntityNotFoundException(string nameOfEntity, params string[] conditions)
        : base($"Entity {nameOfEntity} where {string.Join(" and ", conditions)} not found.")
    {
    }
}
