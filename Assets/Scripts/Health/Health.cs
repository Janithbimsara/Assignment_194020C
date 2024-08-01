using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }

    private bool dead;

    public void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Player alive
        }
        else
        {
            // Player dead
            if (!dead)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerRespawn>().Respawn();
                dead = true;
            }
        }
    }

    public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn(){
        AddHealth(startingHealth);
        dead = false;
    }
}
