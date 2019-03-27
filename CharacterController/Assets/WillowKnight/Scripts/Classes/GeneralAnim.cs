using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralAnim : MonoBehaviour
{

    Animator AnimatorComponent;


    private void Start()
    {
        AnimatorComponent = this.GetComponent<Animator>();
    }


    public abstract void DamageAnim();

    public abstract void IdleAnim();

    public abstract void DeathAnim();

    public abstract void AttackAnim();

   

}
