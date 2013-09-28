using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.IServices;
using Domain.ViewModels;
using DataAccessLayer;
using System.Web.Mvc;
using WebMatrix.WebData;
using Timesheet.Core.Interfaces;
using AutoMapper;
using Timesheet.Core;
using Timesheet.Core.Interfaces;

namespace Domain.Services
{
    public class ClientProfileVMService : IClientProfileVMServices
    {
        private IRepository Repository;
        public ClientProfileVMService(IRepository repo)
        {
            this.Repository = repo;

            Mapper.CreateMap<ClientProfileModel, ClientProfile>();
            Mapper.CreateMap<ClientProfile, ClientProfileModel>();
        }

        public ClientProfileViewModel NewClient(int companyLocationId)
        {
            //build
            ClientProfileViewModel clientProfileVM = new ClientProfileViewModel();
            clientProfileVM.StatesSL = new SelectList(this.GetStateSLI(), "Value", "Text");
            clientProfileVM.ClientProfileM = new ClientProfileModel();
            clientProfileVM.ClientProfileM.CompanyLocationId = companyLocationId;

            return clientProfileVM;
        }

        public bool SaveNewClient(ClientProfileModel clientProfileModel)
        {
            //build
            ClientProfile clientProfile = Mapper.Map<ClientProfile>(clientProfileModel);
            clientProfile.fk_company_location = clientProfileModel.CompanyLocationId;
            clientProfile.fk_state = clientProfileModel.StateId;
            clientProfile.created_at = DateTime.Now;
            clientProfile.updated_at = DateTime.Now;
            clientProfile.FillInNulls();

            //save
            this.Repository.Add(clientProfile);
            this.Repository.CommitAndDispose();
            return true;
        }

        public List<ClientProfileModel> GetClients(int companyLocationId)
        {
            List<ClientProfile> listClientProfiles = this.Repository.Many<ClientProfile>(x=>true).ToList();
            List<ClientProfileModel> listClientProfileVMs = new List<ClientProfileModel>();

            foreach (var clientProfile in listClientProfiles)
            {
                ClientProfileModel clientProfileModel = Mapper.Map<ClientProfileModel>(clientProfile);
                clientProfileModel.ClientName = clientProfile.client_name;
                clientProfileModel.ClientId = clientProfile.id_client;
                clientProfileModel.Deleted = clientProfile.deleted_on != null;

                listClientProfileVMs.Add(clientProfileModel);
            }

            return listClientProfileVMs;
        }

        public ClientProfileViewModel GetClient(int clientId)
        {
            ClientProfile clientProfile = this.Repository.Single<ClientProfile>(x=>x.id_client == clientId);
            if (clientProfile == null)
            {
                return null;
            }
            ClientProfileModel clientProfileModel = Mapper.Map<ClientProfileModel>(clientProfile);
            clientProfileModel.ClientName = clientProfile.client_name;
            clientProfileModel.ClientId = clientProfile.id_client;
            clientProfileModel.CompanyLocationId = clientProfile.fk_company_location;
            clientProfileModel.StateId = clientProfile.fk_state;
            clientProfileModel.Zip4 = clientProfile.zip_4;
            clientProfileModel.Deleted = clientProfile.deleted_on != null;

            ClientProfileViewModel clientProfileVM = new ClientProfileViewModel();
            clientProfileVM.ClientProfileM = clientProfileModel;
            clientProfileVM.StatesSL = new SelectList(this.GetStateSLI(), "Value", "Text");

            return clientProfileVM;
        }


        public bool SaveClientEdits(ClientProfileModel clientProfileModel)
        {
            ClientProfile existingClient = this.Repository.Single<ClientProfile>(x=>x.id_client == (int)clientProfileModel.ClientId);
            this.Repository.Dispose();

            ClientProfile clientProfile = Mapper.Map<ClientProfile>(clientProfileModel);

            //properties that dont change
            clientProfile.created_at = existingClient.created_at;
            clientProfile.id_client = existingClient.id_client;
            clientProfile.deleted_on = existingClient.deleted_on;

            clientProfile.client_name = clientProfileModel.ClientName;
            clientProfile.fk_state = clientProfileModel.StateId;
            clientProfile.zip_4 = clientProfileModel.Zip4;
            clientProfile.fk_company_location = clientProfileModel.CompanyLocationId;
            clientProfile.updated_at = DateTime.Now;

            clientProfile.FillInNulls();

            this.Repository.NewContext();
            this.Repository.Modify(clientProfile);
            this.Repository.CommitAndDispose();
            return true;
        }

        private List<SelectListItem> GetStateSLI()
        {
            return this.Repository.Many<State>(x=>true)
                .Select(x =>
                    new SelectListItem()
                    {
                        Text = x.state_abbrev.ToUpper(),
                        Value = x.id_state.ToString()
                    }).ToList();
        }

        public bool ArchiveClient(int clientId)
        {
            ClientProfile existingClient = this.Repository.Single<ClientProfile>(x=>x.id_client == clientId);
            existingClient.deleted_on = DateTime.Now;
            this.Repository.Modify(existingClient);
            this.Repository.CommitAndDispose();
            return true;
        }


        public bool UnarchiveClient(int clientId)
        {
            ClientProfile existingClient = this.Repository.Single<ClientProfile>(x=>x.id_client == clientId);
            existingClient.deleted_on = null;
            this.Repository.Modify(existingClient);
            this.Repository.CommitAndDispose();
            return true;
        }
    }
}