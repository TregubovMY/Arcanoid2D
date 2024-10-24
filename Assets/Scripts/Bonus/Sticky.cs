using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : Bonus
{
    public Color stickyColor = new Color(0.5f, 1f, 0.5f);
    [SerializeField] private bool _negative;


    public override void Apply()
    {
        PlayerScript player = GetComponentInParent<PlayerScript>();
        if (player != null)
        {
            if (_negative)
                player.MakeSimple();
            else
                player.MakeSticky(stickyColor);
        }
        StartTimer();
    }

    protected override void Remove()
    {
        PlayerScript player = GetComponentInParent<PlayerScript>();
        if (player != null)
        {
            // if (_negative)
                // player.MakeSticky(stickyColor);
            // else
                player.MakeSimple();
        }
    }
}
