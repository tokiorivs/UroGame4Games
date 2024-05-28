using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
  
    [SerializeField] Button s_Button;

    [SerializeField] Image s_Image;

    [SerializeField] float s_Speed = 25f;

    private Quaternion s_Target;

    private bool s_Hidden;
    private bool s_Animate = false;

    public int ChildId { get; private set; }
    public int PairId { get; private set; }

    public Sprite Sprite
    {
        get
        {
            return s_Image.sprite;
        }
    }


    public void Setup(int childid,int pairid, Sprite sprite)
    {
        ChildId = childid;
        PairId = pairid;

        s_Image.sprite = sprite;

        s_Button.onClick.RemoveAllListeners();
        s_Button.onClick.AddListener(() =>
        {
            CardManager.Instance.SelectedCard(childid);
            Debug.Log("me eligieron XS");
        });

    }

    private void Start()
    {
        s_Hidden = true;
    }

    private void Update()
    {
        if(s_Animate)
        {
            AnimateCard();
        }
    }

    public void ShowCard()
    {
        s_Target = Quaternion.Euler(180, 0, 0);

        s_Animate = true;
    }
   
    public void HideCard()
    {
        s_Target = Quaternion.Euler(0, 0, 0);

        s_Animate = true;
    }

    private void AnimateCard()
    {
        s_Button.transform.rotation = Quaternion.RotateTowards(s_Button.transform.rotation, s_Target, s_Speed);

        if (Quaternion.Angle(s_Button.transform.rotation, s_Target) <= 0.01f)
        {
            s_Button.transform.rotation = s_Target;

            s_Animate = false;
        }
    } 
}
