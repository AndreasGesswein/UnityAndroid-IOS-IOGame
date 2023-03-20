using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayernameSet : MonoBehaviour
{
    public static PlayernameSet playernameSet;
    public Text playerNameOnScene;
   // private PlayerNameTransfer playernameTransfer;
    // Start is called before the first frame update
    void Start()
    {
        playerNameOnScene.text = PlayerPrefs.GetString("PlayerName");
       // playerNameOnScene.text = PlayerNameTransfer.playerNameTransfer.inputName.text;
    }

    // Update is called once per frame
    void Update()
    {
        //print(playernameTransfer.playerName.text);
    }
}
