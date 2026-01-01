using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : MonoBehaviour
{
    public SwordMovement swordPrefebs;
    public Vector2 minMaxSpawn,
        minMaxDelaySpawn,
        minMaxSwordSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSwordCoroutine());
    }

    IEnumerator SpawnSwordCoroutine()
    {
        transform.position = new Vector3
            (Random.Range(minMaxSpawn.x, minMaxSpawn.y), 5.27f , 0);
        var sword = Instantiate(swordPrefebs, transform.position, Quaternion.identity);
        sword.fallingSpeed = Random.Range(minMaxSwordSpeed.x, minMaxSwordSpeed.y);
        yield return new WaitForSeconds(Random.Range(minMaxDelaySpawn.x, minMaxDelaySpawn.y));
        StartCoroutine(SpawnSwordCoroutine());
    }
}
