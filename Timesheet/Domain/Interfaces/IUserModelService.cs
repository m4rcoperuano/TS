using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Interfaces;
using Timesheet.Core;

namespace Domain.Interfaces
{
    public interface IUserModelService
    {
        UserModel GetUser(int userId);
    }
}
