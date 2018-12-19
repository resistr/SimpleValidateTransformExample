using System;
using System.Reflection;

namespace Framework
{
    public static class TypeExtensions
    {
        public static bool TryGetPropertyValue(this object source, string propertyName, out object value)
        {
            if (!source.TryGetProperty(propertyName, out PropertyInfo propertyInfo))
            {
                value = null;
                return false;
            }
            return source.TryGetPropertyValue(propertyInfo, out value);
        }

        public static bool TryGetPropertyValue(this object source, PropertyInfo propertyInfo, out object value)
        {
            try
            {
                value = propertyInfo.GetValue(source);
                return true;
            }
            catch (Exception)
            {
                // NullReferenceException
                // GetValue exceptions?

                value = null;
                return false;
            }
        }

        public static bool TrySetPropertyValue(this object source, PropertyInfo propertyInfo, object value)
        {
            try
            {
                propertyInfo.SetValue(source, value);
                return true;
            }
            catch (Exception)
            {
                // NullReferenceException
                // SetValue exceptions?
                return false;
            }
        }

        public static bool TryGetProperty(this object source, string propertyName, out PropertyInfo propertyInfo)
        {
            try
            {
                propertyInfo = source.GetType().GetProperty(propertyName);
                return true;
            }
            catch (Exception)
            {
                // NullReferenceException
                // GetValue exceptions?
                //   T:System.Reflection.AmbiguousMatchException:
                //   T:System.ArgumentNullException:

                propertyInfo = null;
                return false;
            }
        }

        public static bool TryChangeType<TDest>(this object source, out TDest value)
        {
            try
            {
                value = (TDest)Convert.ChangeType(source, typeof(TDest));
                return true;
            }
            catch (Exception)
            {
                value = default;
                return false;
            }
        }

    }
}
