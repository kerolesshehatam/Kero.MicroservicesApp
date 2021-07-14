namespace Ordering.Domain.Common
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }


}
