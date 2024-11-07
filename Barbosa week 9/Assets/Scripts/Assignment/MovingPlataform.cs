using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private bool whichPoint;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sleepMode = RigidbodySleepMode2D.StartAwake;
        whichPoint = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(whichPoint)
        {
            transform.Translate((transform.position - pointB.position).normalized * Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, pointA.position) < 0.1f) 
            {
                
                whichPoint = false;
            }
        }
        else
        {
           
            transform.Translate((transform.position - pointA.position).normalized * Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, pointB.position) < 0.1f) 
            {
                whichPoint = true;
            }
        }
        


    }
}
