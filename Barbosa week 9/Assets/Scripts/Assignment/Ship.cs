using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private List<ContactPoint2D> contacts = new List<ContactPoint2D>();
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.GetContacts(contacts);
        if (contacts.Count > 2)
        {
            Debug.Log("Ship is filled now");
        }

    }
}
