using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.IServices;
using Domain.ViewModels;
using DataSource;
using System.Web.Mvc;
using Domain.Models;
using WebMatrix.WebData;

namespace Timesheet.Services
{
    public class ClientService : IClientServices
    {
        public ClientProfileVM NewClient(int companyLocationId)
        {
            using (var db = DataCtx.GetDb())
            {
                ClientProfileVM clientProfileVM = new ClientProfileVM();
                clientProfileVM.StatesSL = new SelectList(this.GetStateSLI(), "Value", "Text");
                clientProfileVM.ClientProfileM = new ClientProfileModel();
                clientProfileVM.ClientProfileM.CompanyLocationId = companyLocationId;

                return clientProfileVM;
            }
        }

        private IEnumerable<SelectListItem> GetStateSLI()
        {
            using (var db = DataCtx.GetDb())
            {
                return db.States.ToList()
                    .Select(x => 
                        new SelectListItem() { 
                            Text = x.state_abbrev.ToUpper(), 
                            Value = x.id_state.ToString() 
                        });
            }
        }

        public int GetUserCompanyLocationId()
        {
            using (var db = DataCtx.GetDb())
            {
                UserProfile user = db.UserProfiles.Find(WebSecurity.CurrentUserId);
                if (user != null)
                {
                    return user.fk_company_location;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}