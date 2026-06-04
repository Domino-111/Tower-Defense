using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage, fireRate;

    private List<Enemy> enemiesInRange = new List<Enemy>();

    public Enemy enemy;

    public LineRenderer beam;

    // Create a set list of shapes a tower or enemy can be
    public enum Shape
    {
        circle,
        triangle,
        hexagon
    }

    public Shape towerShape;

    void Start()
    {
        beam.positionCount = 2;
    }

    void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            Attack();
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, enemy.transform.position);
        }

        else
        {
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, transform.position);
        }
    }

    // Check if a matching enemy shape is within range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy combatant))
        {
            if (combatant.myShape == towerShape)
            {
                enemiesInRange.Add(combatant);
                enemy = combatant;
            }
        }
    }

    // Check when enemies leave range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy combatant))
        {
            enemiesInRange.Remove(combatant);
        }
    }

    // Attacks the enemy
    private void Attack()
    {
        enemy.health -= Time.deltaTime * damage;
    }
}
