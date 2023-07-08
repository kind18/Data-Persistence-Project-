using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    
    public static MainManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int highScore;

    // Start is called before the first frame update
    void Awake()
    {
            if (Instance != null) // check if Instance already exsist
            {
                Destroy(gameObject); 
                return; // to exit a method 
            }
                
            // can call MainManager.Instance from any other script
            Instance = this;
            
            // script not destory when scene change
            DontDestroyOnLoad(gameObject);
    }

   
    public void SaveHighScore()
        {
            SaveData data = new SaveData();
            data.highScore = highScore;
            data.bestPlayerName = bestPlayerName;

            string json = JsonUtility.ToJson(data); //transformed that instance to JSON
        
            //used the special method File.WriteAllText to write a string to a file
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

    public void LoadHighScore()
        {
            string path = Application.persistentDataPath + "/savefile.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);

                highScore = data.highScore;
                bestPlayerName = data.bestPlayerName;
            }
        }



    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int highScore;

    }





}
