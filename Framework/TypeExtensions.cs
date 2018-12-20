using System;
using System.Reflection;

namespace Framework
{
    /// <summary>
    /// Common extensions to System.Type.  
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Try to get a value from a property on an object by the property name.
        /// </summary>
        /// <param name="source">The object to attempt to get the value from.</param>
        /// <param name="propertyName">The name of the property to access to get the value from.</param>
        /// <param name="value">The value if successful.</param>
        /// <returns>True if able to obtain the value; otherwise false.</returns>
        public static bool TryGetPropertyValue(this object source, string propertyName, out object value)
        {
            // If we can't get the property info we can't try to get the value. 
            if (!source.TryGetProperty(propertyName, out PropertyInfo propertyInfo))
            {
                value = null;
                return false;
            }

            // defer to more specific attempt.
            return source.TryGetPropertyValue(propertyInfo, out value);
        }

        /// <summary>
        /// Try to get a value from a property on an object by the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="source">The object to attempt to get the value from.</param>
        /// <param name="propertyInfo">The PropertyInfo of the property to access to get the value from.</param>
        /// <param name="value">The value if successful.</param>
        /// <returns>True if able to obtain the value; otherwise false.</returns>
        public static bool TryGetPropertyValue(this object source, PropertyInfo propertyInfo, out object value)
        {
            try
            {
                // get the value from the object
                value = propertyInfo.GetValue(source);
                return true;
            }
            catch (Exception ex)
            when (

                // propertyInfo is null
                ex is NullReferenceException ||

                //   T:System.ArgumentException:
                //     The index array does not contain the type of arguments needed. -or- The property's
                //     get accessor is not found.
                ex is ArgumentException ||

                //   T:System.Reflection.TargetException:
                //     The object does not match the target type, or a property is an instance property
                //     but obj is null.
                ex is TargetException ||

                //   T:System.Reflection.TargetParameterCountException:
                //     The number of parameters in index does not match the number of parameters the
                //     indexed property takes.
                ex is TargetParameterCountException ||

                //   T:System.MethodAccessException:
                //     There was an illegal attempt to access a private or protected method inside a
                //     class.
                ex is MethodAccessException ||

                //   T:System.Reflection.TargetInvocationException:
                //     An error occurred while retrieving the property value. For example, an index
                //     value specified for an indexed property is out of range. The System.Exception.InnerException
                //     property indicates the reason for the error.
                ex is TargetInvocationException
            )
            {
                // TODO catch only expected exceptions 
                // NullReferenceException
                // GetValue exceptions? - Not well documented from MSFT

                // failure
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Try to set a value from a property on an object by the property name.
        /// </summary>
        /// <param name="source">The object to attempt to set the value to.</param>
        /// <param name="propertyName">The name of the property to access to set the value to.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>True if able to set the value; otherwise false.</returns>
        public static bool TrySetPropertyValue(this object source, string propertyName, object value)
        {
            // If we can't get the property info we can't try to get the value. 
            if (!source.TryGetProperty(propertyName, out PropertyInfo propertyInfo))
            {
                value = null;
                return false;
            }

            // defer to more specific attempt.
            return source.TrySetPropertyValue(propertyInfo, value);
        }

        /// <summary>
        /// Try to set a value to a property on an object by the <see cref="PropertyInfo"/>.
        /// </summary>
        /// <param name="source">The object to attempt to set the value to.</param>
        /// <param name="propertyInfo">The PropertyInfo of the property to access to set the value to.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>True if able to set the value; otherwise false.</returns>
        public static bool TrySetPropertyValue(this object source, PropertyInfo propertyInfo, object value)
        {
            try
            {
                // set the value to the object
                propertyInfo.SetValue(source, value);
                return true;
            }
            catch (Exception ex)
            when (
                // propertyInfo is null
                ex is NullReferenceException ||

                //   T:System.ArgumentException:
                //     The property's set accessor is not found. -or- value cannot be converted to the
                //     type of System.Reflection.PropertyInfo.PropertyType.
                ex is ArgumentException ||

                //   T:System.Reflection.TargetException:
                //     In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912)
                //     or the [Portable Class Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md),
                //     catch System.Exception instead. The type of obj does not match the target type,
                //     or a property is an instance property but obj is null.
                ex is TargetException ||

                //   T:System.MethodAccessException:
                //     In the [.NET for Windows Store apps](http://go.microsoft.com/fwlink/?LinkID=247912)
                //     or the [Portable Class Library](~/docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md),
                //     catch the base class exception, System.MemberAccessException, instead. There
                //     was an illegal attempt to access a private or protected method inside a class.
                ex is MethodAccessException ||

                //   T:System.Reflection.TargetInvocationException:
                //     An error occurred while setting the property value. The System.Exception.InnerException
                //     property indicates the reason for the error.
                ex is TargetInvocationException

            )
            {
                // TODO catch only expected exceptions 
                // NullReferenceException
                // SetValue exceptions? - Not well documented from MSFT

                // failure 
                return false;
            }
        }

        /// <summary>
        /// Try to get <see cref="PropertyInfo" /> from an object for a property by property name.
        /// </summary>
        /// <param name="source">The object to attempt to get the PropertyInfo from.</param>
        /// <param name="propertyName">The name of the property to access to get the PropertyInfo from.</param>
        /// <param name="propertyInfo">The PropertyInfo for the property if successful.</param>
        /// <returns>True if able to get the PropertyInfo; otherwise false.</returns>
        public static bool TryGetProperty(this object source, string propertyName, out PropertyInfo propertyInfo)
        {
            try
            {
                // get the PropertyInfo
                propertyInfo = source.GetType().GetProperty(propertyName);
                return true;
            }
            catch (Exception ex)
            when (
                // source is null or some how source.GetType() is null
                ex is NullReferenceException ||

                //   T:System.Reflection.AmbiguousMatchException:
                //     More than one property is found with the specified name.
                ex is AmbiguousMatchException ||

                //   T:System.ArgumentNullException:
                //     name is null.
                ex is ArgumentNullException
            )
            {
                // failure
                propertyInfo = null;
                return false;
            }
        }

        /// <summary>
        /// Try to change the type of an object using <see cref="Convert.ChangeType(object, Type)"/>.
        /// </summary>
        /// <typeparam name="TDest">The type of the object resulting from the conversion.</typeparam>
        /// <param name="source">The source object to convert.</param>
        /// <param name="value">The resulting object from the conversion.</param>
        /// <returns>True if conversion was sucessful; otherwise false.</returns>
        public static bool TryChangeType<TDest>(this object source, out TDest value)
        {
            try
            {
                // do the conversion
                value = (TDest)Convert.ChangeType(source, typeof(TDest));
                return true;
            }
            catch (Exception ex)
            when (
                //   T:System.InvalidCastException:
                //     This conversion is not supported. -or- value is null and conversionType is a
                //     value type. -or- value does not implement the System.IConvertible interface.
                ex is InvalidCastException ||

                //   T:System.FormatException:
                //     value is not in a format recognized by conversionType.
                ex is FormatException ||

                //   T:System.OverflowException:
                //     value represents a number that is out of the range of conversionType.
                ex is OverflowException ||

                //   T:System.ArgumentNullException:
                //     conversionType is null.
                ex is ArgumentNullException
            )
            {
                // failure
                value = default;
                return false;
            }
        }
    }
}
