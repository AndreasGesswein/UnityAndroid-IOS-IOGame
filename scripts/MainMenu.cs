using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text inputName; //wird in playerprefs gespeichert (nur für unwichtige daten die verloren gehen und gehackt werden dürfen)
    public InputField InputFieldForName;
    [SerializeField] private Text totalScoreString; //für "totalScore"
    public int totalScore; //wird in binary file gespeichert um spieler progress zu sichern (ist sicherer da die daten verschlüsselt werden in 1010110)

    [SerializeField] private Text gameScoreString;
    public int gameScore;

    
    private void Start()
    {
        LoadProgress();
        
        //Wenn dead soll name und score in Highscore eingetragen werden
        //Highscore highscore = FindObjectOfType<Highscore>();
        // highscore.AddHighscoreEntry(PlayerPrefs.GetInt("ErspielterScore", 0), PlayerPrefs.GetString("PlayerName"));
    }
    void Update()
    {
        totalScore = int.Parse(totalScoreString.text);
        gameScore = int.Parse(gameScoreString.text);
        //int erspielterScore = PlayerPrefs.GetInt("ErspielterScore", 0);
        //gameScore += erspielterScore;
        //gameScoreString.text = gameScore.ToString();
        //print(PlayerPrefs.GetInt("ErspielterScore", 0));

        SaveProgress();
    }

    public void SaveProgress()
    {
        SaveSystemBinary.SaveProgress(this);
    }

    public void LoadProgress()
    {
        MainMenuData data = SaveSystemBinary.LoadProgress();
        totalScoreString.text = data.totalScore.ToString();
        gameScoreString.text = data.gameScore.ToString();
    }

    public void PlayGame()
    {
        if (inputName.text != "")
        {
            //Wechselt anhand des indexes in "Build and run" die Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Prefs ist quasi ein lokaler speicher in welchem man daten speichern und wieder aufrufen kann
            PlayerPrefs.SetString("PlayerName", inputName.text);
        }
        else
        {
            InputFieldForName.text = "You are Blind?";
            inputName.color = Color.red;
            
        }
    }
    public void QuitGame()
    {
        //Um Spiel komplett zu verlassen
        Application.Quit();
        PlayerPrefs.DeleteKey("PlayerName");
        print("Quit");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
