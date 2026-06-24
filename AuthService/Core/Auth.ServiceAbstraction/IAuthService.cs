using Auth.Shared.DTOS.Auth;
using Auth.Shared.DTOS.OTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.ServiceAbstraction
{
    public  interface IAuthService
    {
        Task<OTPResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<OTPResponse> LoginAsync(LoginRequest loginRequest);
        Task<UserResponse> VerifyOTPAsync(VerifyOTPRequest verifyOTPRequest);
        Task LogoutAsync(string refreshToken);

    }
}
