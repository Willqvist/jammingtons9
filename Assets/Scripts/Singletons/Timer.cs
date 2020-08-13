using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private static Timer instance;
    public static Timer Instance => instance;

    private List<TimerInstance> timers = new List<TimerInstance>();

    public void StartTimer(float duration, UnityAction callback)
    {
        this.timers.Add(new TimerInstance(duration, callback));
    }

    private void Start()
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
    public float duration;
    public UnityAction callback;

    public TimerInstance(float duration, UnityAction callback)
    {
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
