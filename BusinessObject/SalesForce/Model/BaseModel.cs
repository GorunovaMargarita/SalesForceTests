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
            var stringBuilder = new StringBuilder();
            var propertyNames = ReflectionHelper.GetPropertyNames(this);
            foreach (var property in propertyNames)
            {
                stringBuilder.Append(property);
                stringBuilder.Append(": ");
                stringBuilder.Append(ReflectionHelper.GetPropertyValue(property, this));
                stringBuilder.Append(System.Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
    }
}
