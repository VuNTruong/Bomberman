using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneFromInstruction1To2 : MonoBehaviour
{
    // Number of frame to wait until the animation is done
    int numOfFrameToWait = 150;

    // Animator component of the object
    Animator anim;

    // Boolean value to check if scene change process has been started or not
    bool sceneChange;
    bool sceneChangeFrom1To2;

    // Start is called before the first frame update
    void Start()
    {
        numOfFrameToWait = 150;

        // Get the Animator component of the object
        anim = GetComponent<Animator>();

        // Ininially, scene change process is false
        sceneChange = false;
        sceneChangeFrom1To2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player press the n key, bring the player to the next page of instruction
        if (Input.GetKeyDown("n"))
        {
            anim.SetBool("fadeout", true);

            // Start changing scene
            sceneChangeFrom1To2 = true;
        }

        // If the player press the e key, bring the player to the main menu
        if (Input.GetKeyDown("e"))
        {
            // Fade out the instruction page
            anim.SetBool("fadeout", true);

            // Start changing scene
            sceneChange = true;
        }

        if (sceneChange)
        {
            // Decrease the number of frame to wait by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (sceneChangeFrom1To2)
        {
            // Decrease the number of frame to wait by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
