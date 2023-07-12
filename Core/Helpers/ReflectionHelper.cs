using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class ReflectionHelper
    {
        /// <summary> 
        /// Получаем список имен свойств 
        /// </summary> 
        /// <param name="currentObject"></param> 
        /// <returns></returns> 
        public static IEnumerable<string> GetPropertyNames(object currentObject)
        {
            return currentObject.GetType().BaseType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Concat(
                            currentObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)).Select(r => r.Name.ToLower());
        }

        /// <summary> 
        /// Получаем значение свойства объекта 
        /// </summary> 
        /// <param name="_object">объект</param> 
        /// <param name="attributeName">название свойства</param> 
        /// <returns></returns> 
        public static object GetPropertyValue(string attributeName, object _object)
        {
            return ReflectionHelper.GetProperties(_object)
                                    .FirstOrDefault(p => p.Name.ToLower().Equals(attributeName.ToLower()))
                                    ?.GetValue(_object);
        }

        /// <summary> 
        /// Получаем список свойств 
        /// </summary> 
        /// <param name="currentObject"></param> 
        /// <returns></returns> 
        public static IEnumerable<PropertyInfo> GetProperties(object currentObject)
        {
            return currentObject.GetType().BaseType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Concat(
                            currentObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)).ToList();
        }
    }
}
