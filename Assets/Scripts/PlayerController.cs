using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameController gc;
    public float speed;
    public float drag = -0.2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (gc.gameGoing)
        {
            // User Input 
            var x = Input.GetAxis("Horizontal") * speed;
            var y = Input.GetAxis("Vertical") * speed;
            rb.AddForce(new Vector2(x, y));
            rb.AddForce(rb.velocity * drag);

            // Fuel check for input magnitude
            if (new Vector2(x, y).magnitude > 0.1f)
            {
                gc.UsingFuel();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CoinController>() != null)
        {
            // Coin interaction
            gc.ScoreChange(5);
            gc.coins.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
