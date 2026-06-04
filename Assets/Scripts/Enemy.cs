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

    // Gets the first path
    void Start()
    {
        CalculatePath();

        InvokeRepeating("MoveToNextPoint", speed, speed);
    }

    void Update()
    {
        // When health is zero increase the player's score and remove the object
        if (health <= 0)
        {
            GameManager.game.score++;
            Destroy(gameObject);
        }

        // Recalculates the path whenever a tower is placed or removed
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

        //MoveToNextPoint();
    }

    // Determines the next node to move towards and updates what the start node is
    public void MoveToNextPoint()
    {
        if (point != path.Count)
        {
            point += 1;
            transform.position = Vector2.MoveTowards(transform.position, path[point].transform.position, (speed * Time.fixedDeltaTime)) * 2;

            //transform.position = path[point].transform.position;
            startNode = path[point];
        }
    }

    // Calculates the shortest path the final node determined in game
    private void CalculatePath()
    {
        path = pathFinder.FindShortestPath(startNode, goalNode);
        point = 0;
    }
}
