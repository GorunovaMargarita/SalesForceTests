using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class CommonResponse<T> : BaseModel
    {
        public string StatusCode { get; set; }
        public T? Data { get; set; }
        public ICollection<Error>? Errors { get; set; }
    }
}
