using UnityEngine;

public class Attribut : MonoBehaviour
{
    [SerializeField] public int bulletdmg;

    //Für die Munition die man auf der map findet
    [SerializeField] public int xpValue;

    //npc
    [SerializeField] public int blueAmmoSlider = 100;
    [SerializeField] public int blueAmmoSliderMax = 100;
    [SerializeField] public int redAmmoSlider = 100;
    [SerializeField] public int redAmmoSliderMax = 100;
    [SerializeField] public int yellowAmmoSlider = 100;
    [SerializeField] public int yellowAmmoSliderMax = 100;
    [SerializeField] public int purpleAmmoSlider = 100;
    [SerializeField] public int purpleAmmoSliderMax = 100;
    [SerializeField] public bool ammoButtonOnOff;

    private void Start()
    {
        string gameMode = PlayerPrefs.GetString("GameDifficulty", "");
        if (gameMode == "Easy")
        {
           // Debug.Log("easipeasi");
            blueAmmoSlider = blueAmmoSlider * 1;
            blueAmmoSliderMax = blueAmmoSliderMax * 1;
            redAmmoSlider = redAmmoSlider * 1;
            redAmmoSliderMax = redAmmoSliderMax * 1;
            yellowAmmoSlider = yellowAmmoSlider * 1;
            yellowAmmoSliderMax = yellowAmmoSliderMax * 1;
            bulletdmg = 100;

        }
        else if (gameMode == "Normal")
        {
           // Debug.Log("noooorm");
            blueAmmoSlider += 50;
            blueAmmoSliderMax += 50;
            redAmmoSlider += 50;
            redAmmoSliderMax += 50;
            yellowAmmoSlider += 50;
            yellowAmmoSliderMax += 50;

        }
        else if (gameMode == "Hard")
        {
           // Debug.Log("h");
            blueAmmoSlider += 150;
            blueAmmoSliderMax += 150;
            redAmmoSlider += 150;
            redAmmoSliderMax += 150;
            yellowAmmoSlider += 150;
            yellowAmmoSliderMax += 150;

        }
        else if (gameMode == "Asian")
        {
           // Debug.Log("a");
            blueAmmoSlider += 400;
            blueAmmoSliderMax += 400;
            redAmmoSlider += 400;
            redAmmoSliderMax += 400;
            yellowAmmoSlider += 400;
            yellowAmmoSliderMax += 400;

        }
    }

}
