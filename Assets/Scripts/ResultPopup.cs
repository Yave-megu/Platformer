using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text resultTitle;
    [SerializeField]
    private TMP_Text ScoreLabel;
    [SerializeField]
    private GameObject HighScoreObject;
    [SerializeField]
    private GameObject HighScorePopup;
    private void OnEnable()
    {
        Time.timeScale = 0;
        if(GameManager.Instance.IsCleared)
        {
            resultTitle.text = "Game Clear!";
            ScoreLabel.text = "Score: " + ((int)GameManager.Instance.TimeLimit);
            SaveHighScore();
        }
        else
        {
            resultTitle.text = "Game Over!";
            ScoreLabel.text = "Score: 0";
        }
    }

    public void SaveHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScores", 0);
        float Score = GameManager.Instance.TimeLimit;
        ;
        if (Score> highScore)
        {
            
            HighScoreObject.SetActive(true);
            PlayerPrefs.SetFloat("HighScore", Score);
            PlayerPrefs.Save();
        }
        else
        {
            HighScoreObject.SetActive(false);    
        }

        string currentScoreString = Score.ToString("#.##");
        string saveScoreString = PlayerPrefs.GetString("HighScores", "");
        if (saveScoreString == "")
        {
            PlayerPrefs.SetString("HighScores", currentScoreString);
        }
        else
        {
            string[] ScoreArray = saveScoreString.Split(',');
            List<string> scoreList = new List<string>(ScoreArray);
            for (int i = 0; i < scoreList.Count; i++)
            {
                float saveScore = float.Parse(scoreList[i]);
                if (saveScore < Score)
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }
            if (ScoreArray.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }

            if (scoreList.Count > 10)
            {
                scoreList.RemoveAt(10);
            }
            
            string result = string.Join(",", scoreList.ToArray());
            Debug.Log(result);
            PlayerPrefs.SetString("HighScores", result);
        }
        PlayerPrefs.Save();

    }

    public void AgainPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    
    public void QuitPressed()
    {
        Application.Quit();
    }

    public void ShowHighScorePressed()
    {
        HighScorePopup.SetActive(true);
    }
    
}
