using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    [CreateAssetMenu(menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        [SerializeField] private List<GameEventListener> listeners = new();
        public void TriggerEvent()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered(this);
            }
        }
        public void TriggerEvent(int intValue)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered(this, intValue);
                listeners[i].OnEventTriggered(this);
            }
        }
        public void TriggerEvent(bool boolValue)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventTriggered(this, boolValue);
            }
        }


        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
