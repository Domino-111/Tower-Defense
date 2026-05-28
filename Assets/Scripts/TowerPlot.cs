using System.Collections.Generic;
using UnityEngine;

public class TowerPlot : MonoBehaviour
{
    public bool towerPlaced = false;

    public GameObject demolishMenu, tower;

    public GameManager gm;

    public List<MyPathfinding.Node> nodesInRange = new List<MyPathfinding.Node>();

    public MyPathfinding.Node node;

    public float weightIncrease;

    void Awake()
    {
        demolishMenu.SetActive(false);

        gm = GameManager.FindFirstObjectByType<GameManager>();
    }

    void Start()
    {
        if (towerPlaced == true)
        {
            Invoke("IncreasePathWeight", 0.1f);
        }
    }

    // Bring up demolish option and close menu after inactivity
    public void Options()
    {
        if (towerPlaced == true)
        {
            demolishMenu.SetActive(true);

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
        DecreasePathWeight();
        Destroy(transform.GetChild(1).gameObject);
        gm.availableTowers += 1;
        towerPlaced = false;
        demolishMenu.SetActive(false);
    }

    public void MenuTimer()
    {
        demolishMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When placed the tower will find all the nodes in its range
        if (collision.TryGetComponent<MyPathfinding.Node>(out MyPathfinding.Node path))
        {
            nodesInRange.Add(path);
            node = path;
        }
    }

    // Increases the path weight
    private void IncreasePathWeight()
    {
        foreach (var node in nodesInRange)
        {
            node.pathWeight += weightIncrease;
        }
    }

    // Decrease the path weight back to normal when the tower is removed
    private void DecreasePathWeight()
    {
        foreach (var node in nodesInRange)
        {
            node.pathWeight -= weightIncrease;
        }
    }
}
