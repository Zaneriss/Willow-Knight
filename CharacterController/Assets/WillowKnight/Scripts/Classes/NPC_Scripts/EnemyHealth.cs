using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, iDamagable {

    public int maxHealth = 10;
    int currentHealth;

    public Image healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

 
    public void TakeDamage(float _damage)
    {
        currentHealth -= Mathf.FloorToInt(_damage);
        DamageEffects();

        UpdateHealth();
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

    void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

}
