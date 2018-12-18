using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Reponsitories;
using TeduShop.Model.Model;

namespace TeduShop.Service.Error
{
    public class LogErrorService : ILogError
    {
        ILogErrorRepository _logError;
        IUnitOfWork _unitOfWork;
        public LogErrorService(ILogErrorRepository logError, IUnitOfWork unitOfWork)
        {
            _logError = logError;
            _unitOfWork = unitOfWork;
        }
        public LogError Create(LogError err)
        {
            return _logError.Add(err);
        }

        public void Save()
        {
            _unitOfWork.Commit();

        }
    }
}
