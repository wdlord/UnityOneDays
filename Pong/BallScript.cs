using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D R2D;
    [SerializeField] float ballSpeed = 5.0f;


    public delegate void Scored(string s);
    public static event Scored ScorePoint;

    // Start is called before the first frame update
    void Start()
    {
        R2D = gameObject.GetComponent<Rigidbody2D>();
        SetInitialDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
        {
            R2D.velocity = new Vector2(R2D.velocity.x, -R2D.velocity.y);
        }
        else if (collision.tag == "goal")
        {
            StartCoroutine(ResetBall());

            // trigger the score event
            if (ScorePoint != null)
            {
                if (collision.gameObject.transform.position.x > 5) ScorePoint("left");
                else ScorePoint("right");
            }
        }
        else R2D.velocity = new Vector2(-R2D.velocity.x, R2D.velocity.y);
    }

    void SetInitialDirection()
    {
        if (Random.Range(0, 1) == 1) ballSpeed = -ballSpeed;
        float ballY = Random.Range(-2f, 2f);
        R2D.AddForce(new Vector2(ballSpeed, ballY), ForceMode2D.Impulse);
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(1f);

        gameObject.transform.position = Vector3.zero;
        R2D.velocity = Vector2.zero;

        yield return new WaitForSeconds(1f);

        SetInitialDirection();
    }
}
