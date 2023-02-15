using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode jumpInput;
    public KeyCode leftInput;
    public KeyCode rightInput;

    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        moveVector = new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKey(jumpInput))
        {
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
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
}
