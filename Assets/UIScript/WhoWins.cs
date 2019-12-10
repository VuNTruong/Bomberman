using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoWins : MonoBehaviour
{
    // Public access to LiveManager Component of player 1
    public LivesManager liveManagerPlayer1;

    // Public access to LiveManager Component of player 2
    public LivesManagerPlayer2 liveManagerPlayer2;

    // Text component of the object
    Text status;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Text component of the object
        status = GetComponent<Text>();

        // If player 1 dies first, player 2 wins
        if (liveManagerPlayer1.getLives() <= 0)
        {
            status.text = "Player 2 wins";
        }    

        // If player 2 dies first, player 1 wins
        if (liveManagerPlayer2.getLives() <= 0)
        {
            status.text = "Player 1 wins";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
