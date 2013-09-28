using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Timesheet.Tests.Services
{
    public class FakeMembership : IMembership
    {
        public bool CreateAccount(string email, string password, object propertyValues, bool confirm)
        {
            return true;
        }

        public bool LoginUser(string username, string password)
        {
            return true;
        }

        public bool ConfirmAccount(string confirmationToken)
        {
            return true;
        }

        public int UserId()
        {
            return 1;
        }

        public bool LogoutUser()
        {
            return true;
        }


        public int CompanyLocationId()
        {
            throw new NotImplementedException();
        }
    }
}
