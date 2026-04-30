using UnityEngine;

public class TowerPlot : MonoBehaviour
{
    public bool towerPlaced = false;

    public GameObject towerOptions, tower;

    public GameManager gm;

    void Awake()
    {
        towerOptions.SetActive(false);

        gm = GameManager.FindFirstObjectByType<GameManager>();
    }

    // Bring up demolish option and close menu after inactivity
    public void Options()
    {
        if (towerPlaced == true)
        {
            towerOptions.SetActive(true);

            Invoke("MenuTimer", 4f);
        }
    }

    // Place the tower
    public void Tower()
    {
        if (gm.availableTowers > 0 && towerPlaced == false)
        {
            Instantiate(tower, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            gm.availableTowers -= 1;
            towerPlaced = true;
        }
    }

    // Destroy the tower on the plot
    public void Demolish()
    {
        Destroy(transform.GetChild(1).gameObject);
        gm.availableTowers += 1;
        towerPlaced = false;
        towerOptions.SetActive(false);
    }

    public void MenuTimer()
    {
        towerOptions.SetActive(false);
    }
}
