using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private ForceMode2D forcemode;
    [SerializeField] private float groundCheckDistance = 5f;
    [SerializeField] private LayerMask jumpLayerMask;

    private bool isGrounded= false;
    // Start is called before the first frame update
    void Start()
    {
        if ( body== null)
        {
            body = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.down,groundCheckDistance,jumpLayerMask);
        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance * 1000, Color.red);

        if(isGrounded = hitInfo.collider !=null)
        {
            //print(hitInfo.collider.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            isGrounded = true;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector2.up * jumpForce, forcemode);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Started contatact with" + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Still in contatact with" + collision.gameObject.name);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Ended contatact with" + collision.gameObject.name);

    }
}
