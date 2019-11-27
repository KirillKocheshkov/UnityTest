using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
   public  int maxHealth;
   private int currentHealth;
   public int GetCurrentHealth {get{return currentHealth; } set { currentHealth = value;}}

   
   void Awake()
   {
       currentHealth = maxHealth;
   }
   public void DealDamage (int dmg)
    {
        currentHealth -= dmg;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
