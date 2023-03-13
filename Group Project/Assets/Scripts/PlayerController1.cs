using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private KeyCode jumpInput = KeyCode.W;
    private KeyCode leftInput = KeyCode.A;
    private KeyCode rightInput = KeyCode.D;

    private Player1Dash dashScript;

    public Rigidbody2D rb;

    public bool isJumping;

    public float moveSpeed;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        dashScript = GetComponent<Player1Dash>();
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

        if (Input.GetKey(jumpInput) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
        }

        //Left and right
        if (Input.GetKey(leftInput))
        {
            rb.velocity = new Vector2(-moveSpeed * dashScript.dashingMultiplier, rb.velocity.y);
        }

        if (Input.GetKey(rightInput))
        {
            rb.velocity = new Vector2(moveSpeed * dashScript.dashingMultiplier, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ensure player can't double bounce off corners
        if ((collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Player")))
        {
            isJumping = false;
        }
    }
}
