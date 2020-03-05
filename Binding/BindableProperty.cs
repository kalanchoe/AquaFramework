using System;

namespace AquaFramework.Binding
{
    public class BindableProperty<T> : IBindableProperty<T>
    {
        public event Action<T> ValueChanged;

        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!Equals(_value, value))
                {
                    _value = value;
                    ValueChanged?.Invoke(value);
                }
            }
        }
    }
}
