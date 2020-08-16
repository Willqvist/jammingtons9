using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRoll : MonoBehaviour
{
    public GameObject head;

    public void CreateHeadRollEffect()
    {
        if(Random.Range(0, 100) < 20)
        {
            var obj = Instantiate(head);
            var rb = obj.GetComponent<Rigidbody2D>();
            rb.transform.position = this.transform.position;
            rb.velocity = new Vector2(0, 0);
            rb.AddTorque(22);
            rb.AddForce(new Vector2((Random.value * 4 + 1), 14), ForceMode2D.Impulse);
        }
    }

    public void onDeath()
    {
        GlobalVariables.Instance.guardDeath++;
        ScoreUI.instance.setScore(ScoreScreen.calcTot());
    }
}
