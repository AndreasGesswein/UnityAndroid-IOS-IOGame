using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Transform scoreContainer;
    private Transform scoreAndName;
    private Transform feld;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryListDefault;

    //update und if rein222222222222222222222222222222

    private void Start()
    {
        //PlayerPrefs.DeleteKey("highscores");

    }
    private void Awake()
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Wenn ich einen Nullreference bekomme in genau diesem Script!!!
        //Schritt 1: "Table" und "private List<HighscoreEntry> highscoreEntryList;" -ausklammern/freischalten
        //Schritt 2: Bei Highscore sortieren "higscores." entfernen
        //Schritt 3: "Highscore Playerpref wieder herstellen(etwas reinpacken aus Tabelle falls Null in "AddHighscoreEntry")" wieder ausklammern/freischalten
        //Schritt 4: Einklammer/ausblenden ->
        //string jsonString = PlayerPrefs.GetString("highscores");
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Schritt 5: AddHighscoreEntry nichts adden in Awake
        //Schritt 6: Starten 
        //Schritt 7: Schritt 1,Schritt 4, Schritt 2,Schritt 3 -rückgängig machen
        //------------------------------------------------------------------------------------------------------------------------------------------------------------

        feld = transform.Find("Feld");
        scoreContainer = feld.Find("ScoreContainer");
        scoreAndName = scoreContainer.Find("ScoreAndName");

        /*
        // Table       
         highscoreEntryList = new List<HighscoreEntry>()
         {
             new HighscoreEntry{score = 20, name = "sponge"},
             new HighscoreEntry{score = 2000, name = "bobi"},
             new HighscoreEntry{score = 22340, name = "npc"}
         };
        */


        if (PlayerPrefs.GetInt("ErspielterScore") != 0)
        {
            AddHighscoreEntry(PlayerPrefs.GetInt("ErspielterScore", 0), PlayerPrefs.GetString("PlayerName"));
            Debug.Log("juuuuuuuuuuuu");
        }

        //Adden hier war



        //AddHighscoreEntry(25570, "Nice Guy");
        //AddHighscoreEntry(8050, "Alpha");

        if (PlayerPrefs.HasKey("highscores") == false)
        {
            Debug.Log("nuuuuuuuull");
            highscoreEntryListDefault = new List<HighscoreEntry>()
             {
             new HighscoreEntry{score = 5000, name = "Spongebob"},
             new HighscoreEntry{score = 4000, name = "Karen"},
             new HighscoreEntry{score = 2240, name = "npc"},
             new HighscoreEntry{score = 800, name = "Boss"},
             new HighscoreEntry{score = 500, name = "Michael"},
             new HighscoreEntry{score = 7347, name = "LOL"},
             new HighscoreEntry{score = 666, name = "666"},
             new HighscoreEntry{score = 50, name = "Cringe"},
             new HighscoreEntry{score = 220, name = "Welcome"},
             new HighscoreEntry{score = 100000, name = "IShowSpeed"},
             new HighscoreEntry{score = 380, name = "Admin"},
             new HighscoreEntry{score = 700, name = "StopIt"},
             new HighscoreEntry{score = 350, name = "hey"},
             new HighscoreEntry{score = 3000, name = "°_°"}
         };


            Highscores highscoresDefault = new Highscores { highscoreEntryList = highscoreEntryListDefault };
            string json = JsonUtility.ToJson(highscoresDefault);
            PlayerPrefs.SetString("highscores", json);
            PlayerPrefs.Save();
        }
        scoreAndName.gameObject.SetActive(false);

        //AddHighscoreEntry(1050, "Boss");
        //AddHighscoreEntry(20510, "LOOL");
        //string d = "4";
        //PlayerPrefs.SetString("highscores", d);
        string jsonString = PlayerPrefs.GetString("highscores");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        /*  if (highscores.highscoreEntryList.Count >= 5)
          {
              for (int i = 1; i <= highscores.highscoreEntryList.Count; i++)
              {
                  Debug.Log(highscores.highscoreEntryList[i = 1].score + "1");

                    //  highscores.highscoreEntryList.RemoveAt(5);


              }
          }*/


        if (highscores.highscoreEntryList != null)
        {

            //highscore sortieren
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        //umtauschen
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }

            //highscore löschen bzw. ersetzen
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                if (highscores.highscoreEntryList.Count > 15)//15=15
                {
                    Debug.Log(highscores.highscoreEntryList.Count + "-----------gelöscht");
                    highscores.highscoreEntryList.RemoveAt(15);//15=16

                }
            }

            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {

                CreateHighscoreEntryTransform(highscoreEntry, scoreContainer, highscoreEntryTransformList);
            }

            /*
            // Highscore Playerpref wieder herstellen(etwas reinpacken aus Tabelle falls Null in "AddHighscoreEntry")
            Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("highscores", json);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetString("highscores"));
            */

        }


        Debug.Log(highscores.highscoreEntryList[13].name + " nummer 13 im code nummer 14 in highscore tabelle ");
        Debug.Log(highscores.highscoreEntryList.Count + " Anzahl an highscroreentrys vor adden");
     
    }

    private void Update()
    {

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform scoreContainer, List<Transform> transformList)
    {
        float templateheight = 20f;
        Transform scoreErzeugen = Instantiate(scoreAndName, scoreContainer);
        RectTransform abstand = scoreErzeugen.GetComponent<RectTransform>();
        abstand.anchoredPosition = new Vector2(0, -templateheight * transformList.Count);
        scoreErzeugen.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        int score = highscoreEntry.score;
        scoreErzeugen.Find("gamescore").GetComponent<Text>().text = "   " + rankString + " " + score.ToString();
        // scoreErzeugen.Find("gamescore").GetComponent<Text>().text = "   " + rankString + " " + erspielterScore.text;

        string name = highscoreEntry.name;
        scoreErzeugen.Find("name").GetComponent<Text>().text = name;
        // scoreErzeugen.Find("name").GetComponent<Text>().text = PlayerPrefs.GetString("PlayerName");

        transformList.Add(scoreErzeugen);
    }

    public void AddHighscoreEntry(int score, string name)
    {


        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Load saved Highscore
        string jsonString = PlayerPrefs.GetString("highscores");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        Debug.Log(highscores.highscoreEntryList.Count + " Anzahl an highscroreentrys beim adden");
        
        if (highscores.highscoreEntryList.Count == 15) //==15 nur list.count zählt keine "0" mit, er zählt ganz normal, Zb wie viele finger habe ich....
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                if (highscores.highscoreEntryList[14].score < highscoreEntry.score)//Diese 14 ist quasi die 15 ohne 0
                {
                    highscores.highscoreEntryList.RemoveAt(14);//Diese 14 ist quasi die 15 ohne 0

                }
            }
        }
        else if (highscores.highscoreEntryList.Count > 15)
        {
            highscores.highscoreEntryList.RemoveAt(15);
        }

        //Add new entry to Highscore 
        highscores.highscoreEntryList.Add(highscoreEntry);

        //save updated Highscore
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscores", json);
        PlayerPrefs.Save();

        //Damit keine Doppelgänger erzeugt werden
        highscoreEntry = null;




        /*
        PlayerPrefs.SetString("highscores", "100");
        PlayerPrefs.Save();

      
        //Create HighscoreEntrys
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscores");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add new entry to Highscore
            highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated Highscore
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscores", json);
        PlayerPrefs.Save();
        */
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //konstrukt eines highscores
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
