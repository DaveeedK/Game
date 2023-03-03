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
        //Jump
      
    }

    private void FixedUpdate()
    {
        /*if (!Input.anyKey)
        {
            rb.velocity;
        }*/
        if (Input.GetKey(jumpInput) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isOnGround = false;
        }

        //Left and right
        if (Input.GetKey(leftInput))
        {
            rb.AddForce(Vector3.left * moveSpeed);
            //transform.position -= moveVector;
        }

        if (Input.GetKey(rightInput))
        {
            rb.AddForce(Vector3.right * moveSpeed);
            //transform.position += moveVector;
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
