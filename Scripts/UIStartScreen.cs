using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    public void StartBtnClicked()
    {
        GameManager.Instance.LevelSelection();
    }

    public void OptionsBtnClicked()
    {
        GameManager.Instance.Options();
    }
}
