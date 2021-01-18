using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text MaxLvl;
    [SerializeField] private Text score;
    [SerializeField] private Text apple;
    [SerializeField] private Button play;
    void Start()
    {
        play.onClick.AddListener(() => StartGame());
        if (!PlayerPrefs.HasKey("ApplyScore")) apple.text += " " + 0;
        else if (PlayerPrefs.HasKey("ApplyScore")) apple.text += " " + PlayerPrefs.GetInt("ApplyScore");
        if (!PlayerPrefs.HasKey("BestScore")) score.text += " " + 0;
        else if (PlayerPrefs.HasKey("BestScore")) score.text += " " + PlayerPrefs.GetInt("BestScore");
        if (!PlayerPrefs.HasKey("Stage")) MaxLvl.text = " " + 1.ToString();
        else if (PlayerPrefs.HasKey("Stage")) MaxLvl.text += " " + PlayerPrefs.GetInt("Stage").ToString();
    }

    // Update is called once per frame
    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
