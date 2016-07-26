using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class implementing a simple messaging system.
/// </summary>
public sealed class EventManager : SceneSingleton<EventManager>
{
	private EventManager () {}

    private Dictionary<string, UnityEvent> eventDictionary;

	protected sealed override void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

	/// <summary>
	/// Adds a listener.
	/// </summary>
	/// <param name="eventName">Name of the event.</param>
	/// <param name="listener">Listener to add.</param>
    public void AddListener(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventName, thisEvent);
        }
    }

	/// <summary>
	/// Removes a listener.
	/// </summary>
	/// <param name="eventName">Name of the event.</param>
	/// <param name="listener">Listener to remove.</param>
    public void RemoveListener(string eventName, UnityAction listener)
    {
        if (instance == null)
        {
            return;
        }
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

	/// <summary>
	/// Triggers an event.
	/// </summary>
	/// <param name="eventName">Name of the event.</param>
    public void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

}
