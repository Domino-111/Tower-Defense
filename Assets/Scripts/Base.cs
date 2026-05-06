using UnityEngine;
using static UnityEditor.MaterialProperty;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
    }
}
