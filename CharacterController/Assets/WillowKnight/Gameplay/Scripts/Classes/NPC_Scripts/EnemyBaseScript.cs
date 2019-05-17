using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseScript : MonoBehaviour , iDamagable
{
    public float moveSpeedInUnitsPerSecond = 1;

    //Maximum Health Set at start
    public int maxHealth = 10;
    //current health value
    int currentHealth;

    [Range (0,200)]
    public float detectionRadius = 5;

    public Transform groundCheckObject;

    


    protected virtual void Start() {
        currentHealth = maxHealth;
    }

    public abstract void Movement();

    protected abstract void SelfDestruct();

    #region PlayerDetection

    //Player Detection Code
    //returns Player location as a vector2
    protected virtual Vector2 playerDetection(){
        //Vector to be returned
        Vector2 _playerLocation = Vector2.zero;
        //Use a circle cast to grab all "hits" for objects within set radius
        RaycastHit2D[] _hits = Physics2D.CircleCastAll(this.gameObject.GetComponent<Rigidbody2D>().position,detectionRadius,Vector2.zero);
        //cycle through the hits if any of them were a "Player" object set the _playerLocation variable to the position of the collider.
        for(int _i = 0; _i < _hits.Length;_i++){
            if (_hits[_i].collider.gameObject.tag == "Player"){
                _playerLocation = _hits[_i].collider.gameObject.transform.position;
            }
        }
        
        //return the found player location
        return _playerLocation;
      
    }
    //returns Player location as a vector2 taking in the detection range
    protected virtual Vector2 playerDetection(float _detectionRange){
        //Vector to be returned
        Vector2 _playerLocation = Vector2.zero;
        //Use a circle cast to grab all "hits" for objects within set radius
        RaycastHit2D[] _hits = Physics2D.CircleCastAll(this.gameObject.GetComponent<Rigidbody2D>().position,_detectionRange,Vector2.zero);
        //cycle through the hits if any of them were a "Player" object set the _playerLocation variable to the position of the collider.
        for(int _i = 0; _i < _hits.Length;_i++){
            if (_hits[_i].collider.gameObject.tag == "Player"){
                _playerLocation = _hits[_i].collider.gameObject.transform.position;
            }
        }
        
        //return the found player location
        return _playerLocation;
      
    }

    #endregion


    //iDamagable method take damage
    public virtual void TakeDamage(int _dmg){
        //lower health by damage value
        currentHealth -= _dmg;
        //run enemy specific death script if current health is less than or equal to zero
        if(currentHealth<=0){
            SelfDestruct();
        }
    }

    public virtual bool GroundCheck(){

        bool _checkData = false;

        RaycastHit2D[] _hit = Physics2D.LinecastAll(
            new Vector2(this.transform.position.x,this.transform.position.y),
            new Vector2(groundCheckObject.position.x,groundCheckObject.position.y)
        );

           for(int _i = 0; _i<_hit.Length;_i++){
               if(_hit[_i].collider.tag == "Terrain"){
                   _checkData = true;
               }
           }


        return _checkData;
    }

}
