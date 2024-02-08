﻿using System;
using Backend.Core.Enums;

namespace Backend.Entities
{
	public class Job :BaseEntity
	{
		public string Title { get; set; }

		public JobLevel Level { get; set; }

		//Relation
		public long CompanyId { get; set; }

		public Company Company { get; set; }

		public ICollection<Candidate> Candidates { get; set; }

		
	}
}

