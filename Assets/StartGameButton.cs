using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log(GameObject.Find("Eingabe").GetComponent<TMP_InputField>().text);
        StoreName.Instance.playerName = GameObject.Find("Eingabe").GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene("main");
        
    }
    public void HighScoreScreen()
    {
        SceneManager.LoadScene("HighScores");
    }

    static public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenue");
    }
}
