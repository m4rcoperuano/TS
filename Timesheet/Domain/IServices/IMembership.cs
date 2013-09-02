﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IMembership
    {
        bool CreateAccount(string email, string password, object propertyValues, bool confirm);
        bool LoginUser(string username, string password);
        bool ConfirmAccount(string confirmationToken);
        bool LogoutUser();
    }
}
