using DataAccessLayer;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Interfaces;
using Timesheet.Core.Services;
using Timesheet.Core;
using Timesheet.Core.Interfaces;

namespace Timesheet.Core
{
    public static class DataCtx
    {
        public static TimesheetEntities GetDb()
        {
            return new TimesheetEntities();
        }

        public static void RegisterDataAccessLayerTypes(IUnityContainer container)
        {
            container.RegisterType<IRepository, Repository>();
        }
    }
}
