using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float damage, fireRate, boostCounter, killCount;

    private List<Enemy> enemiesInRange = new List<Enemy>();

    public Enemy enemy;

    // Create a set list of shapes a tower or enemy can be
    public enum Shape 
    { circle, 
      triangle, 
      hexagon
    }

    public Shape towerShape;

    void Update()
    {
        if (enemiesInRange.Count>0)
        {
            Attack();
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

    private void Attack()
    {
        enemy.health -= Time.deltaTime * damage;
    }
}
