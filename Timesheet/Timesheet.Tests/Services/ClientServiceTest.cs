using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.IServices;
using Timesheet.Services;
using System.Linq;

namespace Timesheet.Tests.Services
{
    [TestClass]
    public class ClientServiceTest
    {
        [TestMethod]
        public void NewClient()
        {
            IClientServices cs = new ClientService();
            var newClient = cs.NewClient(2);

            Assert.IsNotNull(newClient);
        }
    }
}
