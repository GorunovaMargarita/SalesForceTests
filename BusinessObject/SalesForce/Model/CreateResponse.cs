using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class CreateResponse : BaseModel
    {
        public string? Id { get; set; }
        public bool? Success { get; set; }
        public ICollection<Error>? Errors { get; set; }

    }
}
