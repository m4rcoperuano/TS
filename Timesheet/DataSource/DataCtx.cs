using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public static class DataCtx
    {
        public static TimesheetEntities GetDb()
        {
            return new TimesheetEntities();
        }
    }
}
