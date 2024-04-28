using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Generic
{
    [Serializable]
    public class Observer<T>
    {
        [SerializeField] T value;
        [SerializeField] UnityEvent<T> onValueChanged;
        public T Value { get => value; set => Set(value); }

        public Observer(T value = default, UnityAction<T> callback = null)
        {
            this.value = value;
            onValueChanged = new UnityEvent<T>();
            if (callback != null) onValueChanged.AddListener(callback);
        }

        public void Set(T value)
        {
            if (Equals(this.value, value)) return;

            this.value = value;
            Invoke();
        }

        public void Invoke()
        {
            Debug.Log($"Invoking {onValueChanged.GetPersistentEventCount()}");
            onValueChanged.Invoke(value);
        }

        public void AddListner(UnityAction<T> callback)
        {
            if (callback == null) return;
            if (onValueChanged == null) onValueChanged = new UnityEvent<T>();

            onValueChanged.AddListener(callback);
        }

        public void RemoveListner(UnityAction<T> callback)
        {
            if (callback == null) return;
            if (onValueChanged == null) onValueChanged = new UnityEvent<T>();

            onValueChanged.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            if (onValueChanged == null) return;

            onValueChanged.RemoveAllListeners();
        }

        public void Dispose()
        {
            RemoveAllListeners();
            onValueChanged = null;
            value = default;
        }
    }
}