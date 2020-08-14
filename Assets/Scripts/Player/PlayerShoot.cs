using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Gun gun;
    public DirectionComponent directionComponent;

    void Update()
    {
        if(GlobalVariables.Instance.PlayerIsStunned)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Z))
        {
            this.gun.Shoot(this.directionComponent.GetDirection());
        }
    }
}
