using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseScript : MonoBehaviour , iDamagable
{
    public float moveSpeedInUnitsPerSecond;

    public int maxHealth;
    int currentHealth;

    public Transform groundCheckObject;

    


    public virtual void Start() {
        currentHealth = maxHealth;
    }

    public abstract void Movement();

    protected abstract void SelfDestruct();

    protected virtual Vector2 playerDetection(){
        Vector2 _playerLocation = Vector2.zero;

        return _playerLocation;
    }

    public virtual void TakeDamage(int _dmg){
        currentHealth -= _dmg;

        if(currentHealth<=0){
            SelfDestruct();
        }
    }

    public virtual bool GroundCheck(){
        
        bool _checkData = Physics2D.Linecast(new Vector2(this.transform.position.x,this.transform.position.y), new Vector2(groundCheckObject.position.x,groundCheckObject.position.y));

        return _checkData;
    }

}
