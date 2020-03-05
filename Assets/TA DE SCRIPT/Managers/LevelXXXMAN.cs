using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelXXXMAN : MonoBehaviour
{
    public Transform[] badSpawn;
    public GameObject badPrefab;
    public int badWaves = 3;
    public float waitTimeFirstWave = 2f;
    public float waiTimeBetweenWaves = 4f;

    void Start()
    {
        StartCoroutine(SpawnBad());
    }

    // Update is called once per frame
    IEnumerator SpawnBad()
    {
        yield return new WaitForSeconds(waitTimeFirstWave);
        for (int i = 0; i < badWaves; i++ )
        {
            for (int j = 0; j <badSpawn.Length; j++)
            {
                
                Instantiate(badPrefab, badSpawn[j].position, Quaternion.identity);


            }
            yield return new WaitForSeconds (waiTimeBetweenWaves);
        }
    }
}
