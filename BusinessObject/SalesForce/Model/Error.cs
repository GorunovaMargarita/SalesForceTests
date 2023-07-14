using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class Error
    {
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public ICollection<string> Fields { get; set; }
    }
}
