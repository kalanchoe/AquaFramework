using AquaFramework.Exceptions;
using UnityEngine;
using UnityEngine.UI;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForImage<T> : IBindingHelper
    {
        Image _image;
        string _source;
        IBindableProperty<T> _target;
        Model _model;

        public BindingHelperForImage(Image image, string source, IBindableProperty<T> target, Model model)
        {
            _image = image;
            _source = source;
            _target = target;
            _model = model;
            switch (source)
            {
                case nameof(image.sprite):
                    if (model == Model.OneTime)
                    {
                        image.sprite = BindingConverter.ConvertToConcreteType<Sprite>(target.Value);
                    }
                    else if (model == Model.OneWay)
                    {
                        image.sprite = BindingConverter.ConvertToConcreteType<Sprite>(target.Value);
                        target.ValueChanged += SpriteChangedOneWay;
                    }
                    else if (model == Model.TowWay) throw new AquaFrameworkException("Do not support tow way binding for " + nameof(image.sprite) + ".");
                    break;
                default:
                    throw new AquaFrameworkException("Do not support binding for " + nameof(source) + ".");
            }
        }

        void SpriteChangedOneWay(T value)
        {
            _image.sprite = BindingConverter.ConvertToConcreteType<Sprite>(value);
        }

        public void UnBind()
        {
            if (_source == nameof(_image.sprite) && _model == Model.OneWay)
            {
                _target.ValueChanged -= SpriteChangedOneWay;
                _target = null;
                _image = null;
            }
        }
    }
}
