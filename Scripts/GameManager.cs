using UnityEngine;
using UnityEngine.UI;
using TMPro;  
using UnityEngine.SceneManagement; // Ensure this is included for TextMeshPro

public class GameManager : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    public int award = 10 ;
   

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        SceneManager.LoadScene("a"); 

        Pause();
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void IncreaseScore()
    {
        score = score + 1;
        scoreText.text = score.ToString();
        if (score >= award)
        {
            LoadLevel2();

        }
    }

     public void LoadLevel2()
    {
        SceneManager.LoadScene("b"); 
        
    }

}

        
