using Application.ViewModels.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterUser(RegisterDTO registerDTO);
        Task<LoginResponse> Login(LoginDTO loginDTO);
    }
}
