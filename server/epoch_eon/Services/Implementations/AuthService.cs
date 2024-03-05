using Microsoft.IdentityModel.Tokens;
using Prueba.Models;
using Prueba.Models.DTOs.Auth;
using Prueba.Repositories;
using Prueba.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Prueba.Services.Implementations
{
    public class AuthService : IAuthService
    {

        private readonly ILogger<AuthService> _logger;
        private readonly IAdminUserRepository _repository;

        private readonly string _tokenSecret;

        public AuthService(ILogger<AuthService> logger, IAdminUserRepository repository, IConfiguration _configuration)
        {
            _logger = logger;
            _repository = repository;
            _tokenSecret = _configuration.GetValue<string>("JwtSettings:Key") ?? throw new ArgumentNullException("Jwt Token Signing key was not provided");
        }

        public AdminSessionDTO LogIn(LoginRequestDTO loginRequest)
        {
            var adminUser = _repository.GetByUsername(loginRequest.Username);
            if (adminUser == null)
            {
                throw new ArgumentException("invalid_credentials");
            }

            var password = EncriptPassword(loginRequest.Password);
            if (password != adminUser.Password)
            {
                throw new ArgumentException("invalid_credentials");
            }
            var token = GenerateJwtToken(adminUser);
            var session = new AdminSessionDTO { Username = adminUser.Username, Token = token };
            return session;
        }

        public void SignUp(SignupDataDTO signupData)
        {
            _logger.LogInformation(signupData.ToString());
            var existingUserByUsername = _repository.GetByUsername(signupData.Username);

            if (existingUserByUsername != null)
            {
                throw new ArgumentException("username_taken");
            }

            var existingUserByEmail = _repository.GetByEmail(signupData.Email);

            if (existingUserByEmail != null)
            {
                throw new ArgumentException("email_taken");
            }

            var encriptedPassword = EncriptPassword(signupData.Password);
            var adminUser = new AdminUser { Username = signupData.Username.ToLower(), Email = signupData.Email.ToLower(), Password = encriptedPassword, JoinedAt = DateTime.Now };
            _repository.Insert(adminUser);
        }

        private string EncriptPassword(string rawPassword)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(rawPassword));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        private string GenerateJwtToken(AdminUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSecret));
            var claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim("id", user.Id.ToString()),
            };
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
