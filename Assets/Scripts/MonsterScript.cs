using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody physics component
    Animator anim; // Animator component

    public string target1tag = "Player1";
    public string target2tag = "Player2";
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the target object with the tag Player1
        GameObject targetObject1 = GameObject.FindWithTag("Player1");

        // Get the target object with the tag Player2
        GameObject targetObject2 = GameObject.FindWithTag("Player2");

        if (targetObject1 != null && targetObject2 != null)
        {
            // Get its Rigidbody component so can get its position
            Rigidbody2D targetRb1 = targetObject1.GetComponent<Rigidbody2D>();

            // Get difference between current and target1 location 
            Vector2 delta1 = targetRb1.position - rb.position;

            // Get its Rigidbody component so can get its position
            Rigidbody2D targetRb2 = targetObject2.GetComponent<Rigidbody2D>();

            // Get difference between current and target2 location
            Vector2 delta2 = targetRb2.position - rb.position;

            if (delta1.magnitude < delta2.magnitude)
            {
                // Normalize so that magnitude = 1
                delta1.Normalize();

                // Multiply be speed
                delta1 = delta1 * speed;

                // Use this to change position
                rb.position += delta1;
            }
            else if (delta1.magnitude > delta2.magnitude)
            {
                // Normalize so that magnitude = 1
                delta2.Normalize();

                // Multiply be speed
                delta2 = delta2 * speed;

                // Use this to change position
                rb.position += delta2;
            }
        }
        else if (targetObject1 == null && targetObject2 != null)
        {
            // Get its Rigidbody component so can get its position
            Rigidbody2D targetRb2 = targetObject2.GetComponent<Rigidbody2D>();

            // Get difference between current and target2 location
            Vector2 delta2 = targetRb2.position - rb.position;

            // Normalize so that magnitude = 1
            delta2.Normalize();

            // Multiply be speed
            delta2 = delta2 * speed;

            // Use this to change position
            rb.position += delta2;
        } 
        else if (targetObject1 != null && targetObject2 == null)
        {
            // Get its Rigidbody component so can get its position
            Rigidbody2D targetRb1 = targetObject1.GetComponent<Rigidbody2D>();

            // Get difference between current and target1 location 
            Vector2 delta1 = targetRb1.position - rb.position;

            // Normalize so that magnitude = 1
            delta1.Normalize();

            // Multiply be speed
            delta1 = delta1 * speed;

            // Use this to change position
            rb.position += delta1;
        }
    }
}
