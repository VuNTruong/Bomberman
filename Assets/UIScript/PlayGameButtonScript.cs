using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGameButtonScript : MonoBehaviour
{
    // Play game button
    public Button playGameButton;

    // Instruction button
    public Button instructionButton;

    // Animator of the Scene Switcher
    Animator anim;

    // boolean value to check if the scence is switching or not
    bool isSwitching = false;
    bool isSwitchingInstruction = false;

    // Number of frame to wait until the animation is done
    int numOfFrameToWait = 150;

    // AudioPlayer component of the object
    AudioSource audioSource;

    // AudioSource to play sound when the button clicked
    public AudioSource buttonClickSound;

    void Start()
    {
        // Get the Animator of the object
        anim = GetComponent<Animator>();

        // Set the initial animation to fade in
        anim.SetBool("fadeout", false);

        // Get the AudioSource component of the object
        audioSource = GetComponent<AudioSource>();

        Button playGame = playGameButton.GetComponent<Button>();
        playGame.onClick.AddListener(TaskOnClick);

        Button instruction = instructionButton.GetComponent<Button>();
        instruction.onClick.AddListener(TaskOnClickShowInstruction);
    }

    void Update()
    {
        if (isSwitching)
        {
            // Decrease the number of wait frame by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(2);

                audioSource.Stop();
            }
        }

        if (isSwitchingInstruction)
        {
            // Decrease the number of wait frame by 1
            numOfFrameToWait -= 1;

            if (numOfFrameToWait == 0)
            {
                SceneManager.LoadScene(4);

                audioSource.Stop();
            }
        }
    }

    void TaskOnClick()
    {
        // Play the button click sound
        buttonClickSound.Play();

        // Set the animation to fade out
        anim.SetBool("fadeout", true);

        // Start switching scene
        isSwitching = true;
    }

    void TaskOnClickShowInstruction()
    {
        // Play the button click sound
        buttonClickSound.Play();

        // Set the animation to fade out
        anim.SetBool("fadeout", true);

        // Start switching scene
        isSwitchingInstruction = true;
    }
}