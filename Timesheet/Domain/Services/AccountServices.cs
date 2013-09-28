using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.IServices;
using Domain.ViewModels;
using DataAccessLayer;
using AutoMapper;
using WebMatrix.WebData;
using Domain;
using Timesheet.Core.Interfaces;
using Timesheet.Core;

namespace Domain.Services
{
    public class AccountServices : IAccountServices
    {
        private IMembership MembershipProvider { get; set; }
        private IRepository Repository { get; set; }

        public AccountServices(IMembership ms, IRepository repo)
        {
            this.MembershipProvider = ms;
            this.Repository = repo;
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
            string email = registerModel.Email;
            if (this.Repository.Single<UserProfile>(x=>x.UserName == email) != null)
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

            this.Repository.Add(company);
            this.Repository.CommitAndDispose();       

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
