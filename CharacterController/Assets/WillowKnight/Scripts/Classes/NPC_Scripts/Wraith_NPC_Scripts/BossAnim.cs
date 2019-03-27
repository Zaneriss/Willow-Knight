using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAnim : EnemyAnim {


    //death particle effects.

    public GameObject DarkBlood;
    public GameObject DeathBlast;
    

	// Use this for initialization


    //upon taking damage take away damage from health, and instantiates the darkblood particle effect


    public override void DeathAnim()
    {
        Destroy(gameObject);
        Instantiate(DeathBlast, transform.position, Quaternion.identity);
    }



}
