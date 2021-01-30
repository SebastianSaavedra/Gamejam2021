using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPMovement : MonoBehaviour
{
    public float speed;
    public float force;
    Rigidbody2D rb2d;
    [SerializeField] Collider2D detector;
    [SerializeField] bool canJump;
    public static bool canMove;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && canJump) 
        {
            Jump();
        }
    }

    void Movement() 
    {
        if (canMove) 
        {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime* speed;
        transform.Translate(x,0,0);
        }
    }


    void Jump() 
    {
        rb2d.velocity= Vector3.up*force;
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Piso"))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
}
