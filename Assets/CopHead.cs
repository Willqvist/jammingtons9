using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopHead : MonoBehaviour
{

    public ParticleSystem ps;
    public float speed;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    private bool start = false;
    private Color color = new Color(1f,1f,1f,1f);
    void Start()
    {
        Timer.Instance.StartTimer("hello",4, () =>
        {
            Destroy(this.gameObject);
        });
        
        Timer.Instance.StartTimer("hello",3, () =>
        {
            start = true;
            var a = ps.main;
            a.loop = false;
            ps.Stop();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        color.a = Mathf.Lerp(color.a, 0, Time.deltaTime * speed);
        sprite.color = color;
    }
}
