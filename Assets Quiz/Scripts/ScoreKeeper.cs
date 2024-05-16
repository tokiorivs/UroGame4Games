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
        Debug.Log("cantidad de preguntas" + questionLenght);
        Debug.Log("cantidad de respuestas correctas" + correctAnswers);
        scorePercentil = correctAnswers / questionLenght * 100;
        Debug.Log("el puntaje en %" + scorePercentil);
        return scorePercentil;     
    }

}
