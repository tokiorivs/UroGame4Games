using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Time;

public class CardTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TimerT;
    public bool IsPaused = false;

    public float TotalTimeInSeconds {get; private set;} =0; 
    private bool m_Count = false;

    private void Update()
    {
        if(m_Count && !IsPaused)
        {
            TotalTimeInSeconds += Time.deltaTime;
            UpdateTimer(TotalTimeInSeconds);
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
        m_TimerT.text = "Time " + string.Format("{0}:{1}", minutes, seconds);
    }


}
