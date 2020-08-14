using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    public static Timer Instance => instance;

    private List<TimerInstance> timers = new List<TimerInstance>();

    public void StartTimer(string id, float duration, UnityAction callback)
    {
        this.timers.Add(new TimerInstance(id, duration, callback));
    }

    public TimerInstance GetTimer(string id)
    {
        foreach(var timer in timers)
        {
            if (timer.id == id)
                return timer;
        }

        return null;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        for(int i = 0; i < this.timers.Count; i++)
        {
            timers[i].Tick();
            if (timers[i].IsFinished())
            {
                timers[i].callback.Invoke();
                timers.Remove(timers[i]);
            }
        }
    }
}

public class TimerInstance
{
    public string id;
    public float duration;
    public UnityAction callback;

    public TimerInstance(string id, float duration, UnityAction callback)
    {
        this.id = id;
        this.duration = duration;
        this.callback = callback;
    }

    public void Tick()
    {
        this.duration -= Time.deltaTime;
    }

    public bool IsFinished()
    {
        return this.duration <= 0;
    }
}
