using AquaFramework.Exceptions;
using UnityEngine.UI;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForToggle<T> : IBindingHelper
    {
        Toggle _toggle;
        string _source;
        IBindableProperty<T> _target;
        Model _model;

        public BindingHelperForToggle(Toggle toggle, string source, IBindableProperty<T> target, Model model)
        {
            _toggle = toggle;
            _source = source;
            _target = target;
            _model = model;
            switch (source)
            {
                case nameof(toggle.isOn):
                    if (model == Model.OneTime)
                    {
                        toggle.isOn = BindingConverter.ConvertToConcreteType<bool>(target.Value);
                    }
                    else if (model == Model.OneWay)
                    {
                        toggle.isOn = BindingConverter.ConvertToConcreteType<bool>(target.Value);
                        target.ValueChanged += IsOnChangedOneWay;
                    }
                    else if (model == Model.TowWay)
                    {
                        toggle.isOn = BindingConverter.ConvertToConcreteType<bool>(target.Value);
                        target.ValueChanged += IsOnChangedOneWay;
                        toggle.onValueChanged.AddListener(IsOnChangedTowWay);
                    }
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        public void UnBind()
        {
            if (_source == nameof(_toggle.isOn) && _model == Model.OneWay)
            {
                _target.ValueChanged -= IsOnChangedOneWay;
                _target = null;
                _toggle = null;
            }
            if (_source == nameof(_toggle.isOn) && _model == Model.TowWay)
            {
                _target.ValueChanged -= IsOnChangedOneWay;
                _toggle.onValueChanged.RemoveListener(IsOnChangedTowWay);
                _toggle = null;
                _target = null;
            }
        }

        void IsOnChangedOneWay(T value)
        {
            _toggle.isOn = BindingConverter.ConvertToConcreteType<bool>(value);
        }

        void IsOnChangedTowWay(bool value)
        {
            _target.Value = BindingConverter.ConvertToGenericType<T, bool>(value);
        }
    }
}
