using UnityEngine;
public class destroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "redBullet")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "enemieBullet")
        {
            Destroy(collision.gameObject);
        }

    }

}


