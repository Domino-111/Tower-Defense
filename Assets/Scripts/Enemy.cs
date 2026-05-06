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
        InvokeRepeating("MoveToNextPoint", 1f, 1f);
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.game.score++;
            Destroy(gameObject);
        }

        if (transform.position != goalNode.transform.position)
        {
            //Movement();
        }
    }

    public void Movement()
    {
        
        
        //for (int i = 0; i < path.Count - 1; i++)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, path[i + 1].transform.position, (Time.deltaTime * speed));
        //}
    }

    public void MoveToNextPoint()
    {
        List<Node> path;
        path = pathFinder.FindShortestPath(startNode, goalNode);

        if (point != path.Count)
        {
            point += 1;
            transform.position = path[point].transform.position;
        }
    }
}
