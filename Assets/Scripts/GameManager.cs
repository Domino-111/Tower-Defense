using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public TMP_Text scoreText;
    public int score = 0;

    public int availableTowers;

    void Awake()
    {
        game = this;
    }

    void Update()
    {
        UpdateScore();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
