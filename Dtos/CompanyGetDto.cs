using System;
using Backend.Core.Enums;
using Backend.Entities;

namespace Backend.Dtos
{
	public class CompanyGetDto
	{
        public long id { get; set; }

		public DateTime createdAt { get; set; } = DateTime.Now;

        public string Name { get; set; }

        public CompanySize Size { get; set; }

    }
}

