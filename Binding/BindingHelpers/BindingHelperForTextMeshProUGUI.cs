using AquaFramework.Exceptions;
using TMPro;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForTextMeshProUGUI<T> : IBindingHelper
    {
        TextMeshProUGUI _text;
        string _source;
        IBindableProperty<T> _target;
        Model _model;

        public BindingHelperForTextMeshProUGUI(TextMeshProUGUI text, string source, IBindableProperty<T> target, Model model)
        {
            _text = text;
            _source = source;
            _target = target;
            _model = model;
            switch (source)
            {
                case nameof(text.text):
                    if (model == Model.OneTime)
                    {
                        text.text = BindingConverter.ConvertToConcreteType<string>(target.Value.ToString());
                    }
                    else if (model == Model.OneWay)
                    {
                        text.text = BindingConverter.ConvertToConcreteType<string>(target.Value.ToString());
                        target.ValueChanged += TextChangedOneWay;
                    }
                    else if (model == Model.TowWay) throw new AquaFrameworkException("Do not support tow way binding for " + nameof(text.text) + ".");
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        public void UnBind()
        {
            if (_source == nameof(_text.text) && _model == Model.OneWay)
            {
                _target.ValueChanged -= TextChangedOneWay;
                _target = null;
                _text = null;
            }
        }

        void TextChangedOneWay(T value)
        {
            _text.text = BindingConverter.ConvertToConcreteType<string>(value.ToString());
        }
    }
}
