using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBurden : EnemyBaseScript
{

    [Range(1, 17)]
    public float FallSpeedInUnitsPerSecond = 1;



    public override void Movement(){

    }

    // Update is called once per frame
    protected override void SelfDestruct(){

    }
}
