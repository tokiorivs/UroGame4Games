using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
    }
    public void HomeMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(3);
    }
}
