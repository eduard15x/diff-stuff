namespace GenericBaseEntityInCleanArchitecture.Data.Common
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        public Guid ExternalId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}