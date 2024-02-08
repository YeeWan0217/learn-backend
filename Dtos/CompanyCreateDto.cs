using System;
using Backend.Core.Enums;

namespace Backend.Dtos
{
	public class CompanyCreateDto
	{
        public string Name { get; set; }

        public CompanySize Size { get; set; }
    }
}

