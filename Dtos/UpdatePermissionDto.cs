using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
	public class UpdatePermissionDto
	{
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
    }
}

