using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour {

    //destroys particles FX after a given amount of time as to not pollute the scene

    public float DestroyTime;

    void Update () {

        Destroy(this.gameObject, DestroyTime);
    }
}
