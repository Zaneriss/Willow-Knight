using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssalMass : EnemyBaseScript
{


    [Range(1, 17)]
    public float FallSpeedInUnitsPerSecond = 1;

    public Transform frontCheckObject;



    protected void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        Vector2 _playerPosition = playerDetection();
        Rigidbody2D MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();

        //horizontal movement tracking the player
        if (_playerPosition != Vector2.zero)
        {
            Vector2 _playerDirection = _playerPosition - new Vector2(this.transform.position.x, this.transform.position.y);
            if (!frontCheck())
            {
                MyRigidBody.position += ((new Vector2(_playerDirection.x, 0)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;
            }
            if (_playerDirection.x > 0)
            {
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (_playerDirection.x < 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }

        }

        //horizontal end


        //gravity effect
        if (GroundCheck() != true)
        {
            MyRigidBody.position += (Vector2.down * FallSpeedInUnitsPerSecond) * Time.deltaTime;
        }


    }

    protected override void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    protected virtual void attack(iDamagable _target, int _dmg)
    {
        _target.TakeDamage(_dmg);
    }

    protected virtual bool frontCheck()
    {

        bool _checkData = false;

        RaycastHit2D[] _hit = Physics2D.LinecastAll(
            new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(frontCheckObject.position.x, frontCheckObject.position.y)
        );

        for (int _i = 0; _i < _hit.Length; _i++)
        {
            if (_hit[_i].collider.tag != "Enemy")
            {
                _checkData = true;
            }
        }


        return _checkData;
    }

}
