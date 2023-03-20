using UnityEngine;
using UnityEngine.UI;


public class modifier : MonoBehaviour
{
    [SerializeField] private Slider sliderBlue;
    [SerializeField] private Button buttonBlue;
    [SerializeField] private Slider sliderRed;
    [SerializeField] private Button buttonRed;
    [SerializeField] private Slider sliderYellow;
    [SerializeField] private Button buttonYellow;
    [SerializeField] private Slider sliderPurple;

    private void Awake()
    {
        buttonBlue.onClick.AddListener(modifieShield);
        buttonRed.onClick.AddListener(modifieAttack);
        buttonYellow.onClick.AddListener(modifieFuel);

    }

    void modifieShield()
    {
        if (sliderPurple.value == 100)
        {
            sliderBlue.value = 100;
            sliderPurple.value = 0;
        }
    }
    void modifieAttack()
    {
        if (sliderPurple.value == 100)
        {
            sliderRed.value = 100;
            sliderPurple.value = 0;
        }
    }
    void modifieFuel()
    {
        if (sliderPurple.value == 100)
        {
            sliderYellow.value = 100;
            sliderPurple.value = 0;
        }
    }

}
