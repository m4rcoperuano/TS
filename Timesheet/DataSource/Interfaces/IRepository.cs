using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesheet.Core.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Modify<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        T Single<T>(Func<T, bool> predicate) where T : class;

        IEnumerable<T> Many<T>(Func<T, bool> predicate) where T : class;
        void NewContext();
        void CommitAndDispose();
        void Dispose();
    }
}
