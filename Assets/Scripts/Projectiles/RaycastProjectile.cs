using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DirectionHolder))]
public class RaycastProjectile : MonoBehaviour
{
    public Transform raycastStart;
    public LayerMask stopAtLayerCollision;
    public string[] tagsToTarget;
    public UnityEvent<Vector2, Vector2> onHit;

    private DirectionHolder directionHolder;
    private DamageDealer damageDealer;
    private bool hasHit = false;

    private void Start()
    {
        this.directionHolder = this.GetComponent<DirectionHolder>();
        this.damageDealer = this.GetComponent<DamageDealer>();
    }

    private List<RaycastHit2D> sort(RaycastHit2D[] hits)
    {
        List<RaycastHit2D> l = new List<RaycastHit2D>();
        l.AddRange(hits);
        
        l.Sort((c1,c2) =>
        {
            if (Vector3.Distance(c1.collider.transform.position, this.transform.position) <
                Vector3.Distance(c2.collider.transform.position, this.transform.position))
                return -1;
            else
            {
                return 1;
            }
        });

        return l;
    }

    private void Update()
    {
        if(hasHit)
            return;
        RaycastHit2D hit = Physics2D.Raycast(this.raycastStart.position, this.directionHolder.Direction, Mathf.Infinity, stopAtLayerCollision);
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, this.directionHolder.Direction);

        List<RaycastHit2D> sorted = sort(hits);
        
        if (hit)
        {
            this.onHit.Invoke(this.raycastStart.position, hit.point);
            this.hasHit = true;
        }

        foreach (var h in sorted)
        {

            foreach(var t in tagsToTarget)
            {
                if(h.transform.tag == t)
                {
                    h.transform.GetComponent<Hurt>().DealDamage(this.damageDealer.Damage);
                    if(!hasHit)
                    {
                        this.onHit.Invoke(this.raycastStart.position, h.transform.position);
                    }
                }
            }
            if (stopAtLayerCollision == (stopAtLayerCollision | (1 << h.collider.gameObject.layer)))
            {
                break;
            }
        }
    }
}
