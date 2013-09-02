using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.IServices
{
    public interface IAccountServices
    {
        bool Success { get; set; }
        string Message { get; set; }

        LoginModel GetLoginModel();
        RegisterModel GetRegisterModel();
        bool RegisterUser(RegisterModel registerModel);
        bool LoginUser(LoginModel loginModel);
        bool ConfirmUser(string confirmationToken);
        void LogoutUser();
    }
}
