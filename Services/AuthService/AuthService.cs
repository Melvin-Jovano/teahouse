using AutoMapper;
using Microsoft.AspNetCore.Identity;
using teahouse.Dtos.Auth;
using teahouse.Dtos.Tea;
using teahouse.Models;

namespace teahouse.Services.AuthService {
    public class AuthService : IAuthService {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AuthService(IMapper mapper, DataContext context) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetUserDto>> Register(RegisterDto user) {
            try {
                var findUserByUsername = await _context.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync();

                if(findUserByUsername != null) {
                    return new ServiceResponse<GetUserDto>(Message: ServiceResponseEnum.DataAlreadyExist);
                }

                User newUser = _mapper.Map<User>(user);
                var passwordHasher = new PasswordHasher<User>();
                newUser.Password = passwordHasher.HashPassword(newUser, user.Password);
                await _context.Users.AddAsync(newUser);
                _context.SaveChanges();
                return new ServiceResponse<GetUserDto>(Data: _mapper.Map<GetUserDto>(newUser));
            } catch (System.Exception) {
                return new ServiceResponse<GetUserDto>(Message: ServiceResponseEnum.Error);
            }
        }

        public async Task<ServiceResponse<GetUserDto>> Login(LoginDto userCredentials) {
            try {
                var user = await _context.Users.Where(u => u.Username == userCredentials.Username).FirstOrDefaultAsync();
                if(user == null) {
                    return new ServiceResponse<GetUserDto>(Message: ServiceResponseEnum.DataNotFound);
                }

                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, userCredentials.Password);

                if (result != PasswordVerificationResult.Success) {
                    return new ServiceResponse<GetUserDto>(Message: ServiceResponseEnum.InvalidInput);
                }

                return new ServiceResponse<GetUserDto>(Data: _mapper.Map<GetUserDto>(user));
            } catch (System.Exception) {
                return new ServiceResponse<GetUserDto>(Message: ServiceResponseEnum.Error);
            }
        }
    }
}