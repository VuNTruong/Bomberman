using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEvent : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0.05f;

    // boolean value for right or left walk
    bool leftWalk;
    bool rightWalk;

    // Animator component of the object
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        // Set initial state of the player to idle
        anim.SetBool("walkleft", false);
        anim.SetBool("walkright", false);
    }

    // Update is called once per frame
    void Update()
    {
        // Amount to move in each dimension
        float dx = 0f;
        float dy = 0f;

        // Is w key down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dy = speed;
        }
        // Is s key down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dy = -speed;
        }
        // Is a key down
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dx = -speed;
            anim.SetBool("walkleft", true);
        }
        // Is d key down
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dx = speed;
            anim.SetBool("walkright", true);
        }
        anim.SetBool("walkleft", false);
        anim.SetBool("walkright", false);

        // Use these to change position
        rb.position += new Vector2(dx, dy);
    }
}
