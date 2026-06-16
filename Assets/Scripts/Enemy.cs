using MyPathfinding;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health, updateRate;

    public Tower.Shape myShape;

    public Dijkstra pathFinder;

    public MyPathfinding.Node goalNode;
    public MyPathfinding.Node startNode;

    public List<MyPathfinding.Node> path = new List<MyPathfinding.Node>();

    private int point = 0;

    public GameManager gm;

    private int towerCheck;

    private Vector2 currentPosition;

    void Awake()
    {
        pathFinder = Dijkstra.FindFirstObjectByType<Dijkstra>();
        gm = GameManager.FindFirstObjectByType<GameManager>();

        towerCheck = gm.availableTowers;

        pathFinder.GetAllNodes();

        MyPathfinding.Node[] nodes = FindObjectsByType<MyPathfinding.Node>(FindObjectsSortMode.InstanceID);

        // Used to find the right node index number
        //for (int i = 0; i < nodes.Length; i++)
        //{
        //    print("Index Position: " + i + " ID " + nodes[i]);
        //}

        goalNode = nodes[54];
        startNode = nodes[60];
    }

    // Gets the first path
    void Start()
    {
        CalculatePath();

        currentPosition = transform.position;
        //InvokeRepeating("MoveToNextPoint", updateRate, updateRate);
    }

    void Update()
    {
        MoveToNextPoint();

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
    }

    // Determines the next node to move towards and updates what the start node is
    public void MoveToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, path[point].transform.position, Time.deltaTime);

        if (Vector3.Distance(transform.position, path[point].transform.position) < 0.1)
        {
            point += 1;

            startNode = path[point];
        }

        //if (point != path.Count)
        //{
        //    point += 1;

        //    transform.position = path[point].transform.position;

        //    startNode = path[point];
        //}
    }

    // Calculates the shortest path the final node determined in game
    private void CalculatePath()
    {
        path = pathFinder.FindShortestPath(startNode, goalNode);
        point = 0;
    }
}
