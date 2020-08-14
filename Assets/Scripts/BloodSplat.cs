using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    public GameObject bloodSplat;
    public GameObject bloodSplatParticle;

    public void CreateBloodSplatEffect()
    {
        GameObject go = Instantiate(this.bloodSplat);
        go.transform.position = new Vector2(this.transform.position.x + Random.Range(-0.2f, 0.2f), this.transform.position.y - 0.2f);

        GameObject go2 = Instantiate(this.bloodSplatParticle);
        go2.transform.position = this.transform.position;
    }
}
