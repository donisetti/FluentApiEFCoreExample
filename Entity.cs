using System;

namespace FluentApiEFCoreExample
{
    public class Entity
    {
        public Entity()
        {
            UId = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }

        public string UId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdateAt { get; private set; }

        public void ModifiedEntity()
        {
            LastUpdateAt = DateTime.Now;
        }
    }
}