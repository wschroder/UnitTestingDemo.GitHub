using System;
using ZooManager.Providers;

namespace ZooManager.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }

        public string Name { get; }

        public DateTime CreatedOn { get; }

        public DateTime LastModifiedOn { get; set; }

        protected BaseEntity(string name): this(name, UtcDateTimeProvider.Instance)
        {
        }

        protected BaseEntity(string name, IDateTimeProvider dateTimeProvider)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreatedOn = dateTimeProvider.UtcNow();
        }
    }
}
