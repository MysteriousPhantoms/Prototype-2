using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PowerLoader : MonoBehaviour
{
    [Header("Bar Settings")]
    public Image loadingFill;

    // Slower base speeds for longer gameplay
    [SerializeField] private float fillSpeed = 0.025f;
    [SerializeField] private float drainSpeed = 0.1f;

    [Header("Sabotage Settings")]
    private bool isSabotaged = false;
    private float sabotageMultiplier = 1f;

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
}
