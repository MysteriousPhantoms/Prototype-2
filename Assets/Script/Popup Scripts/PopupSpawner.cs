using UnityEngine;

public class PopupSpawner : MonoBehaviour
{
    [Header("Popup Settings")]
    [SerializeField] private GameObject[] popupPrefabs; // drag prefabs here
    [SerializeField] private Transform popupLayer;      // UI parent (Panel under Canvas)
    [SerializeField] private float spawnInterval = 3f;  // seconds between spawns

    private float nextSpawn;

    void Update()
    {
        Debug.Log("Spawner Update running...");

        if (popupPrefabs.Length == 0 || popupLayer == null) return;

        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;

            int index = Random.Range(0, popupPrefabs.Length);
            Debug.Log("Spawning popup: " + popupPrefabs[index].name);

            Instantiate(popupPrefabs[index], popupLayer);
        }
    }
}
