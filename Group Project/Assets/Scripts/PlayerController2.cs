using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private KeyCode jumpInput = KeyCode.UpArrow;
    private KeyCode leftInput = KeyCode.LeftArrow;
    private KeyCode rightInput = KeyCode.RightArrow;

    private Player2Dash dashScript;

    public Rigidbody2D rb;

    public bool isOnGround;

    public float moveSpeed;
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        dashScript = GetComponent<Player2Dash>();
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

        if (Input.GetKey(jumpInput) && isOnGround && rb.velocity.y == 0)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isOnGround = false;
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
            isOnGround = true;
        }
    }
}
