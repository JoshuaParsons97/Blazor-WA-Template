using BlazorTemplate.Client.Pages.Account;
using BlazorTemplate.Shared.DTOs.Account;
using static System.Net.WebRequestMethods;

namespace BlazorTemplate.Client.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _http;

        public AccountService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<string>> Login(LoginDTO login)
        {
            var result = await _http.PostAsJsonAsync("api/Account/login", login);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> Register(RegisterDTO register)
        {
            var result = await _http.PostAsJsonAsync("api/Account/register", register);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(ChangePasswordDTO changePassword)
        {
            ServiceResponse<bool> Result = new ServiceResponse<bool>();
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Account/ChangePassword", changePassword);
                Result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            }
            catch
            {
                Result.Success = false;
                Result.Message = "Something went wrong";
            }

            return Result;
        }

        public async Task<ServiceResponse<bool>> RecoverPassword(PasswordRecoveryDTO passwordRecovery)
        {
            ServiceResponse<bool> Result = new ServiceResponse<bool>();
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Account/RecoverPassword", passwordRecovery);
                Result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            }
            catch
            {
                Result.Success = false;
                Result.Message = "Something went wrong";
            }

            return Result;
        }

        public async Task<ServiceResponse<bool>> ResetPassword(ResetPasswordDTO resetPassword)
        {
            ServiceResponse<bool> Result = new ServiceResponse<bool>();
            try
            {
                var response = await _http.PostAsJsonAsync($"api/Account/ResetPassword", resetPassword);
                Result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            }
            catch
            {
                Result.Success = false;
                Result.Message = "Something went wrong";
            }

            return Result;
        }
    }
}
