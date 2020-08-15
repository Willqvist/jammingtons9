using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Gun gun = null;
    public Gun Gun
    {
        get
        {
            return gun;
        }
        set
        {
            if(gun != null)
                gun.gameObject.SetActive(false);
            gun = value;
            value.gameObject.SetActive(true);
        }
    }

    public DirectionComponent directionComponent;
    public GameObjectPool pool;
    void Update()
    {
        if(GlobalVariables.Instance.PlayerIsStunned || this.gun == null)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Z))
        {
            if (this.gun.Shoot(this.directionComponent.GetDirection()))
            {
                var shell = pool.pull();
                shell.transform.position = this.transform.position;
                shell.transform.rotation = Quaternion.Euler(0,0,Random.value*360);
                shell.GetComponent<SpriteRenderer>().sprite = gun.shellSprite;
                var rb = shell.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0, 0);
                rb.AddTorque(22);
                rb.AddForce(new Vector2((Random.value*4+1)*-this.directionComponent.GetDirection().x, 10), ForceMode2D.Impulse);
            }
        }
    }
}
