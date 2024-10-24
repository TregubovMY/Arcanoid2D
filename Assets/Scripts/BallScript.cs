using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallScript : MonoBehaviour
{
    public Vector2 ballInitialForce;
    Rigidbody2D rb;
    GameObject playerObj;
    float deltaX;

    AudioSource audioSrc;
    public AudioClip hitSound;
    public AudioClip loseSound;
    public GameDataScript gameData;
    private PlayerScript player;

    private bool isStuck = false;
    public Vector2 lastVelocity;
    private Vector2 ballOffset; // Смещение от ракетки
    private Sticky stickyBonus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        deltaX = transform.position.x;
        player = playerObj.GetComponent<PlayerScript>();

        audioSrc = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
// Нужно пофиксить:
// 1) Чтобы если sliky и подобрал simple мячь отлетал. 
// 2) сделать двигающийся блок
// 3) Пофиксить баг, что дважды нельзя сделать склизким
// 4) ...
        if (isStuck)
        {
            transform.position = playerObj.transform.position + (Vector3)ballOffset;
            
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl) || !player.IsSticky)
            {
                UnstickFromPlayer();
            }
        }
        else if (rb.isKinematic)
            if (Input.GetButtonDown("Fire1"))
            {
                rb.isKinematic = false;
                rb.AddForce(ballInitialForce);
            }
            else
            {
                var pos = transform.position;
                pos.x = playerObj.transform.position.x + deltaX;
                transform.position = pos;
            }

        if (!rb.isKinematic && Input.GetKeyDown(KeyCode.J))
        {
            var v = rb.velocity;
            if (Random.Range(0, 2) == 0)
                v.Set(v.x - 0.1f, v.y + 0.1f);
            else
                v.Set(v.x + 0.1f, v.y - 0.1f);
            rb.velocity = v;
        }
    }

    public void StickToPlayer(Sticky bonus)
    {
        lastVelocity = rb.velocity;
        isStuck = true;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        ballOffset = transform.position - playerObj.transform.position;
        GetComponent<Collider2D>().enabled = false;
        stickyBonus = bonus;
    }

    public void UnstickFromPlayer()
    {
        isStuck = false;
        rb.isKinematic = false;
        rb.velocity = lastVelocity;
        GetComponent<Collider2D>().enabled = true;
        player.MakeSimple();
        if (stickyBonus != null)
        {
            stickyBonus.StopAndRemove();
            stickyBonus = null;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BottomWal")
        {
            if (gameData.sound)
                audioSrc.PlayOneShot(loseSound, 5);
            Destroy(gameObject);
            playerObj.GetComponent<PlayerScript>().BallDestroyed();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameData.sound)
            audioSrc.PlayOneShot(hitSound, 5);
    }

}
