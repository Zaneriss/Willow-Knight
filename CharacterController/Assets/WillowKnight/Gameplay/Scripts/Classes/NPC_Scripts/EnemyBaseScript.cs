using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseScript : MonoBehaviour , iDamagable
{
    public float moveSpeedInUnitsPerSecond;

    public float maxHealth;
    float currentHealth;

    public Transform groundCheckObject;


    public virtual void Start() {
        currentHealth = maxHealth;
    }

    public abstract void Movement();

    public abstract void TakeDamage(float _dmg);

    public virtual bool GroundCheck(){
        
        bool _checkData = Physics2D.Linecast(new Vector2(this.transform.position.x,this.transform.position.y), new Vector2(groundCheckObject.position.x,groundCheckObject.position.y));

        return _checkData;
    }

}
