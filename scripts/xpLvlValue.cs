using UnityEngine;
using UnityEngine.UI;

public class xpLvlValue : MonoBehaviour
{
    [SerializeField] private Slider xpBar;
    [SerializeField] private Text xpLvl;
    private int currentXpLvl = 0;

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(xpLvl.text) > currentXpLvl)
        {

            if (int.Parse(xpLvl.text) == 19)
            {
                xpBar.maxValue += 100;
                currentXpLvl = int.Parse(xpLvl.text);
            }
            else
            {
                xpBar.maxValue += 100;
                currentXpLvl = int.Parse(xpLvl.text);
            }
        }
    }
}
