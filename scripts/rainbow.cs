using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rainbow : MonoBehaviour
{
    [SerializeField] private Image sliderFill;
    [SerializeField] [Range(0f, 10f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int coloIndex = 0;
    float t = 0f;
    
    // Color col = new Color(255f);
    int lenght;


    void Start()
    {
        lenght = myColors.Length;
    }

    
    void Update()
    {
      //  sliderFill = xpBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        sliderFill.color = Color.Lerp(sliderFill.color, myColors[coloIndex], lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            coloIndex++;
            coloIndex = (coloIndex >= lenght) ? 0 : coloIndex; 
        }    
    }
}
