using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssalMass : EnemyBaseScript
{


    [Range(1,17)]
    public float FallSpeedInUnitsPerSecond = 1;




    protected void Update() {
        Movement();
    }

    public override void Movement(){
        Vector2 _playerPosition = playerDetection();
        Rigidbody2D MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();

        //horizontal movement tracking the player
        if(_playerPosition!= Vector2.zero){
            Vector2 _playerDirection = _playerPosition -new Vector2( this.transform.position.x, this.transform.position.y);
            MyRigidBody.position += ((new Vector2(_playerDirection.x,0)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;
        }
        //horizontal end
        

        //gravity effect
        if(GroundCheck() != true){
            MyRigidBody.position+= (Vector2.down * FallSpeedInUnitsPerSecond) * Time.deltaTime;
        }


    }

    protected override void SelfDestruct(){
        Destroy(this.gameObject);
    }



}
