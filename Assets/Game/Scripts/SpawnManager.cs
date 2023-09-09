using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());

    }

    IEnumerator EnemySpawnRoutine() {
        while (true) {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerUpSpawnRoutine(){

        while(true) {
            int randomPowerup = Random.Range(0,3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }


    // create a coroutine to spawn the Enemy every 5 seconds
    // as long as the game running indefinitely, we spawn the powerups every 5 seconds


}
