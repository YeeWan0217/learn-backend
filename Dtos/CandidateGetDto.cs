using System;
namespace Backend.Dtos
{
	public class CandidateGetDto
	{
        public long id { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ResumeUrl { get; set; }

        public string CoverLetter { get; set; }

        public long JobId { get; set; }

        public string JobTitle { get; set; }
    
	}
}

