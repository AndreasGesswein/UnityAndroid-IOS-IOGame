using UnityEngine;
using UnityEngine.UI;
public class ammoToXp : MonoBehaviour
{
    //Objekte werden nicht direkt mitgegeben weil, die Objekten welche diesen Script haben, aus den prefabs Generiert werden, d.h
    //sie existieren noch nicht in der scene und ihnen kann deshalb nicht direkt übergeben werden.
    private Text xpLvl;
    private Slider xpbar;
    private Slider hpSlider;
    private int attributXpvalue;
    [SerializeField] private GameObject playerBullet;
    private int attributDmg;

    [SerializeField] private ParticleSystem particleAttack; //bullet effekt beim aufprallen
    void Update()
    {
        xpbar = GameObject.FindGameObjectWithTag("xpbar").GetComponent<Slider>();
        xpLvl = xpbar.gameObject.transform.Find("lvl").GetComponent<Text>();
        attributDmg = playerBullet.GetComponent<Attribut>().bulletdmg;

    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "BlueAmmo")
        {
            // coll.gameObject.GetComponent<xp>().BlueXp(); habe hier auf script von coll zugegriefen
            hpSlider = coll.gameObject.transform.Find("Canvas").Find("hpObject").GetComponent<Slider>();//hpSlider von ammo!
            attributXpvalue = coll.gameObject.GetComponent<Attribut>().xpValue; //wieviel xp bekommt man vom angeschossenem objekt?
            if (hpSlider.value > attributDmg * 2) //warum nicht > 0? weil die Patrone den wert von Ammo erst kennt wenn sie collidieren
            {
                hpSlider.value -= attributDmg * 2;
            }
            else if (hpSlider.value <= attributDmg * 2)
            {
                Destroy(coll.gameObject);
                int erpielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
                erpielterScore += 10;
                PlayerPrefs.SetInt("ErspielterScore", erpielterScore);
                if (xpbar.value + attributXpvalue < xpbar.maxValue)
                {
                    xpbar.value += attributXpvalue;
                }
                else if (xpbar.value + attributXpvalue >= xpbar.maxValue)
                {
                    int ausgleich = (((int)xpbar.value) + attributXpvalue) - ((int)xpbar.maxValue);
                    xpbar.value = ausgleich;
                    int xpLvlInt = int.Parse(xpLvl.text); //Text in int umwandeln um "lvl" zu ändern
                    xpLvlInt += 1;
                    xpLvl.text = xpLvlInt.ToString();
                }

            }

        }

        else if (coll.gameObject.tag == "RedAmmo")
        {
            hpSlider = coll.gameObject.transform.Find("Canvas").Find("hpObject").GetComponent<Slider>();
            attributXpvalue = coll.gameObject.GetComponent<Attribut>().xpValue;

            if (hpSlider.value > attributDmg * 2)
            {
                hpSlider.value -= attributDmg * 2;
            }
            else if (hpSlider.value <= attributDmg * 2)
            {
                Destroy(coll.gameObject);
                int erpielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
                erpielterScore += 20;
                PlayerPrefs.SetInt("ErspielterScore", erpielterScore);
                if (xpbar.value + attributXpvalue < xpbar.maxValue)
                {
                    xpbar.value += attributXpvalue;
                }
                else if (xpbar.value + attributXpvalue >= xpbar.maxValue)
                {
                    int ausgleich = (((int)xpbar.value) + attributXpvalue) - ((int)xpbar.maxValue);
                    xpbar.value = ausgleich;
                    int xpLvlInt = int.Parse(xpLvl.text); //Text in int umwandeln um "lvl" zu ändern
                    xpLvlInt += 1;
                    xpLvl.text = xpLvlInt.ToString();
                }

            }

        }

        else if (coll.gameObject.tag == "YellowAmmo")
        {
            hpSlider = coll.gameObject.transform.Find("Canvas").Find("hpObject").GetComponent<Slider>();
            attributXpvalue = coll.gameObject.GetComponent<Attribut>().xpValue;

            if (hpSlider.value > attributDmg * 2)
            {
                hpSlider.value -= attributDmg * 2;
            }
            else if (hpSlider.value <= attributDmg * 2)
            {
                Destroy(coll.gameObject);
                int erpielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
                erpielterScore += 30;
                PlayerPrefs.SetInt("ErspielterScore", erpielterScore);
                if (xpbar.value + attributXpvalue < xpbar.maxValue)
                {
                    xpbar.value += attributXpvalue;
                }
                else if (xpbar.value + attributXpvalue >= xpbar.maxValue)
                {
                    int ausgleich = (((int)xpbar.value) + attributXpvalue) - ((int)xpbar.maxValue);
                    xpbar.value = ausgleich;
                    int xpLvlInt = int.Parse(xpLvl.text); //Text in int umwandeln um "lvl" zu ändern
                    xpLvlInt += 1;
                    xpLvl.text = xpLvlInt.ToString();
                }

            }
        }

        else if (coll.gameObject.tag == "PurpleAmmo")
        {
            hpSlider = coll.gameObject.transform.Find("Canvas").Find("hpObject").GetComponent<Slider>();
            attributXpvalue = coll.gameObject.GetComponent<Attribut>().xpValue;

            if (hpSlider.value > attributDmg * 2)
            {
                hpSlider.value -= attributDmg * 2;
            }
            else if (hpSlider.value <= attributDmg * 2)
            {
                Destroy(coll.gameObject);
                int erpielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
                erpielterScore += 40;
                PlayerPrefs.SetInt("ErspielterScore", erpielterScore);
                if (xpbar.value + attributXpvalue < xpbar.maxValue)
                {
                    xpbar.value += attributXpvalue;
                }
                else if (xpbar.value + attributXpvalue >= xpbar.maxValue)
                {
                    int ausgleich = (((int)xpbar.value) + attributXpvalue) - ((int)xpbar.maxValue);
                    xpbar.value = ausgleich;
                    int xpLvlInt = int.Parse(xpLvl.text); //Text in int umwandeln um "lvl" zu ändern
                    xpLvlInt += 1;
                    xpLvl.text = xpLvlInt.ToString();
                }

            }
        }

        //Aufprall Logik.  Erstes "if" weil, wenn nps schießt und er sich selber trifft sollen particel NICHT aktiviert werden.
        if (coll.gameObject.tag == "Npc" && playerBullet.tag == "enemieBullet")
        {
           // Debug.Log("looooool");
          
        }
        else if (coll.gameObject.tag == "Player" && playerBullet.tag == "redBullet")
        {
           // Debug.Log("omfg");
        }
        else 
        {
            ParticleSystem ps = Instantiate(particleAttack, transform.position, transform.rotation);
            ps.Play();
            Destroy(ps, 1f);
        }


    }
}


