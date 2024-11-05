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
        Debug.DrawRay(transform.position, Vector3.right * 1000, Color.red);

        if(hitInfo.collider !=null)
        {
            print(hitInfo.collider.name);
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
        }
        if (Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector2.up * jumpForce, forcemode);
        }
    }


}
