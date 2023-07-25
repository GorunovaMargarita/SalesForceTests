using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.API
{
    public class BaseService
    {
        protected BaseClient apiClient;

        public BaseService(string url)
        {
            this.apiClient = new BaseClient(url);
        }
    }
}
