﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeWraith : EnemyBaseScript
{

protected void Update()
{
    TerrainCheck();
}

public override void Movement()
{
    Vector2 _playerPosition = playerDetection();
    Rigidbody2D MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();

    //horizontal movement tracking the player
    if (_playerPosition != Vector2.zero)
    {
        Vector2 _playerDirection = _playerPosition - new Vector2(this.transform.position.x, this.transform.position.y);
        MyRigidBody.position += ((new Vector2(_playerDirection.x, _playerDirection.y)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;
    }
    //horizontal end
}

protected override void SelfDestruct()
{



    Destroy(this.gameObject);
}

protected virtual void attack(iDamagable _target, int _dmg)
{

    _target.TakeDamage(_dmg);
}

protected void TerrainCheck()
    {
        Vector2 _playerPosition = playerDetection();
        RaycastHit2D[] _hit = Physics2D.LinecastAll(
            new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(_playerPosition.x, _playerPosition.y)
        );

        for (int _i = 0; _i < _hit.Length; _i++)
        {
            if (_hit[_i].collider.tag != "Terrain")
            {
                Movement();
            }
        }
    }

}
