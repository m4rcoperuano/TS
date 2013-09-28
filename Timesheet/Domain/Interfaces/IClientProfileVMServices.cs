using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ViewModels;

namespace Domain.IServices
{
    public interface IClientProfileVMServices
    {
        ClientProfileViewModel NewClient(int companyLocationId);
        bool SaveNewClient(ClientProfileModel clientProfileModel);
        bool SaveClientEdits(ClientProfileModel clientProfileModel);

        List<ClientProfileModel> GetClients(int companyLocationId);
        ClientProfileViewModel GetClient(int clientId);

        bool ArchiveClient(int clientId);
        bool UnarchiveClient(int clientId);
    }
}
