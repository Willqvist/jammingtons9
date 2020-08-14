using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

    public CanvasGroup group;
    public Volume volume;
    public float speed;

    private bool fading = false;

    private Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        if (!volume.profile.TryGet<Bloom>(out bloom))
        {
            Debug.Log("CANT GET BLOOM!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            group.alpha = Mathf.Lerp(group.alpha, 1, Time.deltaTime * speed);
            bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, 12f, Time.deltaTime * speed);
            if (group.alpha > 0.98)
            {
                bloom.intensity.value = 0;
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void Fade()
    {
        fading = true;
    }

}
