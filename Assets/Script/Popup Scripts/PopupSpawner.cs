using UnityEngine;

public class PopupSpawner : MonoBehaviour
{
    [Header("Popup Settings")]
    [SerializeField] private GameObject[] popupPrefabs;
    [SerializeField] private Transform popupLayer;
    [SerializeField] private float spawnInterval = 3f;

    private float nextSpawn;

    void Update()
    {
        if (popupPrefabs.Length == 0 || popupLayer == null) return;

        if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnInterval;

            int index = Random.Range(0, popupPrefabs.Length);
            GameObject popup = Instantiate(popupPrefabs[index], popupLayer);

            // Randomize position inside the Canvas
            RectTransform rt = popup.GetComponent<RectTransform>();
            if (rt != null)
            {
                float randomX = Random.Range(-300f, 300f); // adjust to fit your Canvas
                float randomY = Random.Range(-200f, 200f);
                rt.anchoredPosition = new Vector2(randomX, randomY);
            }
        }
    }
}
