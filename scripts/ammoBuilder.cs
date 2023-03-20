using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBuilder : MonoBehaviour
{
    [SerializeField] private Text ammobuilderOnOff;
    [SerializeField] private Button ammoButtonOnOff;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        //weil er am anfang nicht zwischen hellgrün und grün unterscheiden kann
        ammoButtonOnOff.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        text = ammobuilderOnOff.GetComponent<Text>();
        string text1 = text.text;
        ammoButtonOnOff.onClick.AddListener(delegate { change(text1); });
        
    }
    void change(string t)
    {
        if (t == "Ammo Builder ON")
        {
            ammoButtonOnOff.GetComponent<Image>().color = Color.red;
            ammobuilderOnOff.text = "Ammo Builder OFF";

        }

        else if (t == "Ammo Builder OFF")
        {
            ammoButtonOnOff.GetComponent<Image>().color = Color.green;
            ammobuilderOnOff.text = "Ammo Builder ON";

        }
    }
}
