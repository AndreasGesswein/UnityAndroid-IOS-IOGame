using UnityEngine;

public class npcCollisionNachladung : MonoBehaviour
{
    private Attribut attribut;
    private int blueAmmoSlider;
    private int redAmmoSlider;
    private int yellowAmmoSlider;
    private int purpleAmmoSlider;
    private bool ammoButtonOnOff;
    [SerializeField] private GameObject npc;
    Color blueColor;

    void Start()
    {

        //blueAmmoSlider = npc.gameObject.GetComponent<Attribut>().blueAmmoSlider;
        //redAmmoSlider = npc.gameObject.GetComponent<Attribut>().redAmmoSlider;
        //yellowAmmoSlider = npc.gameObject.GetComponent<Attribut>().yellowAmmoSlider;
        //purpleAmmoSlider = npc.gameObject.GetComponent<Attribut>().purpleAmmoSlider;
        //ammoButtonOnOff = npc.gameObject.GetComponent<Attribut>().ammoButtonOnOff;

        GetComponent<SpriteRenderer>().material.color = Color.white;

        //ColorUtility.TryParseHtmlString("000DFF", out blueColor);
        //ColorUtility.TryParseHtmlString("FF0303", out redColor);
        //ColorUtility.TryParseHtmlString("FFFF00", out yellowColor);
        //ColorUtility.TryParseHtmlString("780082", out purpleColor);  
    }
    private void Update()
    {
        ammoButtonOnOff = npc.gameObject.GetComponent<Attribut>().ammoButtonOnOff;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (ammoButtonOnOff == true)
        {
            if (coll.gameObject.tag == "BlueAmmo")
            {
                GetComponent<SpriteRenderer>().material.color = Color.blue;
                if (npc.gameObject.GetComponent<Attribut>().blueAmmoSlider + 25 <= 100)
                {
                    npc.gameObject.GetComponent<Attribut>().blueAmmoSlider += 25;
                }
                else if (npc.gameObject.GetComponent<Attribut>().blueAmmoSlider + 25 > 100)
                {
                    npc.gameObject.GetComponent<Attribut>().blueAmmoSlider = 100;
                }
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "RedAmmo")
            {

                GetComponent<SpriteRenderer>().material.color = Color.red;
                if (npc.gameObject.GetComponent<Attribut>().redAmmoSlider + 25 <= 100)
                {
                    npc.gameObject.GetComponent<Attribut>().redAmmoSlider += 25;
                }
                else if (npc.gameObject.GetComponent<Attribut>().redAmmoSlider + 25 > 100)
                {
                    npc.gameObject.GetComponent<Attribut>().redAmmoSlider = 100;
                }
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "YellowAmmo")
            {

                GetComponent<SpriteRenderer>().material.color = Color.yellow;
                if (npc.gameObject.GetComponent<Attribut>().yellowAmmoSlider + 25 <= 100)
                {
                    npc.gameObject.GetComponent<Attribut>().yellowAmmoSlider += 25;
                }
                else if (npc.gameObject.GetComponent<Attribut>().yellowAmmoSlider + 25 > 100)
                {
                    npc.gameObject.GetComponent<Attribut>().yellowAmmoSlider = 100;
                }
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "PurpleAmmo")
            {

                GetComponent<SpriteRenderer>().material.color = new Color(51, 3, 49);
                if (npc.gameObject.GetComponent<Attribut>().purpleAmmoSlider + 25 <= 100)
                {
                    npc.gameObject.GetComponent<Attribut>().purpleAmmoSlider += 25;
                }
                else if (npc.gameObject.GetComponent<Attribut>().purpleAmmoSlider + 25 > 100)
                {
                    npc.gameObject.GetComponent<Attribut>().purpleAmmoSlider = 100;
                }
                Destroy(coll.gameObject);
            }
        }
    }

}
