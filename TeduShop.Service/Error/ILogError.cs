using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Model;

namespace TeduShop.Service.Error
{
    public interface ILogError
    {
        LogError Create(LogError err);
        void Save();
    }
}
