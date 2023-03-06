using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode jumpInput;
    public KeyCode leftInput;
    public KeyCode rightInput;

    public Rigidbody2D rb;

    public bool isOnGround;

    public float moveSpeed;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        if (!Input.GetKey(leftInput) || !Input.GetKey(rightInput))
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetKey(jumpInput) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isOnGround = false;
        }

        //Left and right
        if (Input.GetKey(leftInput))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(rightInput))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ensure player can't double bounce off corners
        if ((collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player")) && rb.velocity.y <= 1)
        {
            isOnGround = true;
        }
    }
}
