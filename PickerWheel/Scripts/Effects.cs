using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Effects : MonoBehaviour
{
   
    //efecto luz de rueda
    [SerializeField] Image borderLights;
    bool borderActive;   

    public void Start()
    {
       StartCoroutine(RoulleteEffect()) ;
    }
    
    IEnumerator RoulleteEffect()
    {
        while(true)
        {
        borderActive = !borderActive;
        borderLights.enabled = borderActive;
        yield return new WaitForSeconds(1);
        }
    } 
}
