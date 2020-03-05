using AquaFramework.Exceptions;
using TMPro;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForTMP_InputField<T> : IBindingHelper
    {
        IBindableProperty<T> _target;
        Model _model;
        TMP_InputField _inputField;
        string _source;

        public BindingHelperForTMP_InputField(TMP_InputField inputField, string source, IBindableProperty<T> target, Model model)
        {
            _inputField = inputField;
            _source = source;
            _target = target;
            _model = model;
            switch (source)
            {
                case nameof(inputField.text):
                    if (model == Model.OneTime)
                    {
                        inputField.text = BindingConverter.ConvertToConcreteType<string>(target.Value);
                    }
                    else if (model == Model.OneWay)
                    {
                        inputField.text = BindingConverter.ConvertToConcreteType<string>(target.Value);
                        target.ValueChanged += TextChangedOneWay;
                    }
                    else if (model == Model.TowWay)
                    {
                        inputField.text = BindingConverter.ConvertToConcreteType<string>(target.Value);
                        target.ValueChanged += TextChangedOneWay;
                        inputField.onValueChanged.AddListener(TextChangedTowWay);
                    }
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        public void UnBind()
        {
            if (_source == nameof(_inputField.text) && _model == Model.OneWay)
            {
                _target.ValueChanged -= TextChangedOneWay;
                _inputField = null;
                _target = null;
            }
            if (_source == nameof(_inputField.text) && _model == Model.TowWay)
            {
                _target.ValueChanged -= TextChangedOneWay;
                _inputField.onValueChanged.RemoveListener(TextChangedTowWay);
                _inputField = null;
                _target = null;
            }
        }

        void TextChangedOneWay(T value)
        {
            _inputField.text = BindingConverter.ConvertToConcreteType<string>(value);
        }

        void TextChangedTowWay(string value)
        {
            _target.Value = BindingConverter.ConvertToGenericType<T, string>(value);
        }
    }
}
