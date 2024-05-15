using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionLenght;
    int scorePercentil = 0;
    Quiz quiz;

    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        // questionLenght = quiz.GetQuestionsListLength();
    }

    void Update()
    {
    }


    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }
    public string CalculateLevel()
    {
        string level = "";

        switch (correctAnswers)
        {
            case int n when n >= 0 && n <= 5:
                level = "Felicidades, eres madera!";
                break;
            case int n when n >= 6 && n <= 10:
                level = "Felicidades, tu puntaje es plata!";
                break;
            case int n when n >= 11 && n <= 15:
                level = "Felicidades, tu puntaje es oro!";
                break;
            default:
                level = "Tu puntaje no se encuentra dentro de los rangos evaluados.";
                break;
        }

        return level;
    }
    public int  ScorePercentil()
    {

        if (questionLenght > 0)
        {
            scorePercentil = (int)((correctAnswers * 100f) / questionLenght);
        }
        else
        {
            // Handle the case where there are no questions (e.g., set scorePercentil to 0 or some default value)
            scorePercentil = (int)0f;  // Example: Set scorePercentil to 0 if no questions
        }
        // Debug.Log("el puntaje en % es: " + scorePercentil);
        return scorePercentil;
    }

}
