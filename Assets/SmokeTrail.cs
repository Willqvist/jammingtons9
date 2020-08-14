using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrail : MonoBehaviour
{
    public GameObject smokeTrailParticle;
    public Transform smokeTrailParticleSpawnLocation;
    private GameObject smokeTrailParticleInstance;

    void Start()
    {
        this.smokeTrailParticleInstance = Instantiate(this.smokeTrailParticle);
        this.smokeTrailParticleInstance.transform.position = this.smokeTrailParticleSpawnLocation.position;
    }

    private void Update()
    {
        if(this.smokeTrailParticleInstance == null)
        {
            return;
        }

        this.smokeTrailParticleInstance.transform.position = this.smokeTrailParticleSpawnLocation.position;
        this.smokeTrailParticleInstance.transform.localScale = new Vector2(-Mathf.Sign(this.transform.localScale.x), this.smokeTrailParticleInstance.transform.localScale.y);
    }

    private void OnDestroy()
    {
        this.smokeTrailParticleInstance.GetComponent<ParticleSystem>().Stop();
    }
}
