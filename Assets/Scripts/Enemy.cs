using MyPathfinding;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float health, speed;
    public GameObject self;

    public Tower.Shape myShape;

    public Dijkstra pathFinder;

    public Node startNode, goalNode;

    [ContextMenu("Test")]
    void Awake()
    {
        pathFinder.GetAllNodes();

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);



        //pathFinder.DebugPath(path);
    }

    void Update()
    {
        if (health <= 0)
        {
            GameManager.game.score++;
            Destroy(gameObject);
        }
        self.transform.position = Vector3.MoveTowards(self.transform.position, goalNode.transform.position, 1000);
        //Movement();
    }

    public void Movement(List<Node> path)
    {
        path = pathFinder.FindShortestPath(startNode, goalNode);

        
    }
}
