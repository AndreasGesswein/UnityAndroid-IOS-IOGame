using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnFireNpc : MonoBehaviour
{
    [SerializeField] private GameObject npcAttr;
    [SerializeField] private ParticleSystem particleDefence;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private GameObject playerBullet;
    private Attribut attributPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        attributPlayer = playerBullet.GetComponent<Attribut>(); 
    }

    private void Update()
    {

        if (hpSlider.value > 0)
        {
            //yield return new WaitForSeconds(3);
            hpSlider.value += 0.02f;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "redBullet") //npc wird angeschossen mit roter patrone
        {
            Destroy(coll.gameObject);
            if (npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider >= attributPlayer.bulletdmg)
            {
                defenceParticleOnFire();
                npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider -= attributPlayer.bulletdmg;
            }
            else if (npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider < attributPlayer.bulletdmg)
            {
                //example: shield - dmg = -2 rest, Hp - 2
                int ausgleich = attributPlayer.bulletdmg - npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider;
                npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider = 0;
                hpSlider.value -= ausgleich;
            }
        }
        if (hpSlider.value <= 0)
        {
            int erpielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
            erpielterScore += 200;
            PlayerPrefs.SetInt("ErspielterScore", erpielterScore);
            transform.position = new Vector2(-100, 0);
            hpSlider.value = 100;
            npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider = 100;
            npcAttr.gameObject.GetComponent<Attribut>().redAmmoSlider = 100;
            npcAttr.gameObject.GetComponent<Attribut>().yellowAmmoSlider = 100;
            npcAttr.gameObject.GetComponent<Attribut>().purpleAmmoSlider = 100;

        }
    }
    void defenceParticleOnFire()
    {
        particleDefence.Play();
    }
}
