using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IServices;
using Domain.Models;
using DataSource;
using AutoMapper;

namespace Domain.Services
{
    public class AccountServices : IAccountServices
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public LoginModel GetLoginModel()
        {
            return new LoginModel();
        }

        public RegisterModel GetRegisterModel()
        {
            return new RegisterModel();
        }

        public bool RegisterUser(RegisterModel registerModel)
        {            
            using (var db = DataCtx.GetDb())
            {
                UserProfile userProfile = db.UserProfiles.SingleOrDefault(x => x.UserName == registerModel.Email);
                if (userProfile != null)
                {
                    this.Success = false;
                    this.Message = "Error. This user already exists";
                    return false;
                }
                
                userProfile = Mapper.Map<RegisterModel, UserProfile>(registerModel);
                userProfile.UserName = registerModel.Email;

                return true;
            }
        }

        public bool LoginUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
