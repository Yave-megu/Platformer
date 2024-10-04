using UnityEngine;
using TMPro;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public GameObject CinemachineCam;
    public TMP_Text TimeLimitLable;
    public LifeDisplayer LifeDisplayerInstance;
    public float TimeLimit = 20;
    private static GameManager instance;
    private int life = 3;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life =3;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;
        TimeLimitLable.text = "Time Left: " + ((int)TimeLimit);
    }

    public void AddTime(float time)
    {
        TimeLimit += time;
    }

    public void Die()
    {
        CinemachineCam.SetActive(false);
        life--;
        LifeDisplayerInstance.SetLives(life);
        
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        if (life > 0)
        {
            CinemachineCam.SetActive(true);
            Player.Restart();
        }
        else
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        Debug.Log("Game Over");
    }
    
}
