using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    float correctAnswers = 0;
    float scorePercentil = 0;
    [SerializeField] Quiz quiz;

    public float GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }
    
    public float  ScorePercentil()
    {
        float questionLenght = quiz.questionLenght + 1;
        scorePercentil = correctAnswers / questionLenght * 100;
        return scorePercentil;     
    }

}
