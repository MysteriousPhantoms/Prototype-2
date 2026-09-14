using UnityEngine;

public class PopupSpawner : MonoBehaviour
{
    [Header("Popup Settings")]
    [SerializeField] private GameObject[] popupPrefabs;
    [SerializeField] private Transform popupLayer;
    [SerializeField] private float spawnInterval = 3f;

    private float nextSpawn;
    private bool isActive = true; // NEW flag

    void Update()
    {
        if (!isActive) return; // stop spawning if inactive

        if (popupPrefabs.Length == 0 || popupLayer == null) return;

        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;

            int index = Random.Range(0, popupPrefabs.Length);
            GameObject popup = Instantiate(popupPrefabs[index], popupLayer);

            // Random position
            RectTransform rt = popup.GetComponent<RectTransform>();
            if (rt != null)
            {
                float randomX = Random.Range(-300f, 300f);
                float randomY = Random.Range(-200f, 200f);
                rt.anchoredPosition = new Vector2(randomX, randomY);
            }
        }
    }

    // NEW method PowerLoader can call
    public void StopSpawning()
    {
        isActive = false;
    }
}
