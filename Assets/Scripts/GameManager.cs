using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public TMP_Text scoreText, AT_text;
    public int score = 0;

    public int availableTowers;

    void Awake()
    {
        game = this;
    }

    void Update()
    {
        //UpdateScore();
        AvailableTowers();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AvailableTowers()
    {
        AT_text.text = "Towers\n" + availableTowers.ToString() + "/8";
    }
}
