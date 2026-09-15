using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PowerLoader : MonoBehaviour
{
    [Header("Bar Settings")]
    public Image loadingFill;

    [SerializeField] private float fillSpeed = 0.025f;
    [SerializeField] private float drainSpeed = 0.1f;

    [Header("Sabotage Settings")]
    private bool isSabotaged = false;
    private float sabotageMultiplier = 1f;

    [Header("Win Screen Settings")]
    [SerializeField] private GameObject winScreenPrefab;
    [SerializeField] private Transform winLayer;
    private bool hasWon = false;

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            float speed = fillSpeed * (isSabotaged ? sabotageMultiplier : 1f);
            loadingFill.fillAmount += speed * Time.deltaTime;
        }
        else
        {
            loadingFill.fillAmount -= drainSpeed * Time.deltaTime;
        }

        loadingFill.fillAmount = Mathf.Clamp01(loadingFill.fillAmount);

        // Trigger win screen when bar reaches 100%
        if (loadingFill.fillAmount >= 1f && !hasWon)
        {
            ShowWinScreen();
        }
    }

    public void LoseProgress(float amount)
    {
        loadingFill.fillAmount -= amount;
        loadingFill.fillAmount = Mathf.Clamp01(loadingFill.fillAmount);
    }

    public void ApplySabotage(float multiplier)
    {
        isSabotaged = true;
        sabotageMultiplier = multiplier;
    }

    public void ClearSabotage()
    {
        isSabotaged = false;
        sabotageMultiplier = 1f;
    }

    private void ShowWinScreen()
    {
        if (hasWon) return;
        hasWon = true;

        ClearSabotage();

        // Stop spawner
        PopupSpawner spawner = FindObjectOfType<PopupSpawner>();
        if (spawner != null) spawner.StopSpawning();

        // Enable WinLayer
        winLayer.gameObject.SetActive(true);

        // Spawn win screen prefab into WinLayer
        Instantiate(winScreenPrefab, winLayer);
    }
}
