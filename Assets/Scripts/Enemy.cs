using MyPathfinding;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health, speed;

    public Tower.Shape myShape;

    public Dijkstra pathFinder;

    public MyPathfinding.Node goalNode;
    public MyPathfinding.Node startNode;

    public List<MyPathfinding.Node> path = new List<MyPathfinding.Node>();

    private int point = 0;

    public GameManager gm;

    private int towerCheck;

    void Awake()
    {
        towerCheck = gm.availableTowers;

        pathFinder.GetAllNodes();

        MyPathfinding.Node[] nodes = FindObjectsByType<MyPathfinding.Node>(FindObjectsSortMode.InstanceID);
    }

    void Start()
    {
        CalculatePath();

        InvokeRepeating("MoveToNextPoint", speed, speed);

    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.game.score++;
            Destroy(gameObject);
        }

        if (gm.availableTowers < towerCheck)
        {
            Invoke("CalculatePath", 0.1f);
            towerCheck = gm.availableTowers;

            print("Path recalculated");
        }

        if (gm.availableTowers > towerCheck)
        {
            Invoke("CalculatePath", 0.1f);
            towerCheck = gm.availableTowers;
            print("Path recalculated");
        }
    }

    public void MoveToNextPoint()
    {
        if (point != path.Count)
        {
            point += 1;
            transform.position = path[point].transform.position;
            startNode = path[point];
        }
    }

    private void CalculatePath()
    {
        path = pathFinder.FindShortestPath(startNode, goalNode);
        point = 0;
    }
}
