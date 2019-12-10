using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShowingResultPlayer2 : MonoBehaviour
{
    // Text component of the object
    Text score;

    // ScoreManager component of player1
    public ScoreManagerPlayer2 scoreManagerPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the score for player 1
        score.text = scoreManagerPlayer2.getScore().ToString();
    }
}
