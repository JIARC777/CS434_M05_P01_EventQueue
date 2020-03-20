using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;
    private int eventsInQueue = 0;
    // time it takes for queue to dequeue and trigger event
    private float dequeueInterval = 2.5f;
    private List<string> eventQueue;
    bool queueRunning = false;

    public override void Awake()
    {
        // Make sue there is only one instance
        base.Awake();
        // Initialize yourself
        Instance.Init();
    }
    private void Init()
    {
        if (Instance.m_EventDictionary == null)
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        if (Instance.eventQueue == null)
            Instance.eventQueue = new List<string>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void AddToQueue(string eventName)
    {
        Instance.eventQueue.Add(eventName);
        Debug.Log("Event Added to Queue: " + eventName);
        Instance.eventsInQueue++;

    }
    public IEnumerator DequeueEvent()
    {
        yield return new WaitForSeconds(dequeueInterval);
        while (eventsInQueue > 0)
        {
            
            Debug.Log("Number of events in Queue: " + eventsInQueue);
            string currentEvent = eventQueue[0];
            Debug.Log("Event Dequeued: " + currentEvent);
            Instance.eventQueue.RemoveAt(0);
            Instance.eventsInQueue--;
            TriggerEvent(currentEvent);
            yield return new WaitForSeconds(dequeueInterval);
        }
        queueRunning = false;
    }

    public void Update()
    {
        if (eventsInQueue > 0 && queueRunning == false)
        {
            StartCoroutine("DequeueEvent");
            queueRunning = true;
        }
            
    }
}
