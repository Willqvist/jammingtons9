using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public void AddHealth(int amount)
    {
        this.currentHealth += amount;
    }

    public void RemoveHealth(int amount)
    {
        this.currentHealth -= amount;
    }
}
