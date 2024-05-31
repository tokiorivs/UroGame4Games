using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;// se enlaza la informacion del question donde se encuentra las preguntas y las respuestas
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();//creamos una lista de nuestras preguntas, almacenamos los objetos
    int totalQuestion;
    QuestionSO currentQuestion; //se crea una variable de tipo questioSO

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons; //se crea un gameobject para enlazar con los prefabs de las preguntas
    int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite CorrectAnswerSprite;
    [SerializeField] Sprite IncorrecAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] float timeBetweenQuestions = 10f;


    bool gameOverState;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    public bool gameOver = false;
    public bool isComplete;
    public int questionLenght;
    AudioQuiz audioQuiz; 

    void Start()
    {
        timer = FindObjectOfType<Timer>();//enlazamo el bojeto
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        GetNextQuestion();
        gameOverState = timer.GetGameOverState();
        GetQuestionsListLength();
        audioQuiz = FindObjectOfType<AudioQuiz>();
        
    }
   void Update()
    {
        GameVerify();
    
    }
    void GameVerify() 
    {
        if(timer.GetGameOverState())
        {
            gameOver = true;
        }
        else if(questions.Count <= 0)
        {
            Debug.Log("ya no hay mas preguntassssssssss");
            gameOver = true;
        }
    }
    public bool GetGameOver()
    {
        return gameOver;
    }

    public void OnAnswerSelected(int index)
    {
        StartCoroutine(AnswerSelectedCoroutine(index));
    }
    IEnumerator AnswerSelectedCoroutine(int index)
    {
        DisplayAnswer(index);
        SetButtonState(false);
        yield return new WaitForSeconds(timeBetweenQuestions);

        GetNextQuestion();
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
        if (index == correctAnswerIndex)
        {
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = CorrectAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
            Debug.Log("respondiste bien");
            audioQuiz.MatchSfx();
            
        }
        else
        {
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = IncorrecAnswerSprite;
            Debug.Log("respondiste mal");
            audioQuiz.MissSfx();
        }

    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);//activamos los botones
            SetDefaultButtonSprites();//reiniciamos los sprites
            GetRandomQuestion();//obtnemos una pregunta random y retiramos de la lista la pregunta que obtuvimos
            DisplayQuestion();//la pregunta y sus opciones las desplegamos en el juego
            // scoreKeeper.IncrementQuestionsSeen();
        }

    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswers(i);
        }
    }
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }

    }
    void SetDefaultButtonSprites()
    {
        Image buttonImage;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    public void GetQuestionsListLength()
    {
        questionLenght = questions.Count;

    }
}
