using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Model;

namespace TeduShop.Data.Reponsitories
{
    public interface ILogErrorRepository : IReponsitory<LogError>
    {
    }
    public class LogErrorRepository : ReponsitoryBase<LogError>, ILogErrorRepository
    {
        public LogErrorRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
