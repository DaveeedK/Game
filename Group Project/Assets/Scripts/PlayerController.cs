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

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.y);

        //Jump
        if (Input.GetKey(jumpInput) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            isOnGround = false;
        }

        //Left and right
        if (Input.GetKey(leftInput))
        {
            transform.position -= moveVector;
        }

        if (Input.GetKey(rightInput))
        {
            transform.position += moveVector;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && rb.velocity.y <= 1)
        {
            isOnGround = true;
        }
    }
}
