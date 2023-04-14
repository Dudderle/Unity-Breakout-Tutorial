using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        foreach(string name in StoreName.Instance.data.playerNames)
        {
            nameText.text += "\n" + name;
        }
        foreach (int name in StoreName.Instance.data.playerScores)
        {
            scoreText.text += "\n" + name;
        }
    }




}
