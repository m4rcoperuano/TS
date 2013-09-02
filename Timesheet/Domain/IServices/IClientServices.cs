using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.ViewModels;

namespace Domain.IServices
{
    public interface IClientServices
    {
        ClientProfileVM NewClient(int companyLocationId);
        int GetUserCompanyLocationId();
    }
}
