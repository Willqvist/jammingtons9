using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    private static ObjectActivator instance;
    public static ObjectActivator Instance => instance;


    [Header("Do not apply any objects below here as a prefab")]
    public GameObject player;

    private void Start()
    {
        instance = this;
    }
}
