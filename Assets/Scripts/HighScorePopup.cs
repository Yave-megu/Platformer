using TMPro;
using UnityEngine;

public class HighScorePopup : MonoBehaviour
{
    public TMP_Text ScoreLabel1;
    public TMP_Text ScoreLabel2;
    
    private void OnEnable()
    {
        string[] scores = PlayerPrefs.GetString("HighScores", "").Split(',');
        string result1 = "";
        string result2 = "";
        
        for (int i = 0; i < scores.Length/2; i++)
        {
            result1 += (i + 1) + "." +scores[i] + "\n";
            result2 += (i + 1+ scores.Length/2) + "." +scores[i + scores.Length/2] + "\n";
        }
        
        ScoreLabel1.text = result1;
        ScoreLabel2.text = result2;
    }
    
    
    public void ClosePressed()
    {
        gameObject.SetActive(false);
    }
}
