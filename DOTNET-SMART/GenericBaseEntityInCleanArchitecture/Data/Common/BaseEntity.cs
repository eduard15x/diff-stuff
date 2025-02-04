using GenericBaseEntityInCleanArchitecture.Data.Utils;

namespace GenericBaseEntityInCleanArchitecture.Data.Common
{
    // * abstract doesn't allow this class to be instantiated, only inherited
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public Guid ExternalId { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}