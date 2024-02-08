using System;
using Backend.Core.Enums;

namespace Backend.Dtos
{
	public class JobGetDto
	{
        public long id { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public string Title { get; set; }

        public JobLevel Level { get; set; }

        public string CompanyName { get; set; }

        public long CompanyId { get; set; }
    }
}

