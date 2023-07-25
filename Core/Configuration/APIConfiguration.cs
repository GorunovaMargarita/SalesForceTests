using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class APIConfiguration : IConfiguration
    {
        public string SectionName => "Api";
        public string BaseUrl { get; set; }
        public string Token { get; set; }
    }
}
