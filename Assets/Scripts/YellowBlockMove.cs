// YellowBlockMove.cs
using UnityEngine;

public class YellowBlockMove : MonoBehaviour
{
    public float speed = 1f;
    private Vector2 direction = Vector2.left;
    public string reflectingTag1 = "Wall";
    public string reflectingTag2 = "Block";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            Rigidbody2D ballRb = collision.attachedRigidbody;

            Vector2 reflectedVelocity = Vector2.Reflect(ballRb.velocity, Vector2.down);
            ballRb.velocity = reflectedVelocity;
            GetComponent<BlockScript>().collisionBall();
        } else if (collision.gameObject.CompareTag(reflectingTag2) || collision.gameObject.CompareTag(reflectingTag1)){
            direction = -direction;
        }
    }
}