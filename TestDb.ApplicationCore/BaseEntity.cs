using System;

namespace TestDb.ApplicationCore
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
    }
}
