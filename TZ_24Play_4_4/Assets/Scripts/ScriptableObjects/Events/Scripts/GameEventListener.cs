using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TZ
{
    public class GameEventListener : MonoBehaviour
    {
        public List<EventsList> eventsLists;
        void OnEnable()
        {
            for (int i = 0; i < eventsLists.Count; i++)
            {
                eventsLists[i].gameEvent.AddListener(this);
            }
        }
        void OnDisable()
        {
            for (int i = 0; i < eventsLists.Count; i++)
            {
                eventsLists[i].gameEvent.RemoveListener(this);
            }
        }
        public void OnEventTriggered(GameEvent @event)
        {
            for (int i = 0; i < eventsLists.Count; i++)
            {
                if (eventsLists[i].gameEvent == @event)
                {
                    eventsLists[i].onEventTriggered.Invoke();
                }
            }
        }
        public void OnEventTriggered(GameEvent @event, int intValue)
        {
            for (int i = 0; i < eventsLists.Count; i++)
            {
                if (eventsLists[i].gameEvent == @event)
                {
                    eventsLists[i].onIntEventTriggered.Invoke(intValue);
                    eventsLists[i].onEventTriggered.Invoke();
                }
            }
        }
        public void OnEventTriggered(GameEvent @event, bool boolValue)
        {
            for (int i = 0; i < eventsLists.Count; i++)
            {
                if (eventsLists[i].gameEvent == @event)
                {
                    eventsLists[i].onBoolEventTriggered.Invoke(boolValue);
                }
            }
        }
    }

    [System.Serializable]
    public class EventsList
    {
        public GameEvent gameEvent;
        public UnityEvent onEventTriggered;
        public UnityEvent<int> onIntEventTriggered;
        public UnityEvent<bool> onBoolEventTriggered;
    }
}
