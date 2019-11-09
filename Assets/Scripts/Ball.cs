using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    // Movement Speed
    public float speed = 220.0f;
    public bool sticky;

    private Pause pause;
    private Rigidbody2D rb2D;
    private GameObject racket;
    private Block block;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = Vector2.up * speed;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb2D.velocity.normalized.y) < 0.15f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.normalized.x, 0.15f * (rb2D.velocity.y > 0? 1: -1)).normalized * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            if (!sticky)
            {
                // Calculate hit Factor
                float x = HitFactor(transform.position,
                                  col.transform.position,
                                  col.collider.bounds.size.x);

                // Calculate direction, set length to 1
                Vector2 dir = new Vector2(x + col.gameObject.GetComponent<Rigidbody2D>().velocity.x / 300, 1).normalized;

                // Set Velocity with dir * speed
                rb2D.velocity = dir * speed;
            }
            else // sticky
            {
                rb2D.velocity = new Vector2();
                transform.parent = col.gameObject.transform;
                transform.localPosition = new Vector3(transform.localPosition.x, 7.0f, transform.localPosition.z);
                rb2D.simulated = false;
            }
        }
        // Hit the bottom
        else if (col.gameObject.name == "border_bottom")
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            pause = Camera.main.GetComponent<Pause>();
            pause.BroadcastMessage("GameOver");
        }
        // Hit the Block
        else if (block = col.gameObject.GetComponent<Block>())
        {
            block.DestroyBlock();
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // -1  -0.5  0  0.5  1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth * 2;
    }

    public void BallStart()
    {
        //sticky = false;
        rb2D.simulated = true;
        racket = transform.parent.gameObject;
        transform.parent = null;

        // Calculate hit Factor
        float x = HitFactor(transform.position,
                          racket.transform.position,
                          racket.GetComponent<BoxCollider2D>().size.x);

        // Calculate direction, set length to 1
        Vector2 dir = new Vector2(x + racket.GetComponent<Rigidbody2D>().velocity.x / 300, 1).normalized;

        // Set Velocity with dir * speed
        rb2D.velocity = dir * speed;
    }
}
