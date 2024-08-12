using Application.Contracts;
using Application.ViewModels.AuthModel;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository
{
    internal class UserRepo : IUser
    {
        private readonly MyDbContext myDbContext;
        private readonly IConfiguration configuration;

        public UserRepo(MyDbContext myDbContext,IConfiguration configuration) 
        {
            this.myDbContext = myDbContext;
            this.configuration = configuration;
        }
        public async Task<LoginResponse> Login(LoginDTO loginDTO)
        {
            var user = await FindUserByEmail(loginDTO.Email!);
            if (user == null)
            {
                return new LoginResponse(false, "User not found");

            }
            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash);
            if (checkPassword)
            {
                return new LoginResponse(true, "Login Successfully", GenerateJWTToken(user));
            }else
            {
                return new LoginResponse(false, "Invalid credentials");
            }
        }

        private string? GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var cendentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
            var token = new JwtSecurityToken(
                issuer : configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddDays(1),
                claims : userClaims,
                signingCredentials: cendentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegisterResponse> RegisterUser(RegisterDTO registerDTO)
        {
            var user = await FindUserByEmail(registerDTO.Email!);
            if (user != null) 
            {
                return new RegisterResponse(false, "Email already exists");
            }
            myDbContext.Add(new User()
            {
                /*Name = registerDTO.Name,
                Email = registerDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),*/

            });
            await myDbContext.SaveChangesAsync();
            return new RegisterResponse(true,"Register Successfully");
        }

        private async Task<User> FindUserByEmail(string email) =>
            await myDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
