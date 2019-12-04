using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEventPlayer2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component for the object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Amount to move in each dimension
        float dx = 0f;
        float dy = 0f;

        // Is w key down
        if (Input.GetKey("w"))
        {
            dy = speed;
        }
        // Is s key down
        if (Input.GetKey("s"))
        {
            dy = -speed;
        }
        // Is a key down
        if (Input.GetKey("a"))
        {
            dx = -speed;
        }
        // Is d key down
        if (Input.GetKey("d"))
        {
            dx = speed;
        }

        // Use these to change position
        rb.position += new Vector2(dx, dy);
    }
}
