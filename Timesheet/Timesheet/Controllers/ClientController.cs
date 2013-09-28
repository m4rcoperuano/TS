using Domain.Interfaces;
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
        private IClientProfileVMServices ClientProfileVMService;
        private IMembership MembershipService;
        private IUserModelService UserModelService;

        public ClientController(IClientProfileVMServices cs, IMembership ms, IUserModelService userModelService)
        {
            this.ClientProfileVMService = cs;
            this.MembershipService = ms;
            this.UserModelService = userModelService;
        }

        public ActionResult Create()
        {
            int userId = this.MembershipService.UserId();
            int companyId = this.UserModelService.GetUser(userId).CompanyId;

            ClientProfileViewModel clientModel = ClientProfileVMService.NewClient(companyId);
            return View(clientModel);
        }

        [HttpPost]
        public ActionResult Create(ClientProfileModel clientProfileM)
        {
            if (ModelState.IsValid)
            {
                this.ClientProfileVMService.SaveNewClient(clientProfileM);
                return RedirectToAction("Manage", new
                {
                    alertTitle = "Success",
                    alertType = "success",
                    alertMessage = "New Client Created"
                });
            }

            return View(clientProfileM);
        }

        public ActionResult Manage()
        {
            int userId = this.MembershipService.UserId();
            int companyId = this.UserModelService.GetUser(userId).CompanyId;

            List<ClientProfileModel> clientProfiles = this.ClientProfileVMService.GetClients(companyId);
            return View(clientProfiles);
        }

        public ActionResult Edit(int id)
        {
            ClientProfileViewModel clientProfileVM = this.ClientProfileVMService.GetClient(id);
            if (clientProfileVM == null)
            {
                return new HttpNotFoundResult();
            }
            return View(clientProfileVM);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Prefix = "ClientProfileM")]ClientProfileModel clientProfileModel, string buttonClicked)
        {
            string redirectAction = "Manage";
            string alertType = "";
            string alertMessage = "";
            bool redirect = false;

            //to archive
            if (buttonClicked == "Archive")
            {
                bool wasArchived = this.ClientProfileVMService.ArchiveClient((int)clientProfileModel.ClientId);
                if (wasArchived)
                {
                    redirect = true;
                    alertType = "success";
                    alertMessage = clientProfileModel.ClientName + " archived.";
                }
                else
                {
                    redirect = true;
                    alertType = "error";
                    alertMessage = clientProfileModel.ClientName + " could not be archived.";
                }
            }

            //to restore
            if (buttonClicked == "Unarchive")
            {
                bool wasUnarchived = this.ClientProfileVMService.UnarchiveClient((int)clientProfileModel.ClientId);
                if (wasUnarchived)
                {
                    redirect = true;
                    alertType = "success";
                    alertMessage = clientProfileModel.ClientName + " was restored.";
                }
                else {
                    redirect = true;
                    alertType = "error";
                    alertMessage = clientProfileModel.ClientName + " could not be restored";
                }
            }

            if (ModelState.IsValid && buttonClicked == "")
            {
                this.ClientProfileVMService.SaveClientEdits(clientProfileModel);
                redirect = true;
            }

            //--redirect
            if (redirect)
            {
                return RedirectToAction(redirectAction, new
                {
                    alertType = alertType,
                    alertMessage = alertMessage
                });
            }

            return View(clientProfileModel);
        }
    }
}
