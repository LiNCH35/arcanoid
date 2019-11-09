using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reform : MonoBehaviour {

    public enum Effect {plusSize, minusSize, plusSpeed, minusSpeed, sticky, fire, }

    public Effect effect;

    private Racket racket;
    private Ball ball;

    // Use this for initialization
    void Start () {

        racket = GameObject.FindGameObjectWithTag("Player").GetComponent<Racket>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();

        if (effect == Effect.minusSize || effect == Effect.plusSpeed)
        {
            Sprite sprite = Resources.Load("Sprites/Blocks/block_red", typeof(Sprite)) as Sprite;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            Sprite sprite = Resources.Load("Sprites/Blocks/block_green", typeof(Sprite)) as Sprite;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    public void NewBlock(Vector3 pos)
    {
        int rnd = Random.Range(0, 4);
        switch (rnd) {
            case (0):
                GetComponent<Reform>().effect = Reform.Effect.plusSize;
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Size+";
                break;
            case (1):
                GetComponent<Reform>().effect = Reform.Effect.minusSize;
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Size-";
                break;
            case (2):
                GetComponent<Reform>().effect = Reform.Effect.plusSpeed;
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Speed+";
                break;
            case (3):
                GetComponent<Reform>().effect = Reform.Effect.minusSpeed;
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Speed-";
                break;
        }
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            switch (effect)
            {
                case Effect.minusSize:
                    racket.SetLength(racket.GetLength() - 6);
                    break;
                case Effect.plusSize:
                    racket.SetLength(racket.GetLength() + 6);
                    break;
                case Effect.plusSpeed:
                    if (ball.speed <= 260)
                        ball.speed += 20;
                    break;
                case Effect.minusSpeed:
                    if (ball.speed >= 180)
                        ball.speed -= 20;
                    break;
            }

            GetComponent<Animation>().Play("BlockDisappear");
            Destroy(gameObject, 0.1f);
        }

        if (col.gameObject.name == "border_bottom")
        {
            GetComponent<Animation>().Play("BlockDisappear");
            Destroy(gameObject, 0.1f);
        }

    }
}
