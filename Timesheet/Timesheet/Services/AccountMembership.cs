using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.IServices;
using WebMatrix.WebData;

namespace Timesheet.Services
{
    public class AccountMembership : IMembership
    {
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
    }
}