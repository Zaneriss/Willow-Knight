using System.Collections;
using UnityEngine;


public class ChargeAttack : MonoBehaviour {

    //determines the key that begins the charge attack
    public KeyCode ChargeKey;

    //determines the time it takes for the attack to fully charge
    public float Chargetime;
    
    //determines the attack's origin
    public Transform attackPos;

    //sets a layermask to be marked as enemy
    public LayerMask MarkAsEnemy;

    //determines the range of the charged attack
    public float attackRange;

    //determines the damage of the charged attack
    public int damage;

    //gets the animator for the charged attack
    public Animator BorisSlash;

    //particle FX used while charging the attack
    public GameObject ChargingParticles1;
    public GameObject ChargingParticles2;
    public GameObject ChargingParticles3;
    public GameObject ChargingParticles4;
    public GameObject AttackParticles;
    public GameObject ReadyParticles;

    // Update is called once per frame
    void Update () {

        //when the key is pressed the chargetime begins to increase in value
        if (Input .GetKey(ChargeKey))
        {
            Chargetime += Time.deltaTime;
           
        }

        //between given values the particle systems change as to show how close the charge attack is to being fully charged
        if ((Chargetime > 0.1) && ( Chargetime < 0.75))
        {
            Instantiate(ChargingParticles1, transform.position, Quaternion.identity);
        }

        if ((Chargetime > 0.75) && (Chargetime < 1.5))
        {
            Instantiate(ChargingParticles2, transform.position, Quaternion.identity);
        }

        if ((Chargetime > 1.5) && (Chargetime < 2))
        {
            Instantiate(ChargingParticles3, transform.position, Quaternion.identity);
        }

        if (Chargetime > 2) 
        {
            Instantiate(ChargingParticles4, transform.position, Quaternion.identity);
        }

        //a particle effect that gets triggered when the charge attack is ready to be used
        if ((Chargetime > 2) && (Chargetime < 2.1))
        {
            Instantiate(ReadyParticles, transform.position, Quaternion.identity);
        }

        //if the key is released and the chargetime is above the required amount to fully charge the attack, the attack gets
        //launched as well as a particle effect that indicates that this attack is in fact charged
        if ((Input.GetKeyUp(ChargeKey)) && (Chargetime > 2))
        {
            Instantiate(AttackParticles, transform.position, Quaternion.identity);
            Debug.Log("Boris SpecSlash");
            BorisSlash.SetTrigger("IsAttacking");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, MarkAsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {

                enemiesToDamage[i].GetComponent<iDamagable>().TakeDamage(damage);
            }

            //resets chargetime
            Chargetime = 0;

        }

        //if the charge attack is launched before it is ready then the player loses all of their charge and nothing happens
        if ((Input.GetKeyUp(ChargeKey)) && (Chargetime < 2))
        {
            Chargetime = 0;
        }


    }

    //draws a circle representing the range of the charged attack
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
