using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public event Action nextLevel;
    public GameState gameState { get; private set; }
    public static GameManager gameManager;

   
    public Target target { get; private set; }
    public int stage { get; private set; }
    public int appleScore { get; private set; }

   
    [SerializeField] private Vector3 finishPoint;
    [SerializeField] private Transform panelLose;
    [SerializeField] private Button restart;
    [SerializeField] private GameObject WoodLogPrefab;

    [SerializeField] private Text textScore;
    [SerializeField] private Text scoreEnd;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text appleText;
    [SerializeField] private Text Lvl;
    [SerializeField] private Text EndGameLvl;

    private int score;

    private void Awake()
    {
        target = GameObject.FindObjectOfType<Target>();
        gameManager = this;
        Vibration.Init();
    }
    void Start()
    {
        target.notyfi += Score;
        restart.onClick.AddListener(() => RestartGame());
        gameState = GameState.Play;
        stage++;
        Lvl.text = "Stage : " + stage;
        if (!PlayerPrefs.HasKey("ApplyScore"))
            appleText.text = appleScore.ToString();
        else appleText.text = PlayerPrefs.GetInt("ApplyScore").ToString();
    }

   

    private void Score()
    {
        score++;
        textScore.text = score.ToString();
        Vibration.VibrateNope();
    }

    public void AppleScore()
    {
        appleScore++;
        PlayerPrefs.SetInt("ApplyScore", appleScore);
        appleText.text = appleScore.ToString();
    }
    public void LoseGame()
    {
        Vibration.Vibrate(100);
        StartCoroutine(_LoseGame());
        scoreEnd.text = "Score :" + " "+ score.ToString();
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore.text = "BestScore :" + " " + score.ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("BestScore") >= score)
            {
                bestScore.text = "BestScore :" + " " + PlayerPrefs.GetInt("BestScore").ToString();
            }
            else
            {
                bestScore.text = "BestScore :" + " " + score.ToString();
                PlayerPrefs.SetInt("BestScore", score);
            }
        }
        gameState = GameState.Lose;
        EndGameLvl.text = stage.ToString();
        
    }

    IEnumerator _LoseGame()
    {
        while (panelLose.localPosition!=finishPoint)
        {
            panelLose.localPosition = Vector3.Lerp(panelLose.localPosition, finishPoint, 3 * Time.deltaTime);
            yield return null;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndLvl()
    {
        gameState = GameState.Win;
        Destroy(target.gameObject);
        StartCoroutine(InstanceWoodLog());
    }

    IEnumerator InstanceWoodLog()
    {
        yield return new WaitForSeconds(2f); 
        var WoodLog = Instantiate(WoodLogPrefab, new Vector3(0f, 1f, 0), Quaternion.identity);
        target = WoodLog.GetComponent<Target>(); 
        target.notyfi += Score;
    }
    public void NextLvl()
    {
        nextLevel?.Invoke();
        gameState = GameState.Play;
        stage++;
        Lvl.text = "Stage : " + stage;
        if(PlayerPrefs.GetInt("Stage") < stage)
            PlayerPrefs.SetInt("Stage", stage);
    }
    private void OnDisable()
    {
        target.notyfi -= Score;
    }

}

public enum GameState { Play , Win , Lose}
