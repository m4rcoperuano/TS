using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.IServices;
using WebMatrix.WebData;
using Domain.ViewModels;
using Timesheet.Core;
using Timesheet.Core.Interfaces;

namespace Timesheet.Services
{
    public class Membership : IMembership
    {
        private IRepository Repository;

        public Membership(IRepository repository)
        {
            this.Repository = repository;
        }

        public bool CreateAccount(string email, string password, object propertyValues, bool confirm)
        {
            WebSecurity.CreateUserAndAccount(email, password, propertyValues, confirm);
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            return WebSecurity.Login(username, password);
        }

        public bool ConfirmAccount(string confirmationToken)
        {
            return WebSecurity.ConfirmAccount(confirmationToken);
        }

        public bool LogoutUser()
        {
            WebSecurity.Logout();
            return true;
        }

        public int UserId()
        {
            return WebSecurity.CurrentUserId;
        }

        public int CompanyLocationId()
        {
            int userId = this.UserId();
            return this.Repository.Single<UserProfile>(x=>x.UserId == userId).fk_company_location;
        }
    }
}