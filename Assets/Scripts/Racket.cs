using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Racket : MonoBehaviour {
    
    // Movement Speed
    public float speed = 150;
    public GameObject buttonStart;

    private Rigidbody2D rb2D;
    private BoxCollider2D bc2D;
    private GameObject ballgo;
    private Vector3 ballPos;
    private float horizontal;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        //bc2D.size = new Vector2(transform.position., 1);
        ballgo = transform.GetChild(0).gameObject;
        ballPos = ballgo.transform.localPosition;
    }

    void FixedUpdate() {

        /* COMPUTER VERSION */

        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");
        
        // Set Velocity (movement direction * speed)
        rb2D.velocity = Vector2.right * h * speed;
        /* TELEPHONE VERSION
         * 
        foreach (Touch touch in Input.touches) {
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (touch.position.y - Screen.height / 3 < 0)
            {
                if (touch.position.x - (Screen.width / 2) > 0)
                    horizontal = 1;
                else
                    horizontal = -1;
            }
            // Create a particle if hit
            //if (Physics.Raycast(ray))
                //Instantiate(particle, transform.position, transform.rotation);
            
        }

        if (Input.touchCount == 0)
            horizontal = 0;

        // Set Velocity (movement direction * speed)
        rb2D.velocity = Vector2.right * horizontal * speed;
        */


        if (Input.GetKey(KeyCode.Space) && transform.childCount != 0)
        {
            Ball ball = ballgo.GetComponent<Ball>();
            ball.BallStart();
            buttonStart.SetActive(false);
        }
    }

    /*public void Move(bool goToRight)
    {
        int h = 1;
        if (!goToRight) h = -1;
        rb2D.AddForce(new Vector2(h * speed, 0)); Debug.Log("You have clicked the button!");
    }*/

    public void BallStart() {
        if ( transform.childCount != 0)
        {
            Ball ball = ballgo.GetComponent<Ball>();
            ball.BallStart();
            buttonStart.SetActive(false);
        }
    }

    public void SetLength(int length)
    {
        if (length < 15)
            length = 15;
        else if (length > 75)
            length = 75;
        GetComponent<SpriteRenderer>().size = new Vector2(length, 9);
        bc2D.size = new Vector2(length - 2, 3);
    }

    public int GetLength()
    {
        return (int) GetComponent<SpriteRenderer>().size.x;
    }

    public void StartPosition()
    {
        ballgo.transform.parent = transform;
        ballgo.transform.localPosition = ballPos;
        ballgo.GetComponent<Rigidbody2D>().simulated = false;
        buttonStart.SetActive(true);
        //transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    }
}
