using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GunsMerge
{
    public class CustomEvent
    {
        private UnityEvent _unityEvent;
        private UnityEvent<object> _unityEventWithArgs;

        public CustomEvent()
        {
            _unityEvent = new UnityEvent();
            _unityEventWithArgs = new UnityEvent<object>();
        }
        public void AddListener(UnityAction unityAction) => _unityEvent.AddListener(unityAction);
        public void AddListener(UnityAction<object> unityAction) => _unityEventWithArgs.AddListener(unityAction);
        public void RemoveListener(UnityAction<object> unityAction) => _unityEventWithArgs.RemoveListener(unityAction);
        public void RemoveListener(UnityAction unityAction) => _unityEvent.RemoveListener(unityAction);
        public void Invoke()
        {
            _unityEventWithArgs?.Invoke(null);
            _unityEvent?.Invoke();
        }
        public void Invoke(object arg)
        {
            _unityEventWithArgs?.Invoke(arg);
            _unityEvent?.Invoke();
        }
    }

    public static class EventManager
    {
        private static Dictionary<eEventType, CustomEvent> eventListeners = new Dictionary<eEventType, CustomEvent>();

        public static void Subscribe(eEventType eventType, UnityAction<object> callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.AddListener(callback);
            }
            else
            {
                customEvent = new CustomEvent();
                customEvent?.AddListener(callback);
                eventListeners.Add(eventType, customEvent);
            }
        }
        public static void Subscribe(eEventType eventType, UnityAction callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.AddListener(callback);
            }
            else
            {
                customEvent = new CustomEvent();
                customEvent?.AddListener(callback);
                eventListeners.Add(eventType, customEvent);
            }
        }

        public static void Unsubscribe(eEventType eventType, UnityAction<object> callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.RemoveListener(callback);
            }
        }
        public static void Unsubscribe(eEventType eventType, UnityAction callback)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent?.RemoveListener(callback);
            }
        }

        public static void OnEvent(eEventType eventType, object arg)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent.Invoke(arg);
            }
        }
        public static void OnEvent(eEventType eventType)
        {
            if (eventListeners.TryGetValue(eventType, out CustomEvent customEvent))
            {
                customEvent.Invoke();
            }
        }
    }
}
