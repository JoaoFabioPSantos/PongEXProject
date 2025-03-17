using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public float speedUp = 1.1f;

    [Header("Game Manager")]
    public GameManager gameManager;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitWall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if(collision.gameObject.CompareTag("LeftPlayer") || collision.gameObject.CompareTag("RightPlayer"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }


        if (collision.gameObject.CompareTag("RightWallPlayer"))
        {
            gameManager.ScorePlayerLeft();
            ResetBall();

        }

        else if (collision.gameObject.CompareTag("LeftWallPlayer"))
        {
            gameManager.ScorePlayerRight();
            ResetBall();
        }
    }
}
