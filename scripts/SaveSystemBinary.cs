using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystemBinary
{

    public static void SaveProgress(MainMenu mainMenu)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/MainMenuData.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        MainMenuData data = new MainMenuData(mainMenu);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static MainMenuData LoadProgress()
    {
        string path = Application.persistentDataPath + "/MainMenuData.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //er liest quasi die datei aus
            MainMenuData data = formatter.Deserialize(stream) as MainMenuData;
            stream.Close();

            return data;
        }
        else
        {

            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
