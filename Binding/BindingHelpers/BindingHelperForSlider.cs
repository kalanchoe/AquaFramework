using AquaFramework.Exceptions;
using UnityEngine.UI;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForSlider<T> : IBindingHelper
    {
        Slider _slider;
        string _source;
        IBindableProperty<T> _target;
        Model _model;

        public BindingHelperForSlider(Slider slider, string source, IBindableProperty<T> target, Model model)
        {
            _slider = slider;
            _source = source;
            _target = target;
            _model = model;

            switch (source)
            {
                case nameof(slider.value):
                    if (model == Model.OneTime)
                    {
                        slider.value = BindingConverter.ConvertToConcreteType<float>(target.Value);
                    }
                    else if (model == Model.OneWay)
                    {
                        slider.value = BindingConverter.ConvertToConcreteType<float>(target.Value);
                        target.ValueChanged += ValueChangedOneWay;
                    }
                    else if (model == Model.TowWay)
                    {
                        slider.value = BindingConverter.ConvertToConcreteType<float>(target.Value);
                        target.ValueChanged += ValueChangedOneWay;
                        slider.onValueChanged.AddListener(ValueChangedTowWay);
                    }
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        public void UnBind()
        {
            if (_source == nameof(_slider.value) && _model == Model.OneWay)
            {
                _target.ValueChanged -= ValueChangedOneWay;
                _slider = null;
                _target = null;
            }
            if (_source == nameof(_slider.value) && _model == Model.TowWay)
            {
                _target.ValueChanged -= ValueChangedOneWay;
                _slider.onValueChanged.RemoveListener(ValueChangedTowWay);
                _slider = null;
                _target = null;
            }
        }

        void ValueChangedOneWay(T value)
        {
            _slider.value = BindingConverter.ConvertToConcreteType<float>(value);
        }

        void ValueChangedTowWay(float value)
        {
            _target.Value = BindingConverter.ConvertToGenericType<T, float>(value);
        }
    }
}
