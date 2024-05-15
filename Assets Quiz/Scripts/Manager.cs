using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] Quiz quiz;
    [SerializeField] EndQuiz endQuiz;
    // [SerializeField] MainMenu mainMenu;
    bool gameOver;

    void Start()
    {
        quiz.gameObject.SetActive(true);
        endQuiz.gameObject.SetActive(false);

    }

    void Update()
    {
        if (quiz.gameOver) 
        {
            quiz.gameObject.SetActive(false);
            endQuiz.gameObject.SetActive(true);
            Debug.Log("Game Over! Switching to EndQuiz scene"); // More descriptive message
        }
    }
}
