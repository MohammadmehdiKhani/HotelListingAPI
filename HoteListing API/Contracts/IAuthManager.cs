using HoteListing_API.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace HoteListing_API.Contracts;

public interface IAuthManager
{
    Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
    Task<AuthResponseDto> login(LoginDto loginDto);
}