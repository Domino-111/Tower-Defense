using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float timer, resetTime, spawnRate;
    public int waveCounter;

    // Timer countsdown and once reaches zero it'll spawn an enemy & reset the timer
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            StartCoroutine("Spawn");

            waveCounter++;

            timer = resetTime;
        }
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < waveCounter; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
