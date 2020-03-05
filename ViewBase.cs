using AquaFramework.Binding.BindingHelpers;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AquaFramework
{
    public abstract class ViewBase : MonoBehaviour
    {

        List<IBindingHelper> _bindingHelpers = new List<IBindingHelper>();

        protected void Bind<T>(Action<T> action, IBindableProperty<T> target, Model model)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForAction<T>(action, target, model));
        }
        protected void Bind(UnityEvent source, UnityAction action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _bindingHelpers.Add(new BindingHelperForUnityEvent(source, action));
        }
        protected void Bind<T>(UnityEvent<T> source, UnityAction<T> action)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            _bindingHelpers.Add(new BindingHelperForUnityEvent<T>(source, action));
        }
        protected void Bind<T>(TextMeshProUGUI text, string source, IBindableProperty<T> target, Model model)
        {
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForTextMeshProUGUI<T>(text, source, target, model));
        }
        protected void Bind<T>(Image image, string source, IBindableProperty<T> target, Model model)
        {
            if (image is null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForImage<T>(image, source, target, model));
        }
        protected void Bind<T>(ScrollRect scrollRect, string source, IBindableProperty<T> target, Model model)
        {
            if (scrollRect is null)
            {
                throw new ArgumentNullException(nameof(scrollRect));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForScrollRect<T>(scrollRect, source, target, model));
        }
        protected void Bind<T>(TMP_InputField inputField, string source, IBindableProperty<T> target, Model model)
        {
            if (inputField is null)
            {
                throw new ArgumentNullException(nameof(inputField));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForTMP_InputField<T>(inputField, source, target, model));
        }
        protected void Bind<T>(Toggle toggle, string source, IBindableProperty<T> target, Model model)
        {
            if (toggle is null)
            {
                throw new ArgumentNullException(nameof(toggle));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForToggle<T>(toggle, source, target, model));
        }
        protected void Bind<T>(Slider slider, string source, IBindableProperty<T> target, Model model)
        {
            if (slider is null)
            {
                throw new ArgumentNullException(nameof(slider));
            }

            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("message", nameof(source));
            }

            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            _bindingHelpers.Add(new BindingHelperForSlider<T>(slider, source, target, model));
        }
        protected void Bind<T>(ScrollRect scrollRect, IBindableList<T> list, GameObject cell, Model model)
        {
            if (scrollRect is null)
            {
                throw new ArgumentNullException(nameof(scrollRect));
            }

            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (cell is null)
            {
                throw new ArgumentNullException(nameof(cell));
            }
            _bindingHelpers.Add(new BindingHelperForList<T>(scrollRect, list, cell, model, GenerateCell));
        }
        protected void Bind<TCellData, TListContext>(ScrollRect scrollRect, IBindableList<TCellData, TListContext> list, GameObject cell, Model model)
        {
            if (scrollRect is null)
            {
                throw new ArgumentNullException(nameof(scrollRect));
            }

            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (cell is null)
            {
                throw new ArgumentNullException(nameof(cell));
            }
            _bindingHelpers.Add(new BindingHelperForList<TCellData, TListContext>(scrollRect, list, cell, model, GenerateCell));
        }
        GameObject GenerateCell(GameObject cell, Transform content)
        {
            return Instantiate(cell, content);
        }
        protected virtual void OnDestroy()
        {
            foreach (IBindingHelper bindingHelper in _bindingHelpers)
            {
                bindingHelper.UnBind();
            }
            _bindingHelpers.Clear();
        }
    }
}