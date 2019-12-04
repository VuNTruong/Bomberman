using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Simple demonstration of scene management. 
// We assume this script is attached to an object in some opening "splash screen" scene,
// and the user has been prompted to press the "s" key to start the game.
public class SwitchScene : MonoBehaviour
{
    // Number of frame to stay in splash screen
    public int numOfFrame = 50;

    // Animation component of the object
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("fadeout", false);
    }

    // Update is called once per frame
    void Update()
    {
        numOfFrame -= 1;

        if (numOfFrame == 0)
        { 
            anim.SetBool("fadeout", true);
        }
    }
}
