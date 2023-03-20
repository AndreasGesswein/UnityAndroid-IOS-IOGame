using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleDefence;
    //[SerializeField] private ParticleSystem particleAttack;
    [SerializeField] private Slider ammoSliderBlue;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private GameObject enemyBullet;
    private Attribut attributEnemy;


    // Start is called before the first frame update
    void Start()
    {
        attributEnemy = enemyBullet.GetComponent<Attribut>();
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
        if (coll.gameObject.tag == "enemieBullet") //man wird angeschossen mit roter patrone
        {

            Destroy(coll.gameObject);
            

            if (ammoSliderBlue.value >= attributEnemy.bulletdmg)
            {
                defenceParticleOnFire();
                ammoSliderBlue.value -= attributEnemy.bulletdmg;
            }
            else if (ammoSliderBlue.value < attributEnemy.bulletdmg)
            {
                //example: shield - dmg = -2 rest, Hp - 2
                int ausgleich = attributEnemy.bulletdmg - ((int)ammoSliderBlue.value);
                ammoSliderBlue.value = 0;
                hpSlider.value -= ausgleich;
            }

            if (hpSlider.value <= 0)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

            }

        }
        //else if (coll.gameObject.tag == "playerBullet") wenn spieler jemand anschiesst
        //{
        //    Destroy(coll.gameObject);
        //    if (ammoSliderBlue.value >= attributPlayer.bulletdmg)
        //    {
        //        defenceParticleOnFire();
        //        ammoSliderBlue.value -= attributPlayer.bulletdmg;
        //    }
        //    else if (ammoSliderBlue.value < attributPlayer.bulletdmg)
        //    {
        //        int ausgleich = attributPlayer.bulletdmg - ((int)ammoSliderBlue.value);
        //        ammoSliderBlue.value = 0;
        //        hpSlider.value -= ausgleich;
        //    }
        //}

    }
    void defenceParticleOnFire()
    {
        particleDefence.Play();
    }

   

}
