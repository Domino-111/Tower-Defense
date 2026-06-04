using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer beam;
    public Transform target1, target2;

    void Start()
    {
        beam.positionCount = 2;
    }

    void Update()
    {
        beam.SetPosition(0, target2.position);
        beam.SetPosition(1, target1.position);
    }
}
