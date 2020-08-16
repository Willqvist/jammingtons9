using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{

    public Text cops, lava, ufo, barrel, tot;
    
    // Start is called before the first frame update
    void Start()
    {
        cops.text = $"Eliminated {GlobalVariables.Instance.guardDeath} Cops";
        lava.text = $"Survived {GlobalVariables.Instance.lavaSurvived} Lava floods";
        ufo.text = $"Destroyed {GlobalVariables.Instance.aliensDeath} UFO's";
        barrel.text = $"Exploded {GlobalVariables.Instance.barrelsDestroyed} Barrels";
        tot.text = $"... with a total score of: {calcTot()}";
    }

    public static int calcTot()
    {
        return GlobalVariables.Instance.guardDeath * 100 + GlobalVariables.Instance.barrelsDestroyed * 150 +
               GlobalVariables.Instance.lavaSurvived * 1000 + GlobalVariables.Instance.aliensDeath * 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
