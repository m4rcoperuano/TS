using Domain.IServices;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Timesheet.Controllers
{
    public class ClientController : Controller
    {
        private IClientServices service;
        public ClientController(IClientServices clientService)
        {
            service = clientService;
        }

        public ActionResult Create()
        {
            int userCompanyLocationId = service.GetUserCompanyLocationId();
            ClientProfileVM clientModel = service.NewClient(userCompanyLocationId);
            return View(clientModel);
        }

    }
}
