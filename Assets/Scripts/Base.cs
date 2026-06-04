using UnityEngine;
using static UnityEditor.MaterialProperty;

public class Base : MonoBehaviour
{
    public GameObject endScreen;

    public GameManager gm;

    // Ensures the win screen isn't seen prematurely
    void Awake()
    {
        endScreen.SetActive(false);
    }

    // Once an enemy touches the base it'll freeze the game and turn on the win screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        
        endScreen.SetActive(true);

        gm.isPlaying = false;
        gm.FinalScore();

        Debug.Log("Collision detected");
    }
}
