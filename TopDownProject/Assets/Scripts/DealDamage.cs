using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg;
    EnemyHealthManager enemy;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
     if(other.gameObject.CompareTag("Enemy"))
     {
         enemy = other.GetComponent<EnemyHealthManager>();
         enemy.DealDamage(dmg);
     }   
        
         
     
    }
    
}
