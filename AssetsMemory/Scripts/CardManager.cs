using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : Singleton<CardManager>
{
    public float boardWidth = 4;
    public float boardHeight = 4;
    public float screenWidth = 1080;
    public float screeHeight = 1920;
    float columnas;
    float filas;
    public float margin;
    public bool gameWin = false;
    public bool gameLose = false;
    public bool gameEnd = false;

    public List<GameObject> ListSelectedCards;
    public List<GameObject> ListCopy;
    public List<GameObject> ListOnGame;
    [SerializeField] List<Sprite> m_Items;
    StatesManager statesManager;

    public GameObject card;
    float newPosX;
    float newPosY;

    // public Card cardImages;
    // public GameObject cartaPrueba;
    public bool verifyCardEvent = false;
    private List<Card> m_Cards;
    private Dictionary<int, Card> m_SelectedCards;
    private Dictionary<int, Card> m_MatchedCards;
    [SerializeField] CardTimer cardTimer;
    [SerializeField] TriesManager m_TriesManager;
    AudioCardMemory audioCardMemory;

    public bool UserInteractedWithCard;


    // public bool m_IsPaused {
    //     get
    //     {
    //         return m_IsPaused;
    //     }
    //     set 
    //     {
    //         cardTimer.IsPaused = value;
    //         m_IsPaused = value;
    //     }

    // }



    void Start()
    {
        statesManager = FindObjectOfType<StatesManager>();
        cardTimer = FindObjectOfType<CardTimer>();
        audioCardMemory = FindObjectOfType<AudioCardMemory>();
        RectTransform CardRectTransform = card.GetComponent<RectTransform>();
        columnas = CardRectTransform.sizeDelta.x;
        filas = CardRectTransform.sizeDelta.y;
        gameWin = false;
        gameLose = false;
        gameEnd = false;
        ListCopy = new List<GameObject>();
        // CameraPosition();}
        Debug.Log("empezo el start");
        ListCopy = DuplicateCards(ListSelectedCards, ListCopy);
        ListOnGame = new List<GameObject>(ListCopy);
        // CreateBoard();
        // statesManager = FindObjectOfType<StatesManager>;
        SetupCards();
        audioCardMemory.InicioGame();
    }
    public bool getCardEvent()
    {
        return verifyCardEvent;
    }
    public bool SetCardEvent(bool cardEvent)
    {
        verifyCardEvent = cardEvent;
        return verifyCardEvent;

    }
    void SetupCards()
    {
        int cartas = 6;
        List<int> ids = new List<int>();

        for(int x = 0; x < cartas; x++)
        {
            while(true)
            {
                int id = Random.Range(0, m_Items.Count);
                if(!ids.Contains(id))
                {
                    ids.Add(id);
                    ids.Add(id);
                    break;
                }
            }
        }
        // Debug.Log(m_Items.Count);
        ids = Shuffle(ids);
        // for (int j = 0; j < ids.Count; j++)
        // {
        //     int componenete = ids[j] + 1;
        //     Debug.Log("vuelta numero  "+ j);
        //     Debug.Log(componenete);
        // }
        m_Cards = new List<Card>();
        m_SelectedCards = new Dictionary<int, Card>();
        m_MatchedCards = new Dictionary<int, Card>();
        int codigo = 0;

        for (int i = 0; i < boardWidth; i++)
        {

            for (int j = 0; j < boardHeight; j++)
            {
                float coordX = (i * (columnas * 1.05f)) + (1080 / 2) + ((boardWidth / 2) * -(columnas));
                float coordY = (j * (filas * 1.05f)) + (1920 / 2) + ((boardHeight / 2) * -(filas));

                //creamos una nueva carta de forma random de la lista de 16 scriptable cards disponibles
                var cardObject = ids[j];
                GameObject newCards = Instantiate(card, new Vector3(coordX, coordY, -4), Quaternion.identity);
                Card cardObj = newCards.GetComponent<Card>();
                // Debug.Log("el codigo del id posicion "+ j + "es " );
                cardObj.Setup(codigo,ids[codigo], m_Items[ids[codigo]]);
                codigo++;
                m_Cards.Add(cardObj);
                // ListCopy.Remove(cardObject);
                newCards.transform.SetParent(this.transform);
            }

        }
    }

    public List<GameObject> DuplicateCards(List<GameObject> lista, List<GameObject> listToCopy)
    {

        for( int i = 0; i < lista.Count; i++)
        {
            listToCopy.Add(lista[i]);
            listToCopy.Add(lista[i]);
        }
        return listToCopy;

    }


    void CameraPosition()
    {
        newPosX = screenWidth / 2;
        newPosY = screeHeight / 2;
        Camera.main.transform.position = new Vector3(newPosX - 50, newPosY - 50, -10);
        margin = 550;
    }
  public void SelectedCard(int childid)
    {
        // If the game is paused, then prevent the cards from doing anything e.g animating 
        // if(m_IsPaused)
        // {
        //     Debug.Log("Game is paused, user cannot do anything, until the game is unpaused");
        //     return;
        // }

        // Used in conjunction with gamescreen.cs to determine whether not the game should show, are sure popup
        if(!UserInteractedWithCard)
        {
            UserInteractedWithCard = true;
        }

        Card currentCard = m_Cards[childid];


        if (m_SelectedCards.Count == 2)
        {

            foreach(KeyValuePair<int, Card> card in m_SelectedCards)
            {
                if(!m_MatchedCards.ContainsKey(card.Key))
                {
                    card.Value.HideCard();
                }
            }

            m_SelectedCards = new Dictionary<int, Card>();
        }

        if(m_MatchedCards.Count > 0)
        {
            foreach(KeyValuePair<int, Card> card in m_MatchedCards)
            {
                if(childid == card.Key)
                {
                    Debug.Log("Card already exists in 'matched' stack - user has selected card that is already showing and 'matched'");
                    return;
                }
            }
        }

        currentCard.ShowCard();
        // m_DisplayCardName.Show(currentCard.Sprite.name);
        // SoundManager.Instance.Play_CardPlaced();

        // first card, show no need to do any matching algorithm
        if (m_SelectedCards.Count == 0)
        {
            m_SelectedCards.Add(childid, currentCard);
            return;
        }

     
        if(m_SelectedCards.ContainsKey(childid))
        {
            Debug.Log("Card already exists in selected stack - user has selected card that is already showing");
            return;
        }


        // add to selected cards
        if(m_SelectedCards.Count < 2)
        {
            m_SelectedCards.Add(childid, currentCard);
        }


        // check for a match
        if(m_SelectedCards.Count == 2)
        {

            bool matched = false;
            int? pairId = null;

            foreach (KeyValuePair<int, Card> card in m_SelectedCards)
            {
                if (pairId == null)
                    pairId = card.Value.PairId;
                else if (pairId == card.Value.PairId)
                    matched = true;
                else
                {
                    Debug.Log("More than on item in list did not match");
                    matched = false;
                }
            }

            if(matched)
            {
                foreach(KeyValuePair<int, Card> card in m_SelectedCards)
                {
                    m_MatchedCards.Add(card.Key, card.Value);
                }

                CardsMatched();

                CheckGameOver();
            }
            else
            {
                CardsDidNotMatch();
            }

            // m_TriesManager.UserTried();

            return;
        }
    }

    /// <summary>
    /// Restarts level to defaultgrid
    /// </summary>

        private List<int> Shuffle(List<int> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }

        return ts;
    }
     private void CardsMatched()
    {
        Debug.Log("Two cards matched!");
        audioCardMemory.MatchCard();
        // SoundManager.Instance.Play_CardsMatched();
    }

    private void CardsDidNotMatch()
    {
        // audioCardMemory.MissCard();
        // audioCardMemory.FlipCard2();
        // audioCardMemory.FlipCard2();
        Debug.Log("Cards did not match");
    }
     private void CheckGameOver()
    {
        // colocar las opciones si ganaste o perdiste para poder colocar los audios
        if(m_MatchedCards.Count == m_Cards.Count)
        {
            cardTimer.gameObject.SetActive(false);
            cardTimer.StopTimer();
            gameLose = false;
            statesManager.gameLose = gameLose;
            GameWin();
        }
    }

    private void GameWin()
    {
        Debug.Log("Ganaste el juego");
        gameEnd = true;

        // GridUnlockManager.Instance.CompletedCurrentLevel();
      
        // m_Timer.StopTimer();

        // ScoreManager.Instance.UserScored(GridConfigManager.Instance.SelectedGridSize, m_TriesManager.Tries, m_Timer.TotalTimeInSeconds);

        // StartCoroutine(Delay(.5f, () =>
        // {
        //     ScreenManager.Instance.ChangeScreen(Screen.EndGame);
        // }));
    }

}