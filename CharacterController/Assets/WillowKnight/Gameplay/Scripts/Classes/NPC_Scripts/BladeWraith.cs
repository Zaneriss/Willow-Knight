using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeWraith : EnemyBaseScript
{

    [Range(1, 5)]
    public float AttackRange = 1;

    Animator animatorComponent;

    public GameObject DeathBlast;


    protected override void Start()
    {
        base.Start();
        animatorComponent = this.GetComponentInChildren<Animator>();
    }

    protected void Update()
{
    Movement();
        AttackTrigger();
}

public override void Movement()
{
    Vector2 _playerPosition = playerDetection();
    Rigidbody2D MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();

    //horizontal movement tracking the player
    if (_playerPosition != Vector2.zero)
    {
        Vector2 _playerDirection = _playerPosition - new Vector2(this.transform.position.x, this.transform.position.y);

            // if (!TerrainCheck(_playerDirection.normalized + new Vector2(this.transform.position.x, this.transform.position.y)))
            // {
            //     MyRigidBody.position += ((new Vector2(_playerDirection.x, _playerDirection.y)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;
            // }

            MyRigidBody.position += ((new Vector2(_playerDirection.x, _playerDirection.y)).normalized * moveSpeedInUnitsPerSecond) * Time.deltaTime;

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
}

protected override void SelfDestruct()
{
    Destroy(this.gameObject);

    GameObject DeathBurst = GameObject.Instantiate(DeathBlast, this.transform.position, Quaternion.identity);
}

    protected virtual void Attack()
    {
        animatorComponent.SetTrigger("AttackTrigger");
    }

    protected virtual void AttackTrigger()
    {
        if (playerDetection(AttackRange) != Vector2.zero)
        {
            Attack();
        }
    }



    protected bool TerrainCheck(Vector2 _movementDirection)
    {
        RaycastHit2D[] _hit = Physics2D.LinecastAll(
            new Vector2(this.transform.position.x, this.transform.position.y),
            _movementDirection.normalized * AttackRange*2
        );
        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y),_movementDirection.normalized * AttackRange*2);
        for (int _i = 0; _i < _hit.Length; _i++)
        {

            


            if (_hit[_i].collider.tag == "Terrain" || _hit[_i].collider.tag == "Player")
            {
                Debug.Log(_hit[_i].collider.tag);
                return true;
            }
        }
        return false;
    }

}
