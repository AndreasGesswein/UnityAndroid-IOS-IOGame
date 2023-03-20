using UnityEngine;
using UnityEngine.UI;


public class collisionNachladung : MonoBehaviour
{
    [SerializeField] private Material startingAmmoColor;
    [SerializeField] private Material changingAmmoColor;
    [SerializeField] private Material blueColor;
    [SerializeField] private Material redColor;
    [SerializeField] private Material yellowColor;
    [SerializeField] private Material purpleColor;
    [SerializeField] private Slider ammoSliderBlue;
    [SerializeField] private Slider ammoSliderRed;
    [SerializeField] private Slider ammoSliderYellow;
    [SerializeField] private Slider ammoSliderPurple;

    [SerializeField] private Button ammoButtonOnOff;
    void Start()
    {
        Color w = startingAmmoColor.GetColor("_EmissionColor");
        changingAmmoColor.SetColor("_EmissionColor", w);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (ammoButtonOnOff.GetComponent<Image>().color == Color.green)
        {
            if (coll.gameObject.tag == "BlueAmmo")
            {
                Color b = blueColor.GetColor("_EmissionColor");
                changingAmmoColor.SetColor("_EmissionColor", b);
                ammoSliderBlue.value += 25f;
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "RedAmmo")
            {
                Color r = redColor.GetColor("_EmissionColor");
                changingAmmoColor.SetColor("_EmissionColor", r);
                ammoSliderRed.value += 25f;
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "YellowAmmo")
            {
                Color y = yellowColor.GetColor("_EmissionColor");
                changingAmmoColor.SetColor("_EmissionColor", y);
                ammoSliderYellow.value += 25f;
                Destroy(coll.gameObject);
            }
            else if (coll.gameObject.tag == "PurpleAmmo")
            {
                Color p = purpleColor.GetColor("_EmissionColor");
                changingAmmoColor.SetColor("_EmissionColor", p);
                ammoSliderPurple.value += 25f;
                Destroy(coll.gameObject);
            }
        }
        else if (ammoButtonOnOff.GetComponent<Image>().color == Color.red)
        {

        }
    }

}
