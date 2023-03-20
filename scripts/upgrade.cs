using UnityEngine;
using UnityEngine.UI;

public class upgrade : MonoBehaviour
{
    //Um skillpunkte zu erweitern
    [SerializeField] private Image[] shieldLvl;
    [SerializeField] private Image[] attackLvl;
    [SerializeField] private Image[] speedLvl;
    [SerializeField] private Button[] upgradeButtons;
    [SerializeField] private Text xpLvl;
    private int upgradePoints = 0;
    private int upgradePointsUsed = 0;
    private bool stoppschleife = false;
    //um anhand der skillpunkte die werte zu verändern z.b atk.
    [SerializeField] private GameObject playerBullet;
    [SerializeField] private Slider sliderPlayerShield;
    [SerializeField] private GameObject player;
    private float movSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //schalte beim start die upgradepunkte auf invisible weil lvl = 0
        for (int i = 0; i < shieldLvl.Length; i++)
        {
            shieldLvl[i].enabled = false;
        }
        for (int i = 0; i < attackLvl.Length; i++)
        {
            attackLvl[i].enabled = false;
        }
        for (int i = 0; i < speedLvl.Length; i++)
        {
            speedLvl[i].enabled = false;
        }
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].image.enabled = false;
            upgradeButtons[i].transform.Find("Text").GetComponent<Text>().enabled = false;
        }

        //startdmg von Spieler schuss, befindet sich hier weil es in "attribut" nicht geht und das objekt noch nicht existiert
        //ohne das: wert wird geändert und er wechselt nicht zum original zurück, wenn das game startet
        playerBullet.GetComponent<Attribut>().bulletdmg = 5;

    }


    private void Update()
    {

        if (int.Parse(xpLvl.text) >= (upgradePoints + upgradePointsUsed))//Spielerlvl größer als benutze oder noch nicht benutze lvlpunkte?
        {
            upgradePoints += int.Parse(xpLvl.text) - (upgradePoints + upgradePointsUsed);
          
            //upgrade buttons visible?
            for (int i = 0; i < upgradeButtons.Length; i++)
            {
                if (upgradePoints > 0)//wegen >=, 1-1 2-2 etc muss trodzdem funktionieren 
                {
                    upgradeButtons[i].image.enabled = true; //um button erscheinen zu lassen
                  //upgradeButtons[i].transform.Find("Text").GetComponent<Text>().enabled = true; //um + beim btn ersch. zulassen

                    if (upgradeButtons[i].name == "ButtonShield+")//um +20 beim btn ersch. zulassen
                    {
                        Text b = upgradeButtons[i].transform.Find("Text").GetComponent<Text>();
                        b.text = welchesLvlWirdUmWievielUpgraded("blue");
                        b.enabled = true;
                    }
                    if (upgradeButtons[i].name == "ButtonAttack+")//um +20 beim btn ersch. zulassen
                    {
                        Text r = upgradeButtons[i].transform.Find("Text").GetComponent<Text>();
                        r.text = welchesLvlWirdUmWievielUpgraded("red");
                        r.enabled = true;
                    }
                    if (upgradeButtons[i].name == "ButtonSpeed+")//um +20 beim btn ersch. zulassen
                    {
                        Text y = upgradeButtons[i].transform.Find("Text").GetComponent<Text>();
                        y.text = welchesLvlWirdUmWievielUpgraded("yellow");
                        y.enabled = true;
                    }


                }
                else
                {
                    upgradeButtons[i].image.enabled = false;
                    upgradeButtons[i].transform.Find("Text").GetComponent<Text>().enabled = false;
                }

            }
        }
    }
    private void Awake()
    {




        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            int copie = i; //sonst gibt es ein berüchtigtes outofbounds
            upgradeButtons[copie].onClick.AddListener(delegate { UpgradeSkill(upgradeButtons[copie]); });

        }
    }

    void UpgradeSkill(Button btn)
    {
        stoppschleife = false;

        if (btn.name == "ButtonShield+")
        {
            for (int i = 0; i < shieldLvl.Length; i++)
            {
                if (upgradePoints > 0 && shieldLvl[i].enabled == false && stoppschleife == false)
                {
                    shieldLvl[i].enabled = true;
                    upgradePointsUsed += 1;
                    upgradePoints -= 1;
                    if (!shieldLvl[9].enabled) //9 = 10 weil int = 0 lool haha
                    {
                        sliderPlayerShield.maxValue += 20;
                        stoppschleife = true;
                    }
                    else if (shieldLvl[9].enabled)
                    {
                        print("Yes sir");
                        sliderPlayerShield.maxValue += 200;
                        stoppschleife = true;
                    }

                }

            }
        }
        else if (btn.name == "ButtonAttack+")
        {
            for (int i = 0; i < attackLvl.Length; i++)
            {
                if (upgradePoints > 0 && attackLvl[i].enabled == false && stoppschleife == false)
                {
                    attackLvl[i].enabled = true;
                    upgradePointsUsed += 1;
                    upgradePoints -= 1;
                    if (!attackLvl[9].enabled)
                    {
                        playerBullet.GetComponent<Attribut>().bulletdmg += 2;
                        stoppschleife = true;
                    }
                    else if (attackLvl[9].enabled)
                    {
                        playerBullet.GetComponent<Attribut>().bulletdmg += 20;
                        stoppschleife = true;
                    }
                }
            }
        }
        else if (btn.name == "ButtonSpeed+")
        {
            for (int i = 0; i < speedLvl.Length; i++)
            {
                if (upgradePoints > 0 && speedLvl[i].enabled == false && stoppschleife == false)
                {
                    speedLvl[i].enabled = true;
                    upgradePointsUsed += 1;
                    upgradePoints -= 1;
                   // if (!speedLvl[9].enabled)
                   // {
                        player.GetComponent<movement>().speed += 0.2f;
                        stoppschleife = true;
                  //  }
                    //else if (speedLvl[9].enabled)
                    //{
                    //    player.GetComponent<movement>().speed += 2f;
                    //    stoppschleife = true;
                    //}
                }
            }
        }
    }

    //für den Text im Button der erscheint wenn man lvlUp wird. Dort soll drauf stehen um wieviel punkte man verbessert wenn man auf button drückt
    public string welchesLvlWirdUmWievielUpgraded(string a)
    {
        if (a == "blue")
        {
            for (int i = 0; i < shieldLvl.Length; i++)
            {
                if (!shieldLvl[8].enabled) //wird bis 9 angezeigt 
                {
                    string upgradeShieldPoints = "+20";
                    return upgradeShieldPoints;
                }
                else if (shieldLvl[8].enabled && !shieldLvl[9].enabled)
                {
                    string upgradeShieldPoints = "+200";
                    return upgradeShieldPoints;
                }
                else if (shieldLvl[9].enabled)
                {
                    string upgradeShieldPoints = "MAX";
                    return upgradeShieldPoints;
                }
            }
        }
        else if(a == "red")
        {
            for (int i = 0; i < attackLvl.Length; i++)
            {
                if (!attackLvl[8].enabled) //wird bis 9 angezeigt 
                {
                    string upgradeShieldPoints = "+2";
                    return upgradeShieldPoints;
                }
                else if (attackLvl[8].enabled && !attackLvl[9].enabled)
                {
                    string upgradeShieldPoints = "+20";
                    return upgradeShieldPoints;
                }
                else if (attackLvl[9].enabled)
                {
                    string upgradeShieldPoints = "MAX";
                    return upgradeShieldPoints;
                }
            }
        }
        else if (a == "yellow")
        {
            for (int i = 0; i < speedLvl.Length; i++)
            {
                if (!speedLvl[9].enabled) //wird bis 10 angezeigt 
                {
                    string upgradeShieldPoints = "+0,2";
                    return upgradeShieldPoints;
                }
      
                else if (speedLvl[9].enabled)
                {
                    string upgradeShieldPoints = "MAX";
                    return upgradeShieldPoints;
                }
            }
        }
        return null;
    }
}
