using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreCounterPlayer1 : MonoBehaviour
{
    // Link to Score Manager in inspector
    public ScoreManagerPlayer1 scoreData;

    // Text component of the GameObject
    Text scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, set the score to be 0 in the score manager
        scoreData.setScore(0);

        // Get the Text component of this object 
        scoreCount = GetComponent<Text>();

        // Give a start value
        scoreCount.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the score
        scoreCount.text = scoreData.getScore().ToString();
    }
}
