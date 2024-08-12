using Application.Contracts;
using Application.Services;
using Application.ViewModels.AuthModel;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceImplements
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<LoginResponse> Login(LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginDTO.Email, loginDTO.Password, false, false);
            if (result.Succeeded)
            {
                return new LoginResponse(true, "Login Successfully", GenerateJWTToken(user));
            }
            else
            {
                return new LoginResponse(false, "Invalid credentials");
            }

            throw new NotImplementedException();
        }

        public Task<RegisterResponse> RegisterUser(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
