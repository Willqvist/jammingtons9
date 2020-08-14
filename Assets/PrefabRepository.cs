using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabRepository : MonoBehaviour
{
    private static PrefabRepository instance;
    public static PrefabRepository Instance => instance;

    public GameObject guard;

    private void Awake()
    {
        instance = this;
    }
}
