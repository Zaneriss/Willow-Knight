using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeWraith : EnemyBaseScript
{

    [Range(1, 5)]
    public float AttackRange = 1;

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
            if (!TerrainCheck(_playerDirection.normalized + new Vector2(this.transform.position.x, this.transform.position.y)))
            {
                MyRigidBody.position += ((new Vector2(_playerDirection.x, _playerDirection.y)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;
            }
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

    protected virtual void AttackTrigger()
    {
        if (playerDetection(AttackRange) != Vector2.zero)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {

    }


    protected bool TerrainCheck(Vector2 _movementDirection)
    {
        RaycastHit2D[] _hit = Physics2D.LinecastAll(
            new Vector2(this.transform.position.x, this.transform.position.y),
            new Vector2(_movementDirection.x, _movementDirection.y)
        );

        for (int _i = 0; _i < _hit.Length; _i++)
        {
            if (_hit[_i].collider.tag == "Terrain")
            {
                return true;
            }
        }
        return false;
    }

}
