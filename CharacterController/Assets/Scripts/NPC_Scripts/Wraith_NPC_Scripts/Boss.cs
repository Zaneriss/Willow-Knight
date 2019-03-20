using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    
    //determined how much health the enemy has.

    public int health;

    //unused speed variable 

    public float speed;

    //selects public slider, mainly used during testing.

    public Slider healthBar;
 
    //animators

    public Animator anim;

    //death particle effects.

    public GameObject DarkBlood;
    public GameObject DeathBlast;
    

	// Use this for initialization
	void Start () {

        //gets Animator

        anim = GetComponent<Animator>();
       
	}
	
	//Update is called once per frame
	void Update () {

        //sets the healthbar value to be equal to the amount of health left in the target.

        healthBar.value = health;

        //moves the enemy horizontally, however is currently unused

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        //if health is equal to or below zero the gameObject will be destroyed and a death blast will instantiate in its place.

        if( health <= 0)
        {
            Destroy(gameObject);
            Instantiate(DeathBlast, transform.position, Quaternion.identity);
        }
	}

    //upon taking damage take away damage from health, and instantiates the darkblood particle effect

    public void TakeDamage(int damage)
    {
        Instantiate(DarkBlood, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("DAMAGE TAKEN");
       
    }
}
