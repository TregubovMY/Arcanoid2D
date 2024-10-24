using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : Bonus
{
    public override void Apply()
    {
        StartTimer();
    }

    protected override void Remove()
    {
    }
}
