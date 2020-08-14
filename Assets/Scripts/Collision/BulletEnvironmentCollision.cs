using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionHolder))]
public class BulletEnvironmentCollision : MonoBehaviour
{
    public GameObject dustParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Environment") || collision.gameObject.CompareTag("Wall"))
        {
            GameObject go = Instantiate(dustParticles);
            go.transform.position = this.transform.position;
            var system = go.GetComponent<ParticleSystem>();
            var Shape = system.shape;
            var main = system.main;
            Shape.rotation = new Vector3(0, this.GetComponent<DirectionHolder>().Direction.x < 0 ? 90 : -90, 0);
            Destroy(this.gameObject);
        }
    }
}
