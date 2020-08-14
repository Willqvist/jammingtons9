using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeathTimer : MonoBehaviour
{
    public float duration;

    public void StartTicking()
    {
        Timer.Instance.StartTimer("ParticleDeathTimer", duration, () => 
        {
            Destroy(this.gameObject);
        });
    }
}
