using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add to the Create menu 
[CreateAssetMenu(menuName = "ScoreManagerPlayer2")]

// This is the instance of ScriptableObject
public class ScoreManagerPlayer2 : ScriptableObject
{
    int score = 0;

    // Method to allow other script to increment the score
    public void incrementScore(int scoreToIncrement)
    {
        score += scoreToIncrement;
    }

    // Method to allow other script to decrement the score
    public void decrementScore(int scoreToDecrement)
    {
        score -= scoreToDecrement;
    }

    // Method to get the current number of score
    public int getScore()
    {
        return score;
    }

    // Method to set the number of score
    public void setScore(int score)
    {
        this.score = score;
    }
}
