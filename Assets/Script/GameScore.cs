using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScore : MonoBehaviour
{
    [SerializeField]
    Text countGame;

    [SerializeField]
    Text recordScore;

    private int recordMenu;
    public int ScoreGame { get; set; }


    void Update ()
    {
        SaveScore();
        DeleteSave();
        countGame.text = ScoreGame.ToString();
        recordScore.text = recordMenu.ToString();
	}

    void SaveScore()
    {
        if (ScoreGame > recordMenu)
        {
            PlayerPrefs.SetInt("SavedRecord", ScoreGame);
        }
        recordMenu = PlayerPrefs.GetInt("SavedRecord");
    }

    void DeleteSave()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerPrefs.DeleteAll();
    }
}
