using UnityEngine.Events;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForUnityEvent<T> : IBindingHelper
    {
        UnityEvent<T> _source;
        UnityAction<T> _action;

        public BindingHelperForUnityEvent(UnityEvent<T> source, UnityAction<T> action)
        {
            _source = source;
            _action = action;
            source.AddListener(action);
        }

        public void UnBind()
        {
            _source.RemoveListener(_action);
            _source = null;
            _action = null;
        }
    }
}
