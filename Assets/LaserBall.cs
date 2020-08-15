﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : MonoBehaviour
{
    bool is_destroyed;

    private void Start()
    {
        this.GetComponent<Animator>().Play("LaserBallAnimation");
    }

    public void FireMaLaza()
    {
        this.GetComponentInParent<UfoShoot>().Shoot();

        if (!is_destroyed)
        {
            Timer.Instance.StartTimer("wefwfs", 1.5f, () =>
            {
                if(is_destroyed)
                {
                    return;
                }

                this.GetComponent<Animator>().Play("LaserBallAnimation");
            });
        }
    }

    private void OnDestroy()
    {
        is_destroyed = true;
    }
}
