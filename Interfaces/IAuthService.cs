using System;
using Backend.Dtos;

namespace Backend.Services
{
	public interface IAuthService
	{
		Task<AuthServiceResponseDto> SeedRolesAsync();

		Task<AuthServiceResponseDto> RegisterAsync(RegisterDto dto);

		Task<AuthServiceResponseDto> LoginAsync(LoginDto dto);

        Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto dto);
    }
}

