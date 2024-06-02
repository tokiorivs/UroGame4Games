using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Time;

public class CardTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TimerT;
    public bool IsPaused = false;

    public float TotalTimeInSeconds; 
    public bool m_Count = false;
    CardManager cardManager;
    StatesManager statesManager;
    AudioCardMemory audioCardMemory;
    private void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        statesManager = FindObjectOfType<StatesManager>();
        audioCardMemory = FindObjectOfType<AudioCardMemory>();
        StartTimer();
    }

    private void Update()
    {
        if(m_Count && !IsPaused)
        {
            TotalTimeInSeconds -= Time.deltaTime;
            UpdateTimer(TotalTimeInSeconds);
        }
        if (TotalTimeInSeconds <= 0f)
        {
            statesManager.gameLose = true;
            cardManager.gameEnd = true;
            this.gameObject.SetActive(false);

            StopTimer();
        }
      
    }
    public void StartTimer()
    {
        m_Count = true;
    }
    public void StopTimer()
    {
        m_Count = false;
    }
    public void ResetTimer()
    {
        TotalTimeInSeconds = 0;
    }
    private void UpdateTimer(float totalSeconds)
    {
        string minutes = Mathf.Floor(totalSeconds / 60).ToString();
        string seconds = Mathf.Floor(totalSeconds % 60).ToString("00");
        m_TimerT.text = string.Format("{0}:{1}", minutes, seconds);
    }


}
