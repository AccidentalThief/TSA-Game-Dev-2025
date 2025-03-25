using UnityEngine;

public class DudeSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnAreaWidth = 10f; // Adjust the width of the spawn area
    public float spawnRate = 4f; // Spawns per second

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnPrefab()
    {
        float randomX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        // Generate a random rotation (Euler angles)
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        // Instantiate the prefab with the random rotation
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, randomRotation);

        if (spawnedObject.GetComponent<Collider>() == null) {
            spawnedObject.AddComponent<CapsuleCollider>();
        }
        
        if(spawnedObject.GetComponent<Rigidbody>() == null)
        {
            spawnedObject.AddComponent<Rigidbody>();
        }
    }
}
