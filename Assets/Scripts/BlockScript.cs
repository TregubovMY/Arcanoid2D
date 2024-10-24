using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BlockScript : MonoBehaviour
{
    public int hitsToDestroy;
    public int points;

    public GameObject textObject;
    Text textComponent; // TMP_Text textComponent;
    PlayerScript playerScript;
    public static event Action<Vector2> OnDestroyedPosition;

    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
        playerScript = GameObject.FindGameObjectWithTag("Player")
 .GetComponent<PlayerScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            hitsToDestroy--;
            if (hitsToDestroy == 0)
            {
                OnDestroyedPosition?.Invoke(transform.position);
                Destroy(gameObject);
                playerScript.BlockDestroyed(points, transform.position);
            }
            else if (textComponent != null)
                textComponent.text = hitsToDestroy.ToString();
        }
    }

    public void collisionBall() {
        hitsToDestroy--;
        if (hitsToDestroy == 0)
        {
            OnDestroyedPosition?.Invoke(transform.position);
            Destroy(gameObject);
            playerScript.BlockDestroyed(points, transform.position);
        }
        else if (textComponent != null)
            textComponent.text = hitsToDestroy.ToString();
    }
}
