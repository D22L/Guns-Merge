using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GunsMerge
{
    public static class EventExtension
    {
        public static void Subscribe(this Component component, eEventType eventType, UnityAction<object> callback)
        {
            EventManager.Subscribe(eventType, callback);
        }
        public static void Subscribe(this Component component, eEventType eventType, UnityAction callback)
        {
            EventManager.Subscribe(eventType, callback);
        }
        public static void Unsubscribe(this Component component, eEventType eventType, UnityAction<object> callback)
        {
            EventManager.Unsubscribe(eventType, callback);
        }
        public static void Unsubscribe(this Component component, eEventType eventType, UnityAction callback)
        {
            EventManager.Unsubscribe(eventType, callback);
        }
        public static void OnEvent(this Component component, eEventType eventType, object arg)
        {
            EventManager.OnEvent(eventType, arg);
        }
        public static void OnEvent(this Component component, eEventType eventType)
        {
            EventManager.OnEvent(eventType);
        }
        public static void OnEventAfterDelay(this Component component, eEventType eventType, MonoBehaviour monoBehaviour, float delay)
        {
            monoBehaviour.StartCoroutine(CallEventAfterDelay(eventType, delay));
        }

        private static IEnumerator CallEventAfterDelay(eEventType eventType, float delay)
        {
            yield return new WaitForSeconds(delay);
            EventManager.OnEvent(eventType);
        }
    }
}
