using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public TMP_Text scoreText, AT_text, finalScoreText;

    public int score = 0;
    public int availableTowers;

    public GameObject menu, environment, instructions;

    public bool isPlaying = false;

    // Ensure the right things are visible before the first frame is seen
    void Awake()
    {
        game = this;
        isPlaying = false;

        menu.SetActive(true);
        environment.SetActive(false);
        instructions.SetActive(false);
    }

    void Update()
    {
        // Only run these methods if the game is playing
        if (isPlaying == true)
        {
            UpdateScore();
            AvailableTowers();
        }

        // Can close the game anytime with the escape button
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Game Closed");
            Application.Quit();
        }
    }

    // Restarts the game
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        isPlaying = false;
        Time.timeScale = 1;
    }

    // Shows how many enemies you've killed
    public void UpdateScore()
    {
        scoreText.text = "Kills: " + score.ToString();
    }

    // Shows the available towers you can place
    public void AvailableTowers()
    {
        AT_text.text = "Towers\n" + availableTowers.ToString() + "/8";
    }

    // Begin the game by turning off the menu and turning on the game environment
    public void StartGame()
    {
        environment.SetActive(true);
        menu.SetActive(false);

        isPlaying = true;
    }

    // Turn on the instructions page
    public void InstructionsOpen()
    {
        instructions.SetActive(true);
    }

    // Turn off the instructions page
    public void InstructionsClosed()
    {
        instructions.SetActive(false);
    }

    // Calculates the final score once the game ends
    public void FinalScore()
    {
        score *= 100;

        finalScoreText.text = score.ToString();
    }
}
