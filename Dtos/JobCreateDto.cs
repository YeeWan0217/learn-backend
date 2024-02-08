using System;
using Backend.Core.Enums;

namespace Backend.Dtos
{
	public class JobCreateDto
	{
        public string Title { get; set; }

		public JobLevel Level { get; set; }

		public long CompanyId { get; set; }

	}
}

