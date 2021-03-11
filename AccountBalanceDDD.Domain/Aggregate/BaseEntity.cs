using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class BaseEntity<Guid> : IEntity<Guid>
    {
        public BaseEntity()
        {

        }
        protected BaseEntity(Guid id) => Id = id;

        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity<Guid>;
            return entity != null && this.GetType() == entity.GetType() && EqualityComparer<Guid>.Default.Equals(Id, entity.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.GetType(), Id);
        }

        public static bool operator ==(BaseEntity<Guid> entity1, BaseEntity<Guid> entity2)
        {
            return EqualityComparer<BaseEntity<Guid>>.Default.Equals(entity1, entity2);
        }

        public static bool operator !=(BaseEntity<Guid> entity1, BaseEntity<Guid> entity2)
        {
            return !(entity1 == entity2);
        }

    }
}
