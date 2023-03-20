using UnityEngine;
using UnityEngine.UI;

public class Aiming : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private GameObject redBullet;
    [SerializeField] private Transform shootPointLeft;
    [SerializeField] private Transform shootPointRight;
    [SerializeField] private float bulletForce = 3f;
    [SerializeField] private Slider ammoSliderRed;
    [SerializeField] private float fireRate, sprade, range, reload;
    private float nextFire = 0.0f;
    [SerializeField] private Button ammoButtonOnOff;
    // bool readyToShoot = true;


    void Update()
    {
        //Zum Aimen mit dem Körper |...
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);

            // Schießen bzw. zum erstellen eines Schuss Objektes
            if (ammoButtonOnOff.GetComponent<Image>().color == Color.red)
            {
                if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && ammoSliderRed.value >= 2)
                {
                    nextFire = Time.time + fireRate;

                    GameObject bullet = Instantiate(redBullet, shootPointLeft.position, shootPointLeft.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPointLeft.right * bulletForce, ForceMode2D.Impulse);
                    Destroy(bullet, 5f);

                    bullet = Instantiate(redBullet, shootPointRight.position, shootPointRight.rotation);
                    rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPointRight.right * bulletForce, ForceMode2D.Impulse);
                    Destroy(bullet, 5f);

                    ammoSliderRed.value -= 2f;
                    //Invoke("ResetShot",timebetweenShooting);

                }
            }


        }
    }

    // private void ResetShot()
    // {
    //     readyToShoot = true;
    // }
}