using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponLibrary : MonoBehaviour
{
    private static PlayerWeaponLibrary instance;
    public static PlayerWeaponLibrary Instance => instance;

    public Gun Ak47;
    public Gun Raygun;
    public Gun bazooka;
    public Gun pistol;

    private void Awake()
    {
        instance = this;
    }

    public void GiveGun(Gun gun)
    {
        gun.gameObject.SetActive(true);
        this.GetComponent<PlayerMovement>().gun = gun.GetComponent<Animator>();
        this.GetComponent<PlayerShoot>().Gun = gun;
    }
}
