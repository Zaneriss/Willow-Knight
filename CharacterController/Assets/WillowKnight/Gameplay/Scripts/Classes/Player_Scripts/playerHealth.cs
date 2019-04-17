using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour , iDamagable
{
    [Range(1,50)]
    public int maxHealth = 20;
    int currentHealth;
    [Range(1,50)]
    public float ForceStrength;

    public GameObject DeathEffect;

    public GameObject DamageEffect;

    void Start()
    {
        currentHealth = maxHealth;
    }



    //iDamagable method take damage
    public virtual void TakeDamage(int _dmg)
    {
        //lower health by damage value
        currentHealth -= _dmg;

        this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ForceStrength,ForceMode2D.Impulse);

        GameObject Damage = GameObject.Instantiate(DamageEffect, this.transform.position, Quaternion.identity);



        //run enemy specific death script if current health is less than or equal to zero
        if (currentHealth <= 0)
        {
            GameObject DeathBurst = GameObject.Instantiate(DeathEffect, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }



}
