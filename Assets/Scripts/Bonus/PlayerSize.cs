using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : Bonus
{
    [SerializeField] private bool _negative;
    private const float Size = 0.5f;

    public override void Apply()
    {
        StartTimer();
        SetSize(_negative ? -Size : Size);
    }

    protected override void Remove()
    {
        SetSize(_negative ? Size : -Size);
    }

    private void SetSize(float value)
    {
        PlayerScript player = GetComponentInParent<PlayerScript>();
        if (player != null)
        {
            if (player.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                player.transform.localScale = new Vector3(
                    player.transform.localScale.x + value,
                    player.transform.localScale.y + value,
                    player.transform.localScale.z
                );
            }

            if (player.TryGetComponent(out BoxCollider2D boxCollider2D))
            {
                boxCollider2D.size = new Vector2(boxCollider2D.size.x + value, boxCollider2D.size.y + value);
            }
        }
    } 
}
