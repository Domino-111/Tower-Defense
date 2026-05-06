using MyPathfinding;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health, speed;

    public Tower.Shape myShape;

    public Dijkstra pathFinder;

    public Node startNode, goalNode;

    public int point = 0;

    void Awake()
    {
        pathFinder.GetAllNodes();

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
    }

    void Start()
    {
        InvokeRepeating("MoveToNextPoint", 5f, 5f);
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.game.score++;
            Destroy(gameObject);
        }
    }

    public void MoveToNextPoint()
    {
        List<Node> path;
        path = pathFinder.FindShortestPath(startNode, goalNode);

        if (point != path.Count)
        {
            point += 1;
            //transform.position = path[point].transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, path[point].transform.position, speed * Time.deltaTime);
        }
    }
}
