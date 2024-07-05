using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //-------------------PUBLIC-------------------
    [SerializeField] GameObject UICanvas;
    [SerializeField] TMP_Text score_text;
    [SerializeField] TMP_Text timer_text;
    [SerializeField] GameObject GameplayUI;
    [SerializeField] GameObject EndScreen;
    [SerializeField] TMP_Text playerScore_text;
    [SerializeField] TMP_Text highScore_text;


    //-------------------PRIVATE-------------------
    float timer = 60;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        DontDestroyOnLoad(UICanvas);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            timer -= Time.deltaTime;
            timer_text.text = $"Time: {Mathf.CeilToInt(timer)}";

            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    public void increaseScore(int points)
    {
        score += points;
        score_text.text = $"Score: {score}";
    }

    void EndGame()
    {
        Time.timeScale = 0.0f;
        GameplayUI.SetActive(false);
        EndScreen.SetActive(true);
        playerScore_text.text = $"Your Score: {score}";
        if (score > PlayerPrefs.GetInt("HighScore_farm"))
        {
            PlayerPrefs.SetInt("HighScore_farm", score);
        }
        highScore_text.text = $"High Score: {PlayerPrefs.GetInt("HighScore_farm")}";
    }

    public void RestartButton(int scene)
    {
        Time.timeScale = 1.0f;
        score = 0;
        score_text.text = $"Score: {score}";
        timer = 60;
        GameplayUI.SetActive(true);
        EndScreen.SetActive(false);
        SceneManager.LoadScene(scene);
    }

    public void MenuButton(int scene)
    {
        Time.timeScale = 1.0f;
        score = 0;
        score_text.text = $"Score: {score}";
        timer = 60;
        GameplayUI.SetActive(true);
        EndScreen.SetActive(false);
        SceneManager.LoadScene(scene);
    }
}
