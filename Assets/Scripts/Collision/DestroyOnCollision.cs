using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnCollision : MonoBehaviour
{
    public string[] targetTags;
    public UnityEvent onDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(var targetTag in targetTags)
        {
            if (collision.tag == targetTag)
            {
                this.onDestroy.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}
