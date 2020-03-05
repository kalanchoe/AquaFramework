using System;

namespace AquaFramework
{
    public interface IBindableProperty<T>
    {
        T Value { get; set; }

        event Action<T> ValueChanged;
    }
}
