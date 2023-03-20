using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class npc : MonoBehaviour
{
    // [SerializeField] private Transform player;
    [SerializeField] public float startTime;
    private float waitTime;
    [SerializeField] private float speed;
    //public Transform[] npcMoveSpots; //hab ich benutzt als ich diese werte manuell übergeben habe
    private GameObject[] npcMoveSpots;//Finde und packe hier rein und übertrage dann auf Transform(npcMovespot). Ich suche und finde die movespots weil, das alles automatisiert werde muss, damit die npcs ohne probleme instantiatet werden können.
                                      // public List<GameObject> npcMoveSpotsList; //hab das anscheinend früher benutzt, hba code geändert. Könnte aber aktivieren um zu schauen wieveiel movespots tatsächlich da sind.
    private int randomSpot;

    [SerializeField] private GameObject redBulletEnemy;
    [SerializeField] private Transform shootPointLeft;
    [SerializeField] private Transform shootPointRight;
    [SerializeField] private float bulletForce;
    [SerializeField] private float fireRate, sprade, range, reload;
    private float nextFire = 0.0f;
    private bool chaceTarget = false;
    private string findTarget;
    public List<GameObject> collGameObjects; //man braucht usingSystemcollection. Alle Objekte die Collider betreten werden gespeichert. 
    private List<Vector2> storedPlayerPosition;
    [SerializeField] private GameObject npcAttr;
    [SerializeField] private int abstand; //Abstand zum gefolgtem spieler
    [SerializeField] private Slider hpSlider;

    private int blueAmmoSlider;
    private int blueAmmoSliderMax;
    private int redAmmoSlider;
    private int redAmmoSliderMax;
    private int yellowAmmoSlider;
    private int yellowAmmoSliderMax;
    private int purpleAmmoSlider;
    private int purpleAmmoSliderMax;

    private GameObject collGameObjectOne;
    private bool escaped;

    Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //  npcMoveSpotsList = new List<GameObject>();
        startTime = 2f;
        waitTime = startTime;

        npcMoveSpots = GameObject.FindGameObjectsWithTag("npcMoveSpot");
        randomSpot = Random.Range(0, npcMoveSpots.Length);
        storedPlayerPosition = new List<Vector2>();
        findTarget = "";
        bulletForce = 9f;

        string gameMode = PlayerPrefs.GetString("GameDifficulty", "");
        if (gameMode == "Easy")
        {
            speed = 4f;
        }
        else if (gameMode == "Normal")
        {
            speed = 4.5f;
        }
        else if (gameMode == "Hard")
        {
            speed = 5f;
        }
        else if (gameMode == "Asian")
        {
            speed = 6f;
        }
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        npcMoveSpots = GameObject.FindGameObjectsWithTag("npcMoveSpot");


        //  for (int i = 0; i < npcMoveSpots.Length; i++)
        //  {
        //   if (npcMoveSpotsList.Contains(npcMoveSpots[i]) == false)
        //{
        //     npcMoveSpotsList.Add(npcMoveSpots[i].gameObject);         
        //  }
        //  }


        playerPos = GameObject.FindWithTag("Player").transform.position; //umgewandelt für die if statements

        Vector2 tranPos = transform.position;
        //Solange man nur schauen möchte und nichts verändert, kann man das so machen. Ansonsten nur per direkt zugriff
        blueAmmoSlider = npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSlider;
        blueAmmoSliderMax = npcAttr.gameObject.GetComponent<Attribut>().blueAmmoSliderMax;
        redAmmoSlider = npcAttr.gameObject.GetComponent<Attribut>().redAmmoSlider;
        redAmmoSliderMax = npcAttr.gameObject.GetComponent<Attribut>().redAmmoSliderMax;
        yellowAmmoSlider = npcAttr.gameObject.GetComponent<Attribut>().yellowAmmoSlider;
        yellowAmmoSliderMax = npcAttr.gameObject.GetComponent<Attribut>().yellowAmmoSliderMax;
        purpleAmmoSlider = npcAttr.gameObject.GetComponent<Attribut>().purpleAmmoSlider;
        purpleAmmoSliderMax = npcAttr.gameObject.GetComponent<Attribut>().purpleAmmoSliderMax;


        //normales Roaming von Ort zu Ort
        if (findTarget == "" && chaceTarget == false && escaped == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, npcMoveSpots[randomSpot].transform.position, speed * Time.deltaTime);
            //0.2 weil minimalste unterschiede zu false führen würden
            if (Vector2.Distance(transform.position, npcMoveSpots[randomSpot].transform.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, npcMoveSpots.Length);
                    waitTime = startTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        //Spieler in der nähe! Angriff
        else if (findTarget == "Player" && chaceTarget == true)
        {
            npcAttr.gameObject.GetComponent<Attribut>().ammoButtonOnOff = false;
            LookAt2D(transform, playerPos);
            Attack();
            if (storedPlayerPosition.Count == 0)
            {
                storedPlayerPosition.Add(playerPos);

            }
            else if (storedPlayerPosition[storedPlayerPosition.Count - 1] != playerPos)
            {
                storedPlayerPosition.Add(playerPos);
            }
            if (storedPlayerPosition.Count > abstand)
            {
                transform.position = Vector2.MoveTowards(transform.position, storedPlayerPosition[0], speed * Time.deltaTime);
                storedPlayerPosition.RemoveAt(0);
            }
        }
        else if (findTarget == "")
        {
            chaceTarget = false;
            escaped = true;
        }
        //Munition wird bei einer sicheren gelegenheit eingesammelt wenn Spieler nicht in der nähe ist
        if ((blueAmmoSlider < blueAmmoSliderMax || redAmmoSlider < redAmmoSliderMax || yellowAmmoSlider < yellowAmmoSliderMax || purpleAmmoSlider < 100) && findTarget == "Ammo" && chaceTarget == true) //muss hier nicht false??????
        {
            if (collGameObjectOne.gameObject != null)
            {
                npcAttr.gameObject.GetComponent<Attribut>().ammoButtonOnOff = true;
                LookAt2D(transform, collGameObjectOne.transform.position);
                transform.position = Vector2.MoveTowards(transform.position, collGameObjectOne.transform.position, speed * Time.deltaTime);
            }
            else if (collGameObjectOne.gameObject == null)
            {
                chaceTarget = false;
                findTarget = "";
            }
        }
        //Logik code
        else if ((blueAmmoSlider == blueAmmoSliderMax && redAmmoSlider == redAmmoSliderMax && yellowAmmoSlider == yellowAmmoSliderMax && purpleAmmoSlider == 100) && findTarget == "Player")
        {
            chaceTarget = true;
        }
        else if ((blueAmmoSlider == blueAmmoSliderMax && redAmmoSlider == redAmmoSliderMax && yellowAmmoSlider == yellowAmmoSliderMax && purpleAmmoSlider == 100) && findTarget != "Player")
        {
            chaceTarget = false;
            findTarget = "";
        }

        if ((redAmmoSlider <= 5 || hpSlider.value <= 40) && findTarget == "Player")
        {
            escaped = false;
            chaceTarget = false;
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position - transform.position, speed * Time.deltaTime);
            LookAt2D(transform, playerPos);

        }
    }

    private void FindTarget(Transform target)
    {
        //float targetRange = 12f;
        //if (Vector3.Distance(transform.position, player.position) <= targetRange)
        // {
        LookAt2D(transform, target.position);//LookAt gibt es nicht für 2d daher eben eins erstellt (spieler verschwindet sonst)
        //  return true;
        //}
        /// else
        ///{
        //return false;
        // }
    }

    private void ChaceTarget()
    {
        //if (waitTime / 4 <= 0)
        //{
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        //}
        //else
        //{
        //    waitTime -= Time.deltaTime;
        //}
    }

    private void Attack()
    {

        if (Time.time > nextFire && npcAttr.gameObject.GetComponent<Attribut>().redAmmoSlider >= 2)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(redBulletEnemy, shootPointLeft.position, shootPointLeft.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPointLeft.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);

            bullet = Instantiate(redBulletEnemy, shootPointRight.position, shootPointRight.rotation);
            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPointRight.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);

            npcAttr.gameObject.GetComponent<Attribut>().redAmmoSlider -= 2;

            ;
        }
    }

    public static bool LookAt2D(Transform transform, Vector2 target)
    {
        if (target != null)
        {
            Vector2 current = transform.position;
            var direction = target - current;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            return true;
        }
        else
        {
            return false;
        }
    }

    //  private string CheckNearObjects()
    // {
    //Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, 12);

    //foreach (Collider2D i in objects)
    //{

    //   // Debug.Log(i.tag);
    //   // Debug.Log(i.name);
    //    return i.tag;

    //}
    //return null;
    // }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!collGameObjects.Contains(coll.gameObject))
        {
            collGameObjects.Add(coll.gameObject);
            if (coll.gameObject.tag == "Player")
            {
                findTarget = "Player";//atk,chace,lookAt
                chaceTarget = true;

            }
            else if (coll.gameObject.tag.Contains("Ammo") && findTarget != "Player")
            {
                findTarget = "Ammo";
                chaceTarget = true;

                collGameObjectOne = coll.gameObject;

            }

        }


    }
    private void OnTriggerExit2D(Collider2D coll)
    {

        //  for (int i = 0; i < gameObjects.Count; i++)
        // {
        //if (gameObjects[i] = null)
        // {
        if (coll.gameObject.tag == "Player")
        {
            findTarget = "";
            chaceTarget = false;
            escaped = true;
            collGameObjects.Remove(coll.gameObject);
        }
        else
        {
            collGameObjects.Remove(coll.gameObject);

        }

    }
}


