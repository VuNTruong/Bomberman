using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultScreenButtons : MonoBehaviour
{
    // Play game button
    public Button playAgainButton;

    // Instruction button
    public Button backToMenuButton;

    // Animator of the Scene Switcher
    Animator anim;

    // boolean value to check if the scence is switching or not
    bool isSwitchingPlayAgain = false;
    bool isSwitchingBackToMenu = false;

    // Number of frame to wait until the animation is done
    int numOfFrameToWait = 150;

    // AudioSource to play sound when the button clicked
    public AudioSource buttonClickSound;

    void Start()
    {
        // Get the Animator of the object
        anim = GetComponent<Animator>();

        // Set the initial animation to fade in
        anim.SetBool("fadeout", false);

        Button playAgain = playAgainButton.GetComponent<Button>();
        playAgain.onClick.AddListener(TaskOnClickPlayAgain);

        Button backToMenu = backToMenuButton.GetComponent<Button>();
        backToMenu.onClick.AddListener(TaskOnClickBackToMenu);
    }

    void Update()
    {
        if (isSwitchingPlayAgain)
        {
            // Decrease the number of wait frame by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        if (isSwitchingBackToMenu)
        {
            // Decrease the number of wait frame by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void TaskOnClickPlayAgain()
    {
        // Play the button click sound
        buttonClickSound.Play();

        // Set the animation to fade out
        anim.SetBool("fadeout", true);

        // Start switching scene
        isSwitchingPlayAgain = true;
    }

    void TaskOnClickBackToMenu()
    {
        // Play the button click sound
        buttonClickSound.Play();

        // Set the animation to fade out
        anim.SetBool("fadeout", true);

        // Start switching scene
        isSwitchingBackToMenu = true;
    }
}