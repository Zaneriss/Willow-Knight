using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour { 

    //time between attacks
    public float timeb4attack;

    //time it takes to start an attack
    public float startTimeb4attack;

    //determines what the attack key is
    public KeyCode AttackKey;

    //determines attack position
    public Transform attackPos;

    //sets layer mask to be targetted as an enemy
    public LayerMask MarkAsEnemy;

    //float determining attack range
    public float attackRange;

    //int determining attack damage
    public int damage;

    //gets attack animation
    public Animator BorisSlash;

    //attack sound effect
    

    public void Update()
    {
        //if not already in the middle of an attacking allows the player to attack in the given range

        if (timeb4attack <= 0)
        {
            if (Input.GetKey(AttackKey))
            {
                BorisSlash.SetTrigger("IsAttacking");
                FMODUnity.RuntimeManager.CreateInstance("event:/Weapon sounds/Weapon_Swing_Attacked");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, MarkAsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {

                    enemiesToDamage[i].GetComponent<Boss>().TakeDamage(damage);
                }

            }

            timeb4attack = startTimeb4attack;
        }

        else
        {
            timeb4attack -= Time.deltaTime;
        }

    }

    //displays attack range as a circle in the scene editor

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
