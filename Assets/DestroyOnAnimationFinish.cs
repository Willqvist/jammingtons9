using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationFinish : MonoBehaviour
{
    public void OnAnimationFinish()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
