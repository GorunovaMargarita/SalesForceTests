using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.API
{
    public class CommonResultResponse
    {
        public bool Status { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class CommonResultResponse<T> : CommonResultResponse
    {
        public T? Result { get; set; }
    }
}
