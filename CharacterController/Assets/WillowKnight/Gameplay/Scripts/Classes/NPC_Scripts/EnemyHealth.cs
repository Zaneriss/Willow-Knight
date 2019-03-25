using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, iDamagable {

    int maxHealth;
    int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

 
    public void TakeDamage(float _damage)
    {
        currentHealth -= Mathf.FloorToInt(_damage);
        DamageEffects();
    }

    public void DamageEffects()
    {
        if(currentHealth <= 0)
        {
            this.GetComponent<EnemyAnim>().DeathAnim();
        } else
        {
            this.GetComponent<EnemyAnim>().DamageAnim();
        }

    }

}
