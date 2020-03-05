using System;

namespace AquaFramework.Binding
{
    static class BindingConverter
    {
        public static T ConvertToConcreteType<T>(object value)
        {
            try
            {
                object temp = value;
                return (T)Convert.ChangeType(value , typeof(T));
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        public static T0 ConvertToGenericType<T0, T1>(T1 value)
        {
            if (typeof(T0) == typeof(T1))
            {
                return (T0)(object)value;
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
