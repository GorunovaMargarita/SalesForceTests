using Core.Helpers;
using System.Text;


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
