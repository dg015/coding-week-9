using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Vector2 mouseLocation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(GetComponent<Rigidbody2D>().OverlapPoint(mouseLocation))
        {
            spriteRenderer.color = Color.red;
            Debug.Log("Pressing the button");

        }
        else
        {
            spriteRenderer.color = Color.green;
        }
    }
}
