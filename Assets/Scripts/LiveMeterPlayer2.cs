using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script controls a "meter" that displays a level from 0 to max, controlled by the arrow keys.
// It is attached to an Image object inside a Canvas, that has a sprite attached to it.
public class LiveMeterPlayer2 : MonoBehaviour
{
    int level = 20;
    public int max = 20;      // Max level
    public int redlevel = 2; // level at which the color should change

    // public access to the LivesManager component
    public LivesManagerPlayer2 liveData;

    Image meter; // Image component of this GameObject

    // Start is called before the first frame update
    void Start()
    {
        meter = GetComponent<Image>();

        // Initially, level = 1
        meter.fillAmount = 1;

        // Initially, lives is 20
        level = 20;
        // Also set lives in the LivesManager to 20
        liveData.setLives(20);
    }

    // Update is called once per frame
    void Update()
    {
        level = liveData.getLives();

        // Set the fill level on the Image. This is a value bewteen 0 and 1, so 
        // must divide by the maximum value. The image was set to fill from the left.
        // Since both level and max are int, must cast to float to get correct value.
        meter.fillAmount = (float)level / max;

        // Set the color of the bar based on the level. This is done by setting the
        // color property of the image to some Color value.
        if (level <= redlevel)
        {
            meter.color = Color.red;
        }
        else
        {
            meter.color = Color.green;
        }
    }
}
