using System;
namespace Backend.Entities
{
	public abstract class BaseEntity
	{
        public long id { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public DateTime updatedAt { get; set; } = DateTime.Now;

        public bool isActive { get; set; }
    }
}

