using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField inputField;
    public Text BestScoreText;

    private void Start()
    {
        MainManager.Instance.LoadHighScore();
        
        BestScoreText.text = "Best Score : " + MainManager.Instance.bestPlayerName +" : "+ MainManager.Instance.highScore;
    
        
    }
  

    private void StartNew()
    {
        MainManager.Instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        
        #else
        Application.Quit();

        #endif
    }


}
