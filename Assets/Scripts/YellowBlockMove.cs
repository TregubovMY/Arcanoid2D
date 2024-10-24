using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBlockMove : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction = Vector2.left;
    public string reflectingTag1 = "Wall";
    public string reflectingTag2 = "Block";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 initialPosition = transform.position;
        
        RaycastHit2D hit = Physics2D.Raycast(initialPosition, direction, 2f);

        // Проверяем, произошло ли столкновение
        if (hit.collider != null && (hit.collider.CompareTag(reflectingTag2) || hit.collider.CompareTag(reflectingTag1)))
        {
            direction = -direction;
        }
        else
        {
        }
        
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0, 0);

        // if (hit.collider != null && )
        // {
        //     direction = -direction;
        // }
    }
}
