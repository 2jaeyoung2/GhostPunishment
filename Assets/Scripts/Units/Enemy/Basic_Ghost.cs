using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Ghost : EnemyManager
{
    public override float EnemyHP
    {
        get
        {
            return base.enemyHP;
        }
        set
        {
            base.enemyHP = value;
        }
    }

    protected override void Start()
    {
        EnemyHP = 30f;
    }


    //protected override void Update()
    //{

    //}
}
