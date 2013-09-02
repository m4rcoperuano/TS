using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IServices;
using Domain.Models;
using DataSource;
using AutoMapper;
using WebMatrix.WebData;
using Domain;

namespace Timesheet.Services
{
    public class AccountServices : IAccountServices
    {
        private IMembership MembershipProvider { get; set; }
        public AccountServices(IMembership ms)
        {
            MembershipProvider = ms;
        }

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
                    this.Message = "Sorry, this username already exists. Please select another username.";
                    return false;
                }

                Company company = new Company();
                company.Name = registerModel.CompanyName;

                CompanyLocation companyLocation = new CompanyLocation();
                companyLocation.CompanyLocation1 = "Primary";

                company.CompanyLocations.Add(companyLocation);
                db.Companies.Add(company);

                db.SaveChanges();

                MembershipProvider.CreateAccount(registerModel.Email, registerModel.Password, new
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    created_on = DateTime.Now,
                    updated_on = DateTime.Now,
                    fk_company_location = companyLocation.id_company_locations
                }, true);

                         
                
                return true;
            }
        }
        public bool LoginUser(LoginModel loginModel)
        {
            if (MembershipProvider.LoginUser(loginModel.Email, loginModel.Password))
            {
                return true;
            }
            else
            {
                this.Success = false;
                this.Message = "Sorry, we could not validate your credentials.";
                return false;
            }
        }
        public void LogoutUser()
        {
            this.MembershipProvider.LogoutUser();
        }
        public bool ConfirmUser(string confirmationToken)
        {
            if (MembershipProvider.ConfirmAccount(confirmationToken))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
