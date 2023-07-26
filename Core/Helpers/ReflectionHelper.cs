using System.Reflection;


namespace Core.Helpers
{
    public class ReflectionHelper
    {
        /// <summary> 
        /// Get property names
        /// </summary> 
        /// <param name="_object">Object</param> 
        /// <returns>Collection of property names</returns> 
        public static IEnumerable<string> GetPropertyNames(object _object)
        {
            return _object.GetType().BaseType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Concat(
                            _object.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)).Select(r => r.Name.ToLower());
        }

        /// <summary> 
        /// Get property value
        /// </summary> 
        /// <param name="_object">Object</param> 
        /// <param name="propertyName">Property name</param> 
        /// <returns></returns> 
        public static object GetPropertyValue(string propertyName, object _object)
        {
            return GetProperties(_object)
                                    .FirstOrDefault(p => p.Name.ToLower().Equals(propertyName.ToLower()))
                                    ?.GetValue(_object);
        }

        /// <summary> 
        /// Get collection PropertyInfo
        /// </summary> 
        /// <param name="_object">Object</param> 
        /// <returns>Collection of PropertyInfo</returns> 
        public static IEnumerable<PropertyInfo> GetProperties(object _object)
        {
            return _object.GetType().BaseType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Concat(
                            _object.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)).ToList();
        }
    }
}
