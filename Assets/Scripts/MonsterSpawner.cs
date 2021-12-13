using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MonsterSpawner : MonoBehaviour {

    public List<Monster> availableMonsterPrefab;
    public MeshFilter meshfilter;
    public AudioSource spawnAudioSource;

    private static Monster spawnedMonster;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke(nameof(SpawnMonster), 2);
    }

    private void SpawnMonster()
    {
        if (spawnedMonster != null)
        {
            return;
        }

        var selectedPrefab = availableMonsterPrefab[Random.Range(0,
            availableMonsterPrefab.Count)];

        var position = transform.position + meshfilter.mesh.bounds.center;

        spawnedMonster = Instantiate(selectedPrefab, position, Quaternion.identity);

        spawnAudioSource.Play();

        FindObjectOfType<ARPlaneManager>().subsystem.Stop();

    }

    public static void MonsterCapture()
    {
        spawnedMonster = null;
        FindObjectOfType<ARPlaneManager>().subsystem.Start();
    }
    
}
