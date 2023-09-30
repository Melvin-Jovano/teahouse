using teahouse.Dtos.Auth;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.AuthService {
    public interface IAuthService {
        Task<ServiceResponse<GetUserDto>> Login(LoginDto user);
        Task<ServiceResponse<GetUserDto>> Register(RegisterDto user);
    }
}