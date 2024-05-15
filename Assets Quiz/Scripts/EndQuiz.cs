using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndQuiz : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI logro;
    [SerializeField] Sprite medals;
    [SerializeField] Sprite bronce;
    [SerializeField] Sprite silver;
    [SerializeField] Sprite gold; 
    int scorePercentil;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ShowFinalScore();
    }
    void Update()
    {
        ShowFinalScore();
        ShowMedals();
    }
    void ShowFinalScore()
    {
        scorePercentil = scoreKeeper.ScorePercentil();
        finalScoreText.text = "FELICITACIONESss RESPONDISTE EL " + scorePercentil + "% de las preguntas";
    }
    void ShowMedals()
    {
        if(scorePercentil <= 35)
        {
            Debug.Log("hola estoy en el score percentil");
            // Image medalImage;
            // medalImage = medals.GetComponent<Image>();
            // medalImage.sprite = bronce;
            // medals.sprite = silver;

        }


    }
}
