using AquaFramework.Exceptions;
using UnityEngine;
using UnityEngine.UI;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForScrollRect<T> : IBindingHelper
    {
        ScrollRect _scrollRect;
        string _source;
        IBindableProperty<T> _target;
        Model _model;

        public BindingHelperForScrollRect(ScrollRect scrollRect, string source, IBindableProperty<T> target, Model model)
        {
            _scrollRect = scrollRect;
            _source = source;
            _target = target;
            _model = model;
            switch (source)
            {
                case nameof(scrollRect.normalizedPosition):
                    if (model == Model.OneTime)
                    {
                        scrollRect.normalizedPosition = BindingConverter.ConvertToConcreteType<Vector2>(target.Value);
                    }
                    else if (model == Model.OneWay)
                    {
                        scrollRect.normalizedPosition = BindingConverter.ConvertToConcreteType<Vector2>(target.Value);
                        target.ValueChanged += NormalizedPositionChangedOneWay;
                    }
                    else if (model == Model.TowWay)
                    {
                        scrollRect.normalizedPosition = BindingConverter.ConvertToConcreteType<Vector2>(target.Value);
                        target.ValueChanged += NormalizedPositionChangedOneWay;
                        scrollRect.onValueChanged.AddListener(NormalizedPositionChangedTowWay);
                    }
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        public void UnBind()
        {
            if (_source == nameof(_scrollRect.normalizedPosition) && _model == Model.OneWay)
            {
                _target.ValueChanged -= NormalizedPositionChangedOneWay;
                _target = null;
                _scrollRect = null;
            }
            if (_source == nameof(_scrollRect.normalizedPosition) && _model == Model.TowWay)
            {
                _target.ValueChanged -= NormalizedPositionChangedOneWay;
                _scrollRect.onValueChanged.RemoveListener(NormalizedPositionChangedTowWay);
                _target = null;
                _scrollRect = null;
            }
        }

        void NormalizedPositionChangedOneWay(T value)
        {
            _scrollRect.normalizedPosition = BindingConverter.ConvertToConcreteType<Vector2>(value);
        }

        void NormalizedPositionChangedTowWay(Vector2 value)
        {
            _target.Value = BindingConverter.ConvertToGenericType<T, Vector2>(value);
        }
    }
}
