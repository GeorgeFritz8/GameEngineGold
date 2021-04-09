using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody2D rb;
    public float jumpForce = 2f;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
             transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
             transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        if (Input.GetKey(KeyCode.A))
        {
             transform.Translate(speed * Time.deltaTime * -1, 0, 0, Space.World);
             transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, 1 * jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
