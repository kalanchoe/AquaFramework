using UnityEngine.Events;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForUnityEvent : IBindingHelper
    {
        UnityEvent _source;
        UnityAction _action;

        public BindingHelperForUnityEvent(UnityEvent source, UnityAction action)
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
