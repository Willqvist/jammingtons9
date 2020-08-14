using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Gun gun;
    public DirectionComponent directionComponent;
    public GameObjectPool pool;
    void Update()
    {
        if(GlobalVariables.Instance.PlayerIsStunned)
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
                var rb = shell.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(0, 0);
                rb.AddTorque(22);
                rb.AddForce(new Vector2((Random.value*4+1)*-this.directionComponent.GetDirection().x, 10), ForceMode2D.Impulse);
            }
        }
    }

    public void SetGun(Gun gun)
    {
        this.gun = gun;
    }
}
