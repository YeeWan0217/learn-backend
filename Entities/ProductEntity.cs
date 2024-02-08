using System;
namespace Backend.Entities
{
	public class ProductEntity
	{

		public long id { get; set; }

		public string brand { get; set; }

		public string title { get; set; }

		public DateTime createdAt { get; set; } = DateTime.Now;

		public DateTime updatedAt { get; set; } = DateTime.Now;

    }
}

