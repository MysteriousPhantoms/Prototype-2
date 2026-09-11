using UnityEngine;

public class PopupSpawner : MonoBehaviour
{
    [Header("Popup Settings")]
    [SerializeField] private GameObject[] popupPrefabs; // drag all your prefabs here
    [SerializeField] private Transform popupLayer;      // UI parent (like a Panel under Canvas)
    [SerializeField] private float spawnInterval = 3f;  // seconds between spawns

    private float nextSpawn;

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;

            int index = Random.Range(0, popupPrefabs.Length);
            Instantiate(popupPrefabs[index], popupLayer);
        }
    }
}
