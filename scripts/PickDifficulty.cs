using UnityEngine;
using UnityEngine.SceneManagement;

public class PickDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EasyGame()
    {
        PlayerPrefs.SetString("GameDifficulty", "Easy");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void NormalGame()
    {
        PlayerPrefs.SetString("GameDifficulty", "Normal");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HardGame()
    {
        PlayerPrefs.SetString("GameDifficulty", "Hard");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AsianGame()
    {
        PlayerPrefs.SetString("GameDifficulty", "Asian");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
