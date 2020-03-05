using System;
using AquaFramework.Exceptions;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForAction<T> : IBindingHelper
    {
        Action<T> _action;
        IBindableProperty<T> _target;

        public BindingHelperForAction(Action<T> action, IBindableProperty<T> target, Model model)
        {
            _action = action;
            _target = target;
            if (model == Model.OneTime) action?.Invoke(target.Value);
            else if (model == Model.OneWay)
            {
                action?.Invoke(target.Value);
                target.ValueChanged += action;
            }
            else if (model == Model.TowWay) throw new AquaFrameworkException("Do not support tow way binding for action.");
        }

        public void UnBind()
        {
            _target.ValueChanged -= _action;
            _action = null;
            _target = null;
        }
    }
}

