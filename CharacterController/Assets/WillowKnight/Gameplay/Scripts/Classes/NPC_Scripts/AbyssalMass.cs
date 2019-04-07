using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssalMass : EnemyBaseScript
{



    public override void Movement(){

    }

    protected override void SelfDestruct(){
        Destroy(this.gameObject);
    }

    public override void TakeDamage(int _dmg){

    }

}
