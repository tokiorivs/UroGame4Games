using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatesManager : MonoBehaviour
{
[SerializeField] CardManager cardManager;
    [SerializeField] EndMemory endMemory;
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        cardManager.gameObject.SetActive(true);
        endMemory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cardManager.gameOver)
        {
            GameOverCards();
        }
        
    }
    public void GameOverCards()
    {
        Debug.Log("me vengo");
        cardManager.gameObject.SetActive(false);
        endMemory.gameObject.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(4);
    }
    public void Saludos()
    {
        Debug.Log("saludo");
    }
}
