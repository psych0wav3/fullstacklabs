using System;

namespace monetize.domain.entities
{
    public abstract class Entity
    {
        public Entity(){
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }
    }
}