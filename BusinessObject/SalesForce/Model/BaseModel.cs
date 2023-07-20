using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.SalesForce.Model
{
    public class BaseModel
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var propertyNames = ReflectionHelper.GetPropertyNames(this);
            foreach (var property in propertyNames)
            {
                sb.Append(property);
                sb.Append(": ");
                sb.Append(ReflectionHelper.GetPropertyValue(property, this));
                sb.Append(System.Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
