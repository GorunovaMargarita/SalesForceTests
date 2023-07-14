using BusinessObject.SalesForce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce
{
    public class ContactBuilder
    {
        public static Contact DefaultContact() => new Contact() { Id = "003Hr00002QoOs9IAF", AccountName = "Thompson", LastName = "Thompson" };
    }
}
